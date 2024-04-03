using MongoDB.Driver;
using Common.BO;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Configuration;

namespace _002_Repository
{
    /// <summary>
    /// Verwaltet die Datenzugriffsoperationen für Filme.
    /// </summary>
    public class FilmRepository
    {
        private readonly IMongoCollection<Film> _films;

        /// <summary>
        /// Initialisiert eine neue Instanz der FilmRepository Klasse.
        /// </summary>
        public FilmRepository()
        {
            var settings = ConfigurationManager.ConnectionStrings["MongoDB"];
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["DatabaseName"]);

            _films = database.GetCollection<Film>("filme");
        }

        /// <summary>
        /// Findet alle Filme in der Datenbank.
        /// </summary>
        /// <returns>Eine Liste von Filmen.</returns>
        public IEnumerable<Film> FindAll()
        {
            return _films.Find(_ => true).ToList();
        }

        /// <summary>
        /// Findet einen Film anhand seiner ID.
        /// </summary>
        /// <param name="id">Die ID des Films.</param>
        /// <returns>Den gefundenen Film oder null, falls kein Film gefunden wurde.</returns>
        public Film FindById(ObjectId id)
        {
            return _films.Find(film => film.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Fügt einen neuen Film in die Datenbank ein.
        /// </summary>
        /// <param name="film">Der einzufügende Film.</param>
        public void InsertOne(Film film)
        {
            _films.InsertOne(film);
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Film.
        /// </summary>
        /// <param name="film">Der zu aktualisierende Film mit neuen Werten.</param>
        public void UpdateOne(Film film)
        {
            _films.ReplaceOne(f => f.Id == film.Id, film);
        }

        /// <summary>
        /// Löscht einen Film anhand seiner ID.
        /// </summary>
        /// <param name="id">Die ID des zu löschenden Films.</param>
        public void DeleteOne(ObjectId id)
        {
            _films.DeleteOne(film => film.Id == id);
        }
    }
}
