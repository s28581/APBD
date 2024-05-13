using REST_API.Models;

namespace REST_API.Services;

public interface IWarehouseService
{
    int InsertIntoProductWarehouse(Warehouse warehouse);
    int InsertStored(Warehouse warehouse);
}