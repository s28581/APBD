using System.Data.SqlTypes;

namespace REST_API.Models;

public class Warehouse {
    public int IdProduct { get; set; }
    public int IdWarehouse { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}