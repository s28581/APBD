using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using REST_API.Models;

namespace REST_API.Services;

public class WarehouseService(IConfiguration configuration) : IWarehouseService
{
    public int InsertStored(Warehouse warehouse)
    {
        using var sqlConnection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        using var command = new SqlCommand("EXEC AddProductToWarehouse @IdProduct, @IdWarehouse, @Amount, @CreatedAt", sqlConnection);
        command.Parameters.AddWithValue("@IdProduct", warehouse.IdProduct);
        command.Parameters.AddWithValue("@IdWarehouse", warehouse.IdWarehouse);
        command.Parameters.AddWithValue("@Amount", warehouse.Amount);
        command.Parameters.AddWithValue("@CreatedAt", warehouse.CreatedAt);
        sqlConnection.Open();
        command.ExecuteNonQuery();

        int idOrder = GetIdOrder(sqlConnection, warehouse.IdProduct, warehouse.Amount);
        command.CommandText = "SELECT IdProductWarehouse FROM Product_Warehouse WHERE IdOrder = @IdOrder";
        command.Parameters.AddWithValue("@IdOrder", idOrder);
        return (int)command.ExecuteScalar();
    }
    
    public int InsertIntoProductWarehouse(Warehouse warehouse)
    {
        using var sqlConnection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        sqlConnection.Open();
        if (!ProductExists(sqlConnection, warehouse.IdProduct))
            throw new Exception("Product does not exist");
        if (!WarehouseExists(sqlConnection, warehouse.IdWarehouse))
            throw new Exception("Warehouse does not exist");
        if (warehouse.Amount <= 0 )
            throw new Exception("Amount should be greater than 0");
        if (!OrderExists(sqlConnection, warehouse.IdProduct, warehouse.Amount, warehouse.CreatedAt))
            throw new Exception("Order does not exist");
        if (OrderCompleted(sqlConnection, warehouse.IdProduct, warehouse.Amount))
            throw new Exception("Order is already completed");

        int idOrder = GetIdOrder(sqlConnection, warehouse.IdProduct, warehouse.Amount);
        return FulfillOrder(sqlConnection, warehouse, idOrder);
    }

    private int FulfillOrder(SqlConnection sqlConnection, Warehouse warehouse, int idOrder)
    {
        using var command = new SqlCommand("UPDATE [Order] Set FulfilledAt = GETDATE() WHERE IdOrder = @IdOrder", sqlConnection);
        command.Parameters.AddWithValue("@IdOrder", idOrder);
        command.ExecuteNonQuery();
        
        command.CommandText = "SELECT Price FROM Product WHERE IdProduct = @IdProduct";
        command.Parameters.AddWithValue("@IdProduct", warehouse.IdProduct);
        double price = decimal.ToDouble((decimal)command.ExecuteScalar());
        
        command.CommandText = "INSERT INTO Product_Warehouse VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, GETDATE())";
        command.Parameters.AddWithValue("@IdWarehouse", warehouse.IdWarehouse);
        command.Parameters.AddWithValue("@Amount", warehouse.Amount);
        command.Parameters.AddWithValue("@Price", warehouse.Amount * price);
        command.ExecuteNonQuery();
        
        command.CommandText = "SELECT IdProductWarehouse FROM Product_Warehouse WHERE IdOrder = @IdOrder";
        return (int)command.ExecuteScalar();
    }

    private bool OrderCompleted(SqlConnection sqlConnection, int idProduct, int amount)
    {
        int idOrder = GetIdOrder(sqlConnection, idProduct, amount);
        using var command = new SqlCommand("SELECT COUNT(1) FROM Product_Warehouse WHERE IdOrder = @Id", sqlConnection);
        command.Parameters.AddWithValue("@Id", idOrder);
        return (int)command.ExecuteScalar() > 0;
    }

    private int GetIdOrder(SqlConnection sqlConnection, int idProduct, int amount)
    {
        using var command = new SqlCommand("SELECT IdOrder FROM [Order] WHERE IdProduct = @Id AND Amount = @Amount", sqlConnection);
        command.Parameters.AddWithValue("@Id", idProduct);
        command.Parameters.AddWithValue("@Amount", amount);
        return (int)command.ExecuteScalar();
    }

    private bool OrderExists(SqlConnection sqlConnection, int idProduct, int amount, DateTime dateTime)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM [Order] WHERE IdProduct = @Id AND Amount = @Amount", sqlConnection);
        command.Parameters.AddWithValue("@Id", idProduct);
        command.Parameters.AddWithValue("@Amount", amount);
        if ((int)command.ExecuteScalar() == 0) return false;
        
        command.CommandText = "SELECT CreatedAt FROM [Order] WHERE IdProduct = @Id AND Amount = @Amount";
        DateTime createdAt = (DateTime)command.ExecuteScalar();
        return createdAt.CompareTo(dateTime) < 0;
    }
    
    private bool ProductExists(SqlConnection sqlConnection, int id)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM Product WHERE IdProduct = @Id", sqlConnection);
        command.Parameters.AddWithValue("@id", id);
        return (int)command.ExecuteScalar() > 0;
    }

    private bool WarehouseExists(SqlConnection sqlConnection, int id)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM Warehouse WHERE IdWarehouse = @Id", sqlConnection);
        command.Parameters.AddWithValue("@id", id);
        return (int)command.ExecuteScalar() > 0;
    }
}