using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.BO
{
    /// <summary>
    /// Repräsentiert einen Filmproduzenten in der Datenbank.
    /// </summary>
    public class Filmproduzent
    {
        /// <summary>
        /// Die eindeutige ID des Filmproduzenten in der Datenbank.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Der Name des Filmproduzenten.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Der Hauptsitz des Filmproduzenten.
        /// </summary>
        public string Hauptsitz { get; set; }

        /// <summary>
        /// Die Anzahl der Mitarbeiter, die beim Filmproduzenten beschäftigt sind.
        /// </summary>
        public int AnzahlMitarbeiter { get; set; }

        /// <summary>
        /// Das Gründungsjahr des Filmproduzenten.
        /// </summary>
        public int Gruendungsjahr { get; set; }
    }
}
