using MongoDB.Driver;
using Common.BO;
using System.Collections.Generic;
using System.IO;
using System;
using MongoDB.Bson;

namespace _002_Repository
{
    public class FilmRepository
    {
        private readonly IMongoCollection<Film> _films;

        public FilmRepository(IMongoDatabase database)
        {
            _films = database.GetCollection<Film>("filme");
        }

        public IEnumerable<Film> FindAll()
        {
            return _films.Find(_ => true).ToList();
        }

        public Film FindById(ObjectId id)
        {
            return _films.Find(f => f.Id == id).FirstOrDefault();
        }

        public void InsertOne(Film film)
        {
            _films.InsertOne(film);
        }

        // Weitere Methoden wie UpdateOne, DeleteOne usw. können hier implementiert werden
    }
}
