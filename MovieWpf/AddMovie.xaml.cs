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
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Window
    {
        public Movy movie { get; set; } = null; //the DB give him the name movy...

        public AddMovie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbTitle.Text))
            {
                movie = new Movy
                {
                    Title = tbTitle.Text.Trim(),
                    Year = Convert.ToInt32(tbYear.Text.Trim()),
                    Country = tbCountry.Text.Trim(),
                    MovieSerial = Convert.ToInt32(tbSerial.Text.Trim()),
                    ImdbScore = Convert.ToDecimal(tbIMDB.Text.Trim())
                };
                this.Close();
            }
            else
                MessageBox.Show("You must enter a movie's name");
        }
    }
}
