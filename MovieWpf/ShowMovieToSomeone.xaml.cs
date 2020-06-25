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
    /// Interaction logic for ShowMovieToSomeone.xaml
    /// </summary>
    public partial class ShowMovieToSomeone : Window
    {


        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;



        public ShowMovieToSomeone(string Fn, string Ln)
        {
            InitializeComponent();

            FirstName = Fn;
            LastName = Ln;

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                var actor = (from m in ctx.Actors
                             where FirstName == m.FirstName && LastName == m.LastName
                             select m).First();
                Movie_dg.ItemsSource = actor.Movies.ToList();
            }
        }
    }


}
