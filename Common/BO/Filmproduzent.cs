using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Configuration;

namespace Common.BO
{
    public class Filmproduzent
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
        string databaseName = ConfigurationManager.AppSettings["DatabaseName"];


        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string Hauptsitz { get; set; }
        public int AnzahlMitarbeiter { get; set; }
        public int Gruendungsjahr { get; set; }
    }
}
