using Microsoft.Maui.Controls;
using Common.BO;
using _002_Repository;
using System.Collections.Generic;
using MongoDB.Bson;
using System;
using Windows.Storage;


namespace Frontend
{
    /// <summary>
    /// Hauptseite der Anwendung, welche die Benutzeroberfläche für das Anzeigen und Verwalten von Filmen und Filmproduzenten bereitstellt.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private FilmRepository filmRepository = new FilmRepository();
        private FilmproduzentRepository filmproduzentRepository = new FilmproduzentRepository();
        private IEnumerable<Film> filme;
        private IEnumerable<Filmproduzent> filmproduzenten;

        /// <summary>
        /// Konstruiert die Hauptseite und initialisiert die notwendigen Komponenten.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            LoadAllFilme();
        }
        /// <summary>
        /// Behandelt das Ereignis, wenn auf die Schaltfläche "Filme" geklickt wird.
        /// </summary>
        /// <param name="sender">Der Sender des Ereignisses.</param>
        /// <param name="e">Die Ereignisdaten.</param>
        private void OnFilmsClicked(object sender, EventArgs e)
        {
            LoadAllFilme();
        }
        /// <summary>
        /// Behandelt das Ereignis, wenn auf die Schaltfläche "Filmproduzenten" geklickt wird.
        /// </summary>
        /// <param name="sender">Der Sender des Ereignisses.</param>
        /// <param name="e">Die Ereignisdaten.</param>
        private void OnFilmProducersClicked(object sender, EventArgs e)
        {
            LoadAllFilmproduztenten();
        }
        /// <summary>
        /// Lädt alle Filme und aktualisiert die Liste.
        /// </summary>
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

        /// <summary>
        /// Aktualisiert die Liste der Filme auf der Benutzeroberfläche.
        /// </summary>

        private void UpdateFilmListe()
        {
            FilmListView.ItemsSource = filme;
            FilmproduzentListView.IsVisible = false;
            FilmListView.IsVisible = true;
        }

        /// <summary>
        /// Aktualisiert die Liste der Filmproduzenten auf der Benutzeroberfläche.
        /// </summary>
        private void UpdateFilmproduzentenListe()
        {
            FilmproduzentListView.ItemsSource = filmproduzenten;
            Filme.IsVisible = false;
            Filmproduzenten.IsVisible = true;

       

        /// <summary>
        /// Lädt einen Film anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmId">Die ObjectId des Films.</param>
        }
        private void LoadFilmById(ObjectId filmId)
        {
            Film film = filmRepository.FindById(filmId);
            filme = new List<Film> { film };
            UpdateFilmListe();
        }

        /// <summary>
        /// Fügt einen neuen Film hinzu und aktualisiert die Liste.
        /// </summary>
        /// <param name="sender">Der Sender des Ereignisses.</param>
        /// <param name="e">Die Ereignisdaten.</param>
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
            if (int.TryParse(FilmAnzahlSchauspieler.Text, out int resultSchauspieler))
            {
                film.AnzahlSchauspieler = resultSchauspieler;
            }
            if (ObjectId.TryParse(FilmFilmProduzentId.Text, out ObjectId resultFilmproduzentId))
            {
                film.FilmproduzentId = resultFilmproduzentId;
            }
        }

        /// <summary>
        /// Fügt einen neuen Filmproduzenten hinzu und aktualisiert die Liste.
        /// </summary>
        /// <param name="sender">Der Sender des Ereignisses.</param>
        /// <param name="e">Die Ereignisdaten.</param>
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

        /// <summary>
        /// Aktualisiert einen Film und die Liste.
        /// </summary>
        /// <param name="film">Das Film-Objekt, das aktualisiert werden soll.</param>
        private void UpdateFilm(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            Film film = filmRepository.FindById(filmId);
            filmRepository.UpdateOne(film);
            LoadAllFilme();
        }

        /// <summary>
        /// Löscht einen Film anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmId">Die ObjectId des Films.</param>
        private void DeleteFilmById(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            filmRepository.DeleteOne(filmId);
            LoadAllFilme();
        }

        /// <summary>
        /// Lädt alle Filmproduzenten und aktualisiert die Liste.
        /// </summary>
        private void LoadAllFilmproduzenten()
        {
            filmproduzenten = filmproduzentRepository.GetAllFilmproduzenten();
            UpdateFilmproduzentenListe();
        }

        /// <summary>
        /// Lädt einen Filmproduzenten anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmproduzentId">Die ObjectId des Filmproduzenten.</param>
        private void LoadFilmproduzentById(ObjectId filmproduzentId)
        {
            Filmproduzent filmproduzent = filmproduzentRepository.GetFilmproduzentById(filmproduzentId);
            filmproduzenten = new List<Filmproduzent> { filmproduzent };
            UpdateFilmproduzentenListe();
        }

        /// <summary>
        /// Aktualisiert einen Filmproduzenten und die Liste.
        /// </summary>
        /// <param name="sender">Der Sender des Ereignisses.</param>
        /// <param name="e">Die Ereignisdaten.</param>
        private void UpdateFilmProduzent(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            ObjectId filmproduzentId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            Filmproduzent filmproduzent = filmproduzentRepository.GetFilmproduzentById(filmproduzentId);
            LoadAllFilmproduztenten();
            LoadAllFilmproduzenten();
        }

        /// <summary>
        /// Löscht einen Filmproduzenten anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="sender">Der Sender des Ereignisses.</param>
        /// <param name="e">Die Ereignisdaten.</param>
        private void DeleteFilmProduzentById(System.Object sender, System.EventArgs e)
        {
        
            Button button = (Button)sender;
            ObjectId filmproduzentId = (MongoDB.Bson.ObjectId)button.CommandParameter;
            filmproduzentRepository.DeleteFilmproduzent(filmproduzentId);
            LoadAllFilmproduztenten(); 
        }
    }
}
