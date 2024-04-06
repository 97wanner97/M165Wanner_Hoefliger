using Microsoft.Maui.Controls;
using Common.BO;
using _002_Repository;
using System.Collections.Generic;
using MongoDB.Bson;
using System;

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
            FilmListView.IsVisible = false;
            FilmproduzentListView.IsVisible = true;
        }

        /// <summary>
        /// Lädt alle Filme und aktualisiert die Liste.
        /// </summary>
        private void LoadAllFilme()
        {
            filme = filmRepository.FindAll();
            UpdateFilmListe();
        }

        /// <summary>
        /// Lädt einen Film anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmId">Die ObjectId des Films.</param>
        private void LoadFilmById(ObjectId filmId)
        {
            Film film = filmRepository.FindById(filmId);
            filme = new List<Film> { film };
            UpdateFilmListe();
        }

        /// <summary>
        /// Fügt einen neuen Film hinzu und aktualisiert die Liste.
        /// </summary>
        /// <param name="film">Das Film-Objekt, das hinzugefügt werden soll.</param>
        private void AddFilm(Film film)
        {
            filmRepository.InsertOne(film);
            LoadAllFilme();
        }

        /// <summary>
        /// Aktualisiert einen Film und die Liste.
        /// </summary>
        /// <param name="film">Das Film-Objekt, das aktualisiert werden soll.</param>
        private void UpdateFilm(Film film)
        {
            filmRepository.UpdateOne(film);
            LoadAllFilme();
        }

        /// <summary>
        /// Löscht einen Film anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmId">Die ObjectId des Films.</param>
        private void DeleteFilmById(ObjectId filmId)
        {
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
        /// Fügt einen neuen Filmproduzenten hinzu und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmproduzent">Das Filmproduzent-Objekt, das hinzugefügt werden soll.</param>
        private void AddFilmproduzent(Filmproduzent filmproduzent)
        {
            filmproduzentRepository.InsertFilmproduzent(filmproduzent);
            LoadAllFilmproduzenten();
        }

        /// <summary>
        /// Aktualisiert einen Filmproduzenten und die Liste.
        /// </summary>
        /// <param name="filmproduzent">Das Filmproduzent-Objekt, das aktualisiert werden soll.</param>
        private void UpdateFilmproduzent(Filmproduzent filmproduzent)
        {
            filmproduzentRepository.UpdateFilmproduzent(filmproduzent);
            LoadAllFilmproduzenten();
        }

        /// <summary>
        /// Löscht einen Filmproduzenten anhand seiner ID und aktualisiert die Liste.
        /// </summary>
        /// <param name="filmProduzentId">Die ObjectId des Filmproduzenten.</param>
        private void DeleteFilmproduzentById(ObjectId filmProduzentId)
        {
            filmproduzentRepository.DeleteFilmproduzent(filmProduzentId);
            LoadAllFilmproduzenten();
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
            LoadAllFilmproduzenten();
        }
    }
}
