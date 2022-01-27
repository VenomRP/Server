namespace GVRP.Module.Storage
{
    public class StorageRoomAusbaustufenModule : SqlModule<StorageRoomAusbaustufenModule, StorageRoomAusbaustufe, uint>
    {
        protected override string GetQuery()
        {
            return "SELECT * FROM `storage_rooms_ausbaustufen`;";
        }
    }
}