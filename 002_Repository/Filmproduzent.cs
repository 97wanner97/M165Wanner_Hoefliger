using System.Collections.Generic;
using Common.BO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Common.Repository
{
    public class FilmproduzentRepository
    {
        private readonly IMongoCollection<Filmproduzent> _filmproduzenten;

        public FilmproduzentRepository(IMongoDatabase database)
        {
            _filmproduzenten = database.GetCollection<Filmproduzent>("filmproduzenten");
        }

        public List<Filmproduzent> GetAllFilmproduzenten()
        {
            return _filmproduzenten.Find(_ => true).ToList();
        }

        public Filmproduzent GetFilmproduzentById(ObjectId id)
        {
            return _filmproduzenten.Find(fp => fp.Id == id).FirstOrDefault();
        }

        public void InsertFilmproduzent(Filmproduzent filmproduzent)
        {
            _filmproduzenten.InsertOne(filmproduzent);
        }

        public void UpdateFilmproduzent(Filmproduzent filmproduzent)
        {
            _filmproduzenten.ReplaceOne(fp => fp.Id == filmproduzent.Id, filmproduzent);
        }

        public void DeleteFilmproduzent(ObjectId id)
        {
            _filmproduzenten.DeleteOne(fp => fp.Id == id);
        }
    }
}
