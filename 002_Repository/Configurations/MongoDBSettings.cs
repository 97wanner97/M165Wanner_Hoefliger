namespace Repository.Configurations
{
    /// <summary>
    /// Beinhaltet die Konfigurationseinstellungen für den Zugriff auf MongoDB.
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// Die Verbindungszeichenfolge für die MongoDB-Datenbank.
        /// </summary>
        /// <remarks>
        /// Diese Zeichenfolge sollte alle notwendigen Informationen enthalten, 
        /// um eine Verbindung zur Datenbank herzustellen, einschließlich 
        /// Hostnamen, Ports und Authentifizierungsdetails.
        /// </remarks>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Der Name der Datenbank innerhalb von MongoDB, auf die zugegriffen wird.
        /// </summary>
        public string DatabaseName { get; set; }
    }
}
