using MySql.Data.MySqlClient;

namespace GVRP.Module.Tattoo
{
    public class TattooLicense : Loadable<uint>
    {
        public uint Id { get; }
        public uint AssetsTattooId { get; }
        public int Price { get; }

        public TattooLicense(MySqlDataReader reader) : base(reader)
        {
            Id = reader.GetUInt32("id");
            AssetsTattooId = reader.GetUInt32("assets_tattoo_id");
            Price = reader.GetInt32("price");
        }

        public override uint GetIdentifier()
        {
            return Id;
        }
    }
}
