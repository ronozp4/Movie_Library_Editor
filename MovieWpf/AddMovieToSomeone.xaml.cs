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
    /// Interaction logic for AddMovieToSomeone.xaml
    /// </summary>
    public partial class AddMovieToSomeone : Window
    {
        public Movy Movie { get; set; } = null;

        public AddMovieToSomeone()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                try
                {
                    var movies = (from m in ctx.Movies
                                  where m.Title == tbAM.Text
                                  select m).First();
                    Movie = movies;
                }
                catch (Exception)
                {
                    AddMovie window = new AddMovie();
                    window.ShowDialog();
                    window.tbTitle.Text = tbAM.Text;
                    window.tbTitle.IsEnabled = false;
                    var movies = (from m in ctx.Movies
                                  where m.Title == window.tbTitle.Text
                                  select m).First();
                    Movie = movies;
                }
                if ((bool)rbActor.IsChecked)
                {
                    try
                    {
                        var actor = (from m in ctx.Actors
                                     where m.FirstName == tbFN.Text && m.LastName == tbLN.Text
                                     select m).First();
                        actor.Movies.Add(Movie);
                        Movie.Actors.Add(actor);
                        ctx.SaveChanges();
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Actor dosen't exist.");
                        this.Close();
                    }
                }
                else if ((bool)rbActress.IsChecked)
                {
                    try
                    {
                        var actress = (from m in ctx.Actresses
                                       where m.FirstName == tbFN.Text && m.LastName == tbLN.Text
                                       select m).First();
                        actress.Movies.Add(Movie);
                        Movie.Actresses.Add(actress);
                        ctx.SaveChanges();
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Actress dosen't exist.");
                        this.Close();
                    }
                }
                else if ((bool)rbDirector.IsChecked)
                {
                    try
                    {
                        var director = (from m in ctx.Directors
                                        where m.FirstName == tbFN.Text && m.LastName == tbLN.Text
                                        select m).First();
                        director.Movies.Add(Movie);
                        Movie.Director = director;
                        ctx.SaveChanges();
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Director dosen't exist.");
                        this.Close();
                    }
                }
            }
        }
    }
}
