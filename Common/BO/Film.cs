using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.BO
{
    /// <summary>
    /// Repräsentiert einen Film in der Datenbank.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Die eindeutige ID des Films in der Datenbank.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Der Name des Films.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Die Laufzeit des Films in Minuten.
        /// </summary>
        public int AnzahlMinuten { get; set; }

        /// <summary>
        /// Die Kategorie, zu der der Film gehört.
        /// </summary>
        public string Kategorie { get; set; }

        /// <summary>
        /// Der Hauptdarsteller des Films.
        /// </summary>
        public string Hauptdarsteller { get; set; }

        /// <summary>
        /// Die Anzahl der Schauspieler im Film.
        /// </summary>
        public int AnzahlSchauspieler { get; set; }

        /// <summary>
        /// Die ID des Filmproduzenten, der den Film produziert hat.
        /// </summary>
        public ObjectId FilmproduzentId { get; set; }
    }
}
