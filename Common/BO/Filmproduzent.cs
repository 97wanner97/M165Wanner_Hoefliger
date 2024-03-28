using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.BO
{
    public class Filmproduzent
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string Hauptsitz { get; set; }
        public int AnzahlMitarbeiter { get; set; }
        public int Gruendungsjahr { get; set; }
    }
}
