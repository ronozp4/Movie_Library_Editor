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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add the Novie -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddMovie_Click(object sender, RoutedEventArgs e)
        {
            AddMovie window = new AddMovie();
            window.ShowDialog();
            if (window.movie != null)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        ctx.Movies.Add(window.movie);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This Movie is already exist.");
                    }

                }
            }
        }
        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add the Director -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddDirector_Click(object sender, RoutedEventArgs e)
        {
            AddDirector window = new AddDirector();
            window.ShowDialog();
            if (window.director != null)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        ctx.Directors.Add(window.director);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This Director is already exist.");
                    }

                }
            }
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add the Actor -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddActor_Click(object sender, RoutedEventArgs e)
        {
            AddActor window = new AddActor();
            window.ShowDialog();
            if (window.actor != null)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try { 
                    ctx.Actors.Add(window.actor);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This Actress is already exist.");
                    }
                }
            }
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add the Actress -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddActress_Click(object sender, RoutedEventArgs e)
        {
            AddActress window = new AddActress();
            window.ShowDialog();
            if (window.actress != null)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        ctx.Actresses.Add(window.actress);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This Actress is already exist.");
                    }
                }
            }
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add the Oscar -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddOscar_Click(object sender, RoutedEventArgs e)
        {
            AddOscar window = new AddOscar();
            window.ShowDialog();
            if (window.Oscar != null)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        ctx.Oscars.Add(window.Oscar);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This Oscar is already exist.");
                    }
                }
            }
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add the Golden Globe -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddGoldenGlobe_Click(object sender, RoutedEventArgs e)
        {
            AddGoldenGlobe window = new AddGoldenGlobe();
            window.ShowDialog();
            if (window.GoldenGlobe != null)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        ctx.GoldenGlobes.Add(window.GoldenGlobe);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This Golden Globe is already exist.");
                    }
                }
            }
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add Movie To Someone -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddMovieToSomeone_Click(object sender, RoutedEventArgs e)
        {
            AddMovieToSomeone window = new AddMovieToSomeone();
            window.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ Add Someone To Movie -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void AddSomeoneToMovie_Click(object sender, RoutedEventArgs e)
        {
            AddSomeoneToMovie window = new AddSomeoneToMovie();
            window.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Actresses -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowActresses_Click(object sender, RoutedEventArgs e)
        {
            ShowAllActresses newWindow = new ShowAllActresses();
            newWindow.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Actors -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowActors_Click(object sender, RoutedEventArgs e)
        {
            ShowAllActors newWindow = new ShowAllActors();
            newWindow.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Directors -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowDirectors_Click(object sender, RoutedEventArgs e)
        {
            ShowAllDirectors newWindow = new ShowAllDirectors();
            newWindow.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Movies -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowMovies_Click(object sender, RoutedEventArgs e)
        {
            ShowAllMovies newWindow = new ShowAllMovies();
            newWindow.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Oscars -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowOscars_Click(object sender, RoutedEventArgs e)
        {
            ShowAllOscars newWindow = new ShowAllOscars();
            newWindow.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Golden Globes -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowGoldenGlobes_Click(object sender, RoutedEventArgs e)
        {
            ShowAllGoldenGlobe newWindow = new ShowAllGoldenGlobe();
            newWindow.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show Connection from Movie To Someone -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowMovieToSomeone_Click(object sender, RoutedEventArgs e)
        {
            ShowMovieToSomeone1 window = new ShowMovieToSomeone1();
            window.ShowDialog();
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_  Show the Connection of Someone To Movie -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

        private void ShowSomeoneToMovie_Click(object sender, RoutedEventArgs e)
        {
            ShowSomeoneToMovie1 window = new ShowSomeoneToMovie1();
            window.ShowDialog();
        }

     
    }
}
