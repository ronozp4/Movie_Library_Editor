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
    /// Interaction logic for AddOscar.xaml
    /// </summary>
    public partial class AddOscar : Window
    {
        public Oscar Oscar { get; set; } = null;
        public Actor Actor { get; set; } = null;
        public Actress Actress { get; set; } = null;
        public Director Director { get; set; } = null;
        public Movy Movie { get; set; } = null; //the DB give him the name movy...

        public AddOscar()

        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isFilled() == true)
            {
                using (MoviesDBEntities ctx = new MoviesDBEntities())
                {

                    try
                    {
                        var theActor = (from m in ctx.Actors where m.FirstName == tbActorFN.Text.Trim() && m.LastName == tbActorLN.Text.Trim() select m).First();
                        Actor = theActor;
                    }
                    catch (Exception)
                    {
                        AddActor window = new AddActor();
                        window.tbFN.Text = tbActorFN.Text;
                        window.tbLN.Text = tbActorLN.Text;
                        window.tbFN.IsEnabled = false;
                        window.tbLN.IsEnabled = false;
                        window.ShowDialog();
                        if (window.actor != null)
                        {
                            ctx.Actors.Add(window.actor);
                            ctx.SaveChanges();
                        }
                        var aActor = (from m in ctx.Actors where m.FirstName == window.tbFN.Text.Trim() select m).First();
                        Actor = aActor;
                    }

                    try
                    {
                        var theActress = (from m in ctx.Actresses where m.FirstName == tbActressFN.Text.Trim() && m.LastName == tbActressLN.Text.Trim() select m).First();
                        Actress = theActress;
                    }
                    catch (Exception)
                    {
                        AddActress window = new AddActress();
                        window.tbFN.Text = tbActressFN.Text;
                        window.tbLN.Text = tbActressLN.Text;
                        window.tbFN.IsEnabled = false;
                        window.tbLN.IsEnabled = false;
                        window.ShowDialog();
                        if (window.actress != null)
                        {
                            ctx.Actresses.Add(window.actress);
                            ctx.SaveChanges();
                        }
                        var aActress = (from m in ctx.Actresses where m.FirstName == window.tbFN.Text.Trim() select m).First();
                        Actress = aActress;
                    }
                    try
                    {
                        var theDirector = (from m in ctx.Directors where m.FirstName == tbDirectorFN.Text.Trim() && m.FirstName == tbDirectorFN.Text.Trim() select m).First();
                        Director = theDirector;
                    }
                    catch (Exception)
                    {
                        AddDirector window = new AddDirector();
                        window.tbFN.Text = tbDirectorFN.Text;
                        window.tbLN.Text = tbDirectorLN.Text;
                        window.tbFN.IsEnabled = false;
                        window.tbLN.IsEnabled = false;
                        window.ShowDialog();
                        if (window.director != null)
                        {
                            ctx.Directors.Add(window.director);
                            ctx.SaveChanges();
                        }
                        var aDirector = (from m in ctx.Directors where m.FirstName == window.tbFN.Text.Trim() select m).First();
                        Director = aDirector;
                    }
                    try
                    {
                        var theMovie = (from m in ctx.Movies where m.Title == tbMovie.Text.Trim() select m).First();
                        Movie = theMovie;
                    }
                    catch (Exception)
                    {
                        AddMovie window = new AddMovie();
                        window.tbTitle.Text = tbMovie.Text;
                        window.tbTitle.IsEnabled = false;
                        window.ShowDialog();
                        if (window.movie != null)
                        {
                            ctx.Movies.Add(window.movie);
                            try
                            {
                                ctx.SaveChanges();
                             }
                            catch (Exception)
                            {
                                MessageBox.Show("cannot save the changes. Try again");
                             }
                            }
                        var aMovie = (from m in ctx.Movies where m.Title == window.tbTitle.Text.Trim() select m).First();
                        Movie = aMovie;
                    }

                    try
                    {
                        Oscar = new Oscar
                        {
                            ActressId_Id = Actress.Id,
                            ActorId_Id = Actor.Id,
                            DirectorId_Id = Director.Id,
                            MovieId_MovieSerial = Movie.MovieSerial,
                            Year = Convert.ToInt32(tbYear.Text.Trim())
                        };
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid Input.");
                        this.Close();
                    }
                    ctx.SaveChanges();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Fill all....");
        }







        private bool isFilled() // is all filled?
        {
            if (string.IsNullOrEmpty(tbActressFN.Text) || string.IsNullOrEmpty(tbActressLN.Text) || string.IsNullOrEmpty(tbActorFN.Text) || string.IsNullOrEmpty(tbActorLN.Text)
             || string.IsNullOrEmpty(tbDirectorFN.Text) || string.IsNullOrEmpty(tbDirectorLN.Text) || string.IsNullOrEmpty(tbMovie.Text) || string.IsNullOrEmpty(tbYear.Text))
                return false;

            return true;
        }
    }
}
