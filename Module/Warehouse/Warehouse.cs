using GTANetworkAPI;
using GVRP.Module.Spawners;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace GVRP.Module.Warehouse
{
    public class Warehouse : Loadable<uint>
    {
        public uint Id { get; }
        public Vector3 Position { get; set; }
        public float Heading { get; set; }

        public List<WarehouseItem> WarehouseItems { get; set; }
        public Warehouse(MySqlDataReader reader) : base(reader)
        {
            Id = reader.GetUInt32("id");
            Position = new Vector3(reader.GetFloat("pos_x"), reader.GetFloat("pos_y"),
                reader.GetFloat("pos_z"));
            Heading = reader.GetFloat("heading");
            WarehouseItems = WarehouseItemModule.Instance.GetAll().Values.Where(wi => wi.WareHouseId == Id).ToList();

            // Create Blip
            Main.ServerBlips.Add(Blips.Create(Position, "Warenhandel", 478, 1.0f));
        }

        public override uint GetIdentifier()
        {
            return Id;
        }
    }
}
