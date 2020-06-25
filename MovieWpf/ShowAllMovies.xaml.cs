using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieWpf
{
    /// <summary>
    /// Interaction logic for ShowAllMovies.xaml
    /// </summary>
    public partial class ShowAllMovies : Window
    {
        public ShowAllMovies()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                var movies = from m in ctx.Movies
                             select new { m.MovieSerial, m.Title, m.Year, m.Country, m.ImdbScore };
                Movie_dg.ItemsSource = movies.ToList();
            }
        }
    }
}
