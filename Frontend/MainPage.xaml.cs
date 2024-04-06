using Microsoft.Maui.Controls;
using Common.BO;
using Repository;
using System.Collections.Generic;
using _002_Repository;
using System.Runtime.Serialization;
using MongoDB.Bson;


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

        private void UpdateFilmListe()
        {
            FilmListView.ItemsSource = filme;
            FilmproduzentListView.IsVisible = false;
            FilmListView.IsVisible = true;
        }

        private void UpdateFilmproduzentenListe()
        {
            FilmproduzentListView.ItemsSource = filmproduzenten;
            FilmListView.IsVisible = false;
            FilmproduzentListView.IsVisible = true;
        }

        private void LoadAllFilme()
        {
            filme = filmRepository.FindAll();
            UpdateFilmListe();
        }
        private void LoadFilmById(ObjectId filmId)
        {
            Film film = filmRepository.FindById(filmId);

            filme = null;
            filme.Append(film);
            UpdateFilmListe();
        }

        private void AddFilm(Film film)
        {
            filmRepository.InsertOne(film);
            LoadAllFilme();
        }

        private void UpdateFilm(Film film)
        {
            filmRepository.UpdateOne(film);
            LoadAllFilme();
        }


        private void DeleteFilmById(ObjectId filmId)
        {
            filmRepository.DeleteOne(filmId);
            LoadAllFilme();
        }

        private void LoadAllFilmproduztenten()
        {
            filmproduzenten =  filmproduzentRepository.GetAllFilmproduzenten();
            UpdateFilmproduzentenListe();
        }
        private void LoadFilmproduzentById(ObjectId filmproduzentId)
        {
            Filmproduzent filmProduzent = filmproduzentRepository.GetFilmproduzentById(filmproduzentId);

            filmproduzenten = null;
            filmproduzenten.Append(filmProduzent);
            UpdateFilmListe();
        }

        private void AddFilmproduzent(Filmproduzent filmproduzent)
        {
            filmproduzentRepository.InsertFilmproduzent(filmproduzent);
            LoadAllFilme();
        }

        private void UpdateFilmProduzent(Filmproduzent filmproduzent)
        {
            filmproduzentRepository.UpdateFilmproduzent(filmproduzent);
            LoadAllFilme();
        }


        private void DeleteFilmProduzentById(ObjectId filmProduzentId)
        {
            filmproduzentRepository.DeleteFilmproduzent(filmProduzentId);
            LoadAllFilme();
        }


        private void OnFilmsClicked(object sender, EventArgs e)
        {
            LoadAllFilme(); 
        }

        private void OnFilmProducersClicked(object sender, EventArgs e)
        {
            LoadAllFilmproduztenten(); 
        }
    }
}
