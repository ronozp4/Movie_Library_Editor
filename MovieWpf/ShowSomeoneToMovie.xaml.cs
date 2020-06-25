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
    /// Interaction logic for ShowSomeoneToMovie.xaml
    /// </summary>
    public partial class ShowSomeoneToMovie : Window
    {


        public string MovieName { get; set; } = null;



        public ShowSomeoneToMovie(string Mn)
        {
            InitializeComponent();
            MovieName = Mn;

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                Func<string, IQueryable<Actor>> actorByMovie =
                    movieName => from a in ctx.Actors
                                 from m in a.Movies
                                 where m.Title == movieName
                                 select a;

                Movie_dg.ItemsSource = actorByMovie(MovieName).ToList();
            }
        }
    }
}
