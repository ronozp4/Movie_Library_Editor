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
    /// Interaction logic for AddSomeoneToMovie.xaml
    /// </summary>
    public partial class AddSomeoneToMovie : Window
    {
        public Actor Actor { get; set; } = null;
        public Actress Actress { get; set; } = null;
        public Director Director { get; set; } = null;
        public Movy Movie { get; set; } = null;

        public AddSomeoneToMovie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbActor.IsChecked)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        var theActor = (from m in ctx.Actors where m.FirstName == tbFN.Text.Trim() && m.LastName == tbLN.Text.Trim() select m).First();
                        Actor = theActor;
                    }
                    catch (Exception)
                    {
                        AddActor window = new AddActor();
                        window.tbFN.Text = tbFN.Text;
                        window.tbLN.Text = tbLN.Text;
                        window.tbFN.IsEnabled = false;
                        window.tbLN.IsEnabled = false;
                        window.ShowDialog();
                        if (window.actor != null)
                        {
                            ctx.Actors.Add(window.actor);
                            ctx.SaveChanges();
                        }
                        var theActor = (from m in ctx.Actors where m.FirstName == window.tbFN.Text.Trim() && m.LastName == window.tbLN.Text.Trim() select m).First();
                        Actor = theActor;
                    }
                    try
                    {
                        var theMovie = (from m in ctx.Movies where m.Title == tbAM.Text.Trim() select m).First();
                        Movie = theMovie;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Your movie doesn't exist");
                        this.Close();
                    }
                    Movie.Actors.Add(Actor);
                    Actor.Movies.Add(Movie);
                    ctx.SaveChanges();
                    this.Close();
                }
            }
            else if ((bool)rbActress.IsChecked)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        var theActress = (from m in ctx.Actresses where m.FirstName == tbFN.Text.Trim() && m.LastName == tbLN.Text.Trim() select m).First();
                        Actress = theActress;
                    }
                    catch (Exception)
                    {
                        AddActress window = new AddActress();
                        window.tbFN.Text = tbFN.Text;
                        window.tbLN.Text = tbLN.Text;
                        window.tbFN.IsEnabled = false;
                        window.tbLN.IsEnabled = false;
                        window.ShowDialog();
                        if (window.actress != null)
                        {
                            ctx.Actresses.Add(window.actress);
                            ctx.SaveChanges();
                        }
                        var theActress = (from m in ctx.Actresses where m.FirstName == window.tbFN.Text.Trim() && m.LastName == window.tbLN.Text.Trim() select m).First();
                        Actress = theActress;
                    }
                    try
                    {
                        var theMovie = (from m in ctx.Movies where m.Title == tbAM.Text.Trim() select m).First();
                        Movie = theMovie;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Your movie doesn't exist");
                        this.Close();
                    }
                    Movie.Actresses.Add(Actress);
                    Actress.Movies.Add(Movie);
                    ctx.SaveChanges();
                    this.Close();
                }
            }
            else if ((bool)rbDirector.IsChecked)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {
                    try
                    {
                        var theDirector = (from m in ctx.Directors where m.FirstName == tbFN.Text.Trim() && m.LastName == tbLN.Text.Trim() select m).First();
                        Director = theDirector;
                    }
                    catch (Exception)
                    {
                        AddDirector window = new AddDirector();
                        window.tbFN.Text = tbFN.Text;
                        window.tbLN.Text = tbLN.Text;
                        window.tbFN.IsEnabled = false;
                        window.tbLN.IsEnabled = false;
                        window.ShowDialog();
                        if (window.director != null)
                        {
                            ctx.Directors.Add(window.director);
                            ctx.SaveChanges();
                        }
                        var theDirector = (from m in ctx.Directors where m.FirstName == window.tbFN.Text.Trim() && m.LastName == window.tbLN.Text.Trim() select m).First();
                        Director = theDirector;
                    }
                    try
                    {
                        var theMovie = (from m in ctx.Movies where m.Title == tbAM.Text.Trim() select m).First();
                        Movie = theMovie;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Your movie doesn't exist");
                        this.Close();
                    }
                    Movie.Director = Director;
                    Director.Movies.Add(Movie);
                    ctx.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
