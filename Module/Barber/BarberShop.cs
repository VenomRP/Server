using GTANetworkAPI;
using GVRP.Module.Spawners;
using MySql.Data.MySqlClient;

namespace GVRP.Module.Barber
{
    public class BarberShop : Loadable<uint>
    {
        public uint Id { get; }
        public string Name { get; }
        public Vector3 Position { get; }
        public float Heading { get; }
        public ColShape ColShape { get; set; }

        public BarberShop(MySqlDataReader reader) : base(reader)
        {
            Id = reader.GetUInt32("id");
            Name = reader.GetString("name");
            Position = new Vector3(reader.GetFloat("pos_x"), reader.GetFloat("pos_y"), reader.GetFloat("pos_z"));
            Heading = reader.GetFloat("heading");

            ColShape = ColShapes.Create(Position, 3.0f);
            ColShape.SetData("barberShopId", Id);
        }

        public override uint GetIdentifier()
        {
            return Id;
        }
    }
}