using Microsoft.Maui.Controls;
using Common.BO;
using Repository;
using System.Collections.Generic;
using _002_Repository;
using System.Runtime.Serialization;
using MongoDB.Bson;
using Windows.Storage;


namespace Frontend
{
    public partial class MainPage : ContentPage
    {
        
        
        FilmRepository filmRepository = new FilmRepository();
        FilmproduzentRepository filmproduzentRepository = new FilmproduzentRepository();
        IEnumerable<Film> filme;
        IEnumerable<Filmproduzent> filmproduzenten;

        public MainPage()
        {
            InitializeComponent();
            LoadAllFilme(); // Standart werden die Filme geladen
        }
        private void OnFilmsClicked(object sender, EventArgs e)
        {
            LoadAllFilme();
        }

        private void OnFilmProducersClicked(object sender, EventArgs e)
        {
            LoadAllFilmproduztenten();
        }
        private void LoadAllFilme()
        {
            filme = filmRepository.FindAll();
            UpdateFilmListe();
        }
        private void LoadAllFilmproduztenten()
        {
            filmproduzenten = filmproduzentRepository.GetAllFilmproduzenten();
            UpdateFilmproduzentenListe();
        }

        private void UpdateFilmListe()
        {
            FilmListView.ItemsSource = filme;
            FilmproduzentListView.IsVisible = false;
            FilmListView.IsVisible = true;
        }

        private void UpdateFilmproduzentenListe()
        {
            FilmproduzentListView.ItemsSource = filmproduzenten;
            Filme.IsVisible = false;
            Filmproduzenten.IsVisible = true;
        }
        private void LoadFilmById(ObjectId filmId)
        {
            Film film = filmRepository.FindById(filmId);

            filme = null;
            filme.Append(film);
            UpdateFilmListe();
        }
        private void InsertFilm(System.Object sender, System.EventArgs e)
        {
            Film film = new Film();
            film.Name = FilmName.Text;
            if (int.TryParse(FilmAnzahlMinuten.Text, out int resultMinuten))
            {
                film.AnzahlMinuten = resultMinuten;
            }
            
            film.Kategorie = FilmKategorie.Text;
            film.Hauptdarsteller = FilmHauptdarsteller.Text;
            if(int.TryParse(FilmAnzahlSchauspieler.Text, out int resultSchauspieler))
            {
                film.AnzahlSchauspieler = resultSchauspieler;
            }
            if(ObjectId.TryParse(FilmFilmProduzentId.Text, out ObjectId resultFilmproduzentId))
            {
                film.FilmproduzentId = resultFilmproduzentId;
            }

            filmRepository.InsertOne(film);
        }
        private void InsertFilmproduzent(System.Object sender, System.EventArgs e)
        {
            Filmproduzent filmproduzent = new Filmproduzent();
            filmproduzent.Name = FilmproduzentName.Text;
            filmproduzent.Hauptsitz = FilmproduzentHauptsitz.Text;
            if (int.TryParse(FilmproduzentAnzahlMitarbeiter.Text, out int resultMitarbeiter))
            {
                filmproduzent.AnzahlMitarbeiter = resultMitarbeiter;
            }
            if (int.TryParse(FilmproduzentGruendungsjahr.Text, out int resultGruendungsjahr))
            {
                filmproduzent.Gruendungsjahr= resultGruendungsjahr;
            }

            filmproduzentRepository.InsertFilmproduzent(filmproduzent);
        }
        private void UpdateFilm(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            Film film = filmRepository.FindById(filmId);
            filmRepository.UpdateOne(film);
            LoadAllFilme();
        }
        private void DeleteFilmById(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            filmRepository.DeleteOne(filmId);
            LoadAllFilme();
        }
        private void LoadFilmproduzentById(ObjectId filmproduzentId)
        {
            Filmproduzent filmProduzent = filmproduzentRepository.GetFilmproduzentById(filmproduzentId);

            filmproduzenten = null;
            filmproduzenten.Append(filmProduzent);
            UpdateFilmListe();
        }
        private void UpdateFilmProduzent(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmproduzentId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            Filmproduzent filmproduzent = filmproduzentRepository.GetFilmproduzentById(filmproduzentId);
            filmproduzentRepository.UpdateFilmproduzent(filmproduzent);
            LoadAllFilmproduztenten();
        }
        private void DeleteFilmProduzentById(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmproduzentId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            filmproduzentRepository.DeleteFilmproduzent(filmproduzentId);
            LoadAllFilmproduztenten();
        }
    }
}
