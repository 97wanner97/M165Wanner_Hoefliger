using MongoDB.Driver;
using Common.BO;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Configuration;

namespace _002_Repository
{
    /// <summary>
    /// Verwaltet die Datenzugriffsoperationen für Filmproduzenten.
    /// </summary>
    public class FilmproduzentRepository
    {
        private readonly IMongoCollection<Filmproduzent> _filmproduzenten;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="FilmproduzentRepository"/> Klasse.
        /// </summary>
        public FilmproduzentRepository()
        {
            var settings = ConfigurationManager.ConnectionStrings["MongoDB"];
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["DatabaseName"]);

            _filmproduzenten = database.GetCollection<Filmproduzent>("filmproduzenten");
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="FilmproduzentRepository"/> Klasse.
        /// </summary>
        /// <param name="client">Der <see cref="IMongoClient"/> für den Zugriff auf MongoDB.</param>
        /// <remarks>
        /// Der Konstruktor erwartet eine Instanz von <see cref="IMongoClient"/>, die verwendet wird,
        /// um eine Verbindung zur Datenbank herzustellen. Der Name der Datenbank wird aus den
        /// Anwendungseinstellungen geladen. Stellt sicher, dass die <see cref="ConfigurationManager.AppSettings"/>
        /// den Schlüssel 'DatabaseName' mit dem Namen der zu verwendenden Datenbank enthält.
        /// </remarks>
        public FilmproduzentRepository(IMongoClient client)
        {
            // Hier könnte man auch ConfigurationManager verwenden, aber für Testzwecke
            // ist es besser, wenn diese Informationen von außen kommen.
            var database = client.GetDatabase(ConfigurationManager.AppSettings["DatabaseName"]);
            _filmproduzenten = database.GetCollection<Filmproduzent>("filmproduzenten");
        }

        /// <summary>
        /// Holt alle Filmproduzenten aus der Datenbank.
        /// </summary>
        /// <returns>Eine Liste von <see cref="Filmproduzent"/> Objekten.</returns>
        public IEnumerable<Filmproduzent> GetAllFilmproduzenten()
        {
            return _filmproduzenten.Find(_ => true).ToList();
        }

        /// <summary>
        /// Holt einen spezifischen Filmproduzenten anhand seiner ID.
        /// </summary>
        /// <param name="id">Die ID des gesuchten Filmproduzenten.</param>
        /// <returns>Ein <see cref="Filmproduzent"/> Objekt oder null, falls keiner gefunden wurde.</returns>
        public Filmproduzent GetFilmproduzentById(ObjectId id)
        {
            return _filmproduzenten.Find(fp => fp.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Fügt einen neuen Filmproduzenten zur Datenbank hinzu.
        /// </summary>
        /// <param name="filmproduzent">Das <see cref="Filmproduzent"/> Objekt, das hinzugefügt werden soll.</param>
        public void InsertFilmproduzent(Filmproduzent filmproduzent)
        {
            _filmproduzenten.InsertOne(filmproduzent);
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Filmproduzenten in der Datenbank.
        /// </summary>
        /// <param name="filmproduzent">Das aktualisierte <see cref="Filmproduzent"/> Objekt.</param>
        public void UpdateFilmproduzent(Filmproduzent filmproduzent)
        {
            _filmproduzenten.ReplaceOne(fp => fp.Id == filmproduzent.Id, filmproduzent);
        }

        /// <summary>
        /// Löscht einen Filmproduzenten aus der Datenbank anhand seiner ID.
        /// </summary>
        /// <param name="id">Die ID des zu löschenden Filmproduzenten.</param>
        public void DeleteFilmproduzent(ObjectId id)
        {
            _filmproduzenten.DeleteOne(fp => fp.Id == id);
        }
    }
}
