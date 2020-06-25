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
    /// Interaction logic for ShowSomeoneToMovie1.xaml
    /// </summary>
    public partial class ShowSomeoneToMovie1 : Window
    {
        public ShowSomeoneToMovie1()
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
                                  where tbName.Text == m.Title
                                  select m).First();

                    ShowSomeoneToMovie window = new ShowSomeoneToMovie(tbName.Text);
                    window.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Movie dosen't exist");
                    this.Close();
                }
            }
        }
    }
}
