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
    /// Interaction logic for ShowMovieToSomeone1.xaml
    /// </summary>
    public partial class ShowMovieToSomeone1 : Window
    {
        public ShowMovieToSomeone1()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                if ((bool)rbActor.IsChecked)
                {
                    try
                    {
                        var actor = (from m in ctx.Actors
                                     where m.FirstName == tbFirstName.Text && m.LastName == tbLastName.Text
                                     select m).First();
                        ShowMovieToSomeone window = new ShowMovieToSomeone(tbFirstName.Text, tbLastName.Text);
                        window.ShowDialog();
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
                                       where m.FirstName == tbFirstName.Text && m.LastName == tbLastName.Text
                                       select m).First();
                        ShowMovieToSomeone window = new ShowMovieToSomeone(tbFirstName.Text, tbLastName.Text);
                        window.ShowDialog();
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
                                        where m.FirstName == tbFirstName.Text && m.LastName == tbLastName.Text
                                        select m).First();
                        ShowMovieToSomeone window = new ShowMovieToSomeone(tbFirstName.Text, tbLastName.Text);
                        window.ShowDialog();
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
