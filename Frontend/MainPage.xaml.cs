using Microsoft.Maui.Controls;
using Common.BO;
using System.Collections.Generic;

namespace Frontend
{
    public partial class MainPage : ContentPage
    {
        List<Film> filme;
        List<Filmproduzent> filmproduzenten;

        public MainPage()
        {
            InitializeComponent();
            LoadFilme(); // Standart werden die Filme geladen
        }

        private void LoadFilme()
        {
            
            filme = new List<Film>(); 

            FilmListView.ItemsSource = filme;
            FilmListView.IsVisible = true;

            // Filme werden geladen, Filmproduzenten werden ausgeblendet
            FilmProduzentListView.IsVisible = false;
        }

        private void LoadFilmproduzenten()
        {
            
            filmproduzenten = new List<Filmproduzent>(); 

            FilmProduzentListView.ItemsSource = filmproduzenten;
            FilmProduzentListView.IsVisible = true;

            // Filmproduzenten werden geladen, Filme werden ausgeblendet
            FilmListView.IsVisible = false;
        }

        private void OnFilmsClicked(object sender, EventArgs e)
        {
            LoadFilme(); 
        }

        private void OnFilmProducersClicked(object sender, EventArgs e)
        {
            LoadFilmproduzenten(); 
        }
    }
}
