using MySql.Data.MySqlClient;
using System;

namespace GVRP.Module.Geschenk
{
    public class Geschenk : Loadable<uint>
    {

        public uint Id { get; }
        public uint PlayerId { get; set; }
        public uint PlayerRank { get; set; }
        public String Message { get; set; }

        public Geschenk(MySqlDataReader reader) : base(reader)
        {
            Id = reader.GetUInt32("id");
            PlayerId = reader.GetUInt32("player_id");
            PlayerRank = reader.GetUInt32("player_rank");
            Message = reader.GetString("message");
        }

        public override uint GetIdentifier()
        {
            return Id;
        }
    }
}
