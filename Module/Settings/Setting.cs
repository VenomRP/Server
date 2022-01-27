using MySql.Data.MySqlClient;
using System;

namespace GVRP.Module.Settings
{
    public class Setting : Loadable<uint>
    {

        public uint Id { get; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string ModuleName { get; set; }
        public DateTime Updated { get; set; }


        public Setting(MySqlDataReader reader) : base(reader)
        {
            Id = reader.GetUInt32("id");
            Key = reader.GetString("key");
            Value = reader.GetString("value");
            ModuleName = reader.GetString("modulename");
            Updated = reader.GetDateTime("updated");
        }

        public override uint GetIdentifier()
        {
            return Id;
        }
    }
}