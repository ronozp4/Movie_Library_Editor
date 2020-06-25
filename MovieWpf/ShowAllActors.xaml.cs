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
    /// Interaction logic for ShowAllActors.xaml
    /// </summary>
    public partial class ShowAllActors : Window
    {
        public ShowAllActors()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                var actors = from m in ctx.Actors
                             select new { m.FirstName, m.LastName, m.Id, m.YearBorn };
                Actor_dg.ItemsSource = actors.ToList();
            }
        }
    }
}
