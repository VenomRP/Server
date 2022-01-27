using System.Collections.Generic;
using System.Xml.Serialization;

namespace GVRP.Module.MapParser
{
    public sealed class MapParserModule : Module<MapParserModule>
    {
        Dictionary<string, List<GTANetworkAPI.Object>> objectList = new Dictionary<string, List<GTANetworkAPI.Object>>();



        public void ReadMenyooMap(string file)
        {


        }

        public void ReadMap(string file)
        {


        }
    }

    /* MENYOO XML */
    [XmlRoot("SpoonerPlacements")]
    public class MMap
    {
        [XmlElement("Placement")]
        public List<MMapObject> MapObjects { get; set; }
    }
    public class MMapObject
    {
        [XmlElement("PositionRotation")]
        public PositionRotation PositionRotation { get; set; }

        [XmlElement("HashName")]
        public string Hash { get; set; }
    }

    public class PositionRotation
    {
        [XmlElement("X")]
        public float x { get; set; }

        [XmlElement("Y")]
        public float y { get; set; }

        [XmlElement("Z")]
        public float z { get; set; }

        [XmlElement("Pitch")]
        public float rx { get; set; }

        [XmlElement("Roll")]
        public float ry { get; set; }

        [XmlElement("PositionRot")]
        public float rz { get; set; }
    }

    /* DEFAULT MAP EDITOR XML */
    [XmlRoot("Map")]
    public class Map
    {
        [XmlElement("Objects")]
        public Object Objects { get; set; }
    }


    public class Object
    {
        [XmlElement("MapObject")]
        public List<MapObject> MapObjects { get; set; }
    }
    public class MapObject
    {
        [XmlElement("Position")]
        public ObjectPosition Position { get; set; }

        [XmlElement("Rotation")]
        public ObjectRotation Rotation { get; set; }

        [XmlElement("Hash")]
        public int Hash { get; set; }
    }

    public class ObjectPosition
    {
        [XmlElement("X")]
        public float x { get; set; }

        [XmlElement("Y")]
        public float y { get; set; }

        [XmlElement("Z")]
        public float z { get; set; }
    }

    public class ObjectRotation
    {
        [XmlElement("X")]
        public float x { get; set; }

        [XmlElement("Y")]
        public float y { get; set; }

        [XmlElement("Z")]
        public float z { get; set; }
    }
}