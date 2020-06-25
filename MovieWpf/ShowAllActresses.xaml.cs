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
    /// Interaction logic for ShowAllActresses.xaml
    /// </summary>
    public partial class ShowAllActresses : Window
    {
        public ShowAllActresses()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                var actresses = from m in ctx.Actresses
                                select new { m.FirstName, m.LastName, m.Id, m.YearBorn };
                Actresess_dg.ItemsSource = actresses.ToList();
            }
        }
    }
}
