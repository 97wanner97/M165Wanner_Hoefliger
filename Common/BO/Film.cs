using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Configuration;

namespace Common.BO
{
    public class Film
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
        string databaseName = ConfigurationManager.AppSettings["DatabaseName"];


        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public int AnzahlMinuten { get; set; }
        public string Kategorie { get; set; }
        public string Hauptdarsteller { get; set; }
        public int AnzahlSchauspieler { get; set; }
        public ObjectId FilmproduzentId { get; set; }
    }
}
