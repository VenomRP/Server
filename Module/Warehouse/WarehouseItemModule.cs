namespace GVRP.Module.Warehouse
{
    public class WarehouseItemModule : SqlModule<WarehouseItemModule, WarehouseItem, uint>
    {
        protected override string GetQuery()
        {
            return "SELECT * FROM `warehouses_items`;";
        }
    }
}
