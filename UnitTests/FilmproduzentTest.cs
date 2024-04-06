//using NUnit.Framework;
//using Moq;
//using MongoDB.Driver;
//using Common.BO;
//using MongoDB.Bson;
//using System.Collections.Generic;
//using _002_Repository;
//using System.Linq;
//using System.Threading;

//namespace UnitTests
//{
//    [TestFixture]
//    public class FilmproduzentTest
//    {
//        private Mock<IMongoCollection<Filmproduzent>> _mockCollection;
//        private Mock<IMongoDatabase> _mockDatabase;
//        private Mock<IMongoClient> _mockClient;
//        private FilmproduzentRepository _repository;

//        [SetUp]
//        public void Setup()
//        {
//            // Mock der benötigten Objekte erstellen
//            _mockCollection = new Mock<IMongoCollection<Filmproduzent>>();
//            _mockDatabase = new Mock<IMongoDatabase>();
//            _mockClient = new Mock<IMongoClient>();

//            // Setup des Mock-Verhaltens
//            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null)).Returns(_mockDatabase.Object);
//            _mockDatabase.Setup(db => db.GetCollection<Filmproduzent>(It.IsAny<string>(), null)).Returns(_mockCollection.Object);

//            // Repository mit Mock-Client initialisieren
//            _repository = new FilmproduzentRepository(_mockClient.Object);
//        }

//        [Test]
//        public void InsertFilmproduzentTest()
//        {
//            // Arrange
//            var filmproduzent = new Filmproduzent { Name = "Studio Ghibli", Hauptsitz = "Tokyo", AnzahlMitarbeiter = 150, Gruendungsjahr = 1985 };

//            // Act
//            _repository.InsertFilmproduzent(filmproduzent);

//            // Assert
//            _mockCollection.Verify(m => m.InsertOne(filmproduzent, null, default), Times.Once);
//        }

//        [Test]
//        public void GetAllFilmproduzentenTest()
//        {
//            // Arrange
//            var fakeFilmproduzentenList = new List<Filmproduzent>
//    {
//        new Filmproduzent { Name = "Studio Ghibli" },
//        new Filmproduzent { Name = "Pixar" }
//    };
//            // Mock für IAsyncCursor<Filmproduzent> erstellen, der die fake Liste zurückgibt
//            var mockCursor = new Mock<IAsyncCursor<Filmproduzent>>();
//            mockCursor.Setup(_ => _.Current).Returns(fakeFilmproduzentenList); // Stellt die aktuelle Charge von Dokumenten im Cursor dar
//            mockCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
//                       .Returns(true)  // Gibt an, dass beim ersten Aufruf von MoveNext noch Dokumente verfügbar sind
//                       .Returns(false); // Gibt an, dass keine weiteren Dokumente verfügbar sind

//            // Mock-Setup für die Find-Methode, um den mockCursor zurückzugeben
//            _mockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Filmproduzent>>(),
//                                                    It.IsAny<FindOptions<Filmproduzent, Filmproduzent>>(),
//                                                    It.IsAny<CancellationToken>()))
//                           .Returns(mockCursor.Object);


//            // Act
//            var result = _repository.GetAllFilmproduzenten();

//            // Assert
//            Assert.AreEqual(2, result.Count());
//            _mockCollection.Verify(op => op.Find(It.IsAny<FilterDefinition<Filmproduzent>>(),
//                                     It.IsAny<FindOptions>(), // Verwendet hier FindOptions ohne generische Typen
//                                     It.IsAny<CancellationToken>()),
//                       Times.Once);

//        }

//        [Test]
//        public void GetFilmproduzentByIdTest()
//        {
//            // Arrange
//            var id = ObjectId.GenerateNewId();
//            var fakeFilmproduzent = new Filmproduzent { Id = id, Name = "Studio Ghibli" };
//            _mockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Filmproduzent>>(),
//                                                    It.IsAny<FindOptions<Filmproduzent, Filmproduzent>>(),
//                                                    It.IsAny<CancellationToken>()))
//                           .Returns(new List<Filmproduzent> { fakeFilmproduzent }.AsQueryable().Provider);

//            // Act
//            var result = _repository.GetFilmproduzentById(id);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual("Studio Ghibli", result.Name);
//        }

//        [Test]
//        public void UpdateFilmproduzentTest()
//        {
//            // Arrange
//            var filmproduzent = new Filmproduzent { Id = ObjectId.GenerateNewId(), Name = "Pixar", Hauptsitz = "California" };

//            // Act
//            _repository.UpdateFilmproduzent(filmproduzent);

//            // Assert
//            _mockCollection.Verify(m => m.ReplaceOne(It.IsAny<FilterDefinition<Filmproduzent>>(),
//                                                     filmproduzent,
//                                                     It.IsAny<ReplaceOptions>(),
//                                                     default(CancellationToken)), Times.Once);
//        }

//        [Test]
//        public void DeleteFilmproduzentTest()
//        {
//            // Arrange
//            var id = ObjectId.GenerateNewId();

//            // Act
//            _repository.DeleteFilmproduzent(id);

//            // Assert
//            _mockCollection.Verify(m => m.DeleteOne(It.IsAny<FilterDefinition<Filmproduzent>>(), default(CancellationToken)), Times.Once);
//        }
//    }
//}
