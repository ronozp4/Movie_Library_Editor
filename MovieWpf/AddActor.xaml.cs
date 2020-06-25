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
    /// Interaction logic for AddActor.xaml
    /// </summary>
    public partial class AddActor : Window
    {
        public Actor actor { get; set; } = null;


        public AddActor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isFilled() == true)
            {
                try
                {
                    actor = new Actor
                    {
                        FirstName = tbFN.Text.Trim(),
                        LastName = tbLN.Text.Trim(),
                        Id = Convert.ToInt32(tbID.Text.Trim()),
                        YearBorn = Convert.ToInt32(tbYB.Text.Trim())
                    };
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Input.");
                    this.Close();
                }
                this.Close();
            }
            else
                MessageBox.Show("You must enter a fill all");
        }

        private bool isFilled() // is all text boxes filled?
        {
            if (string.IsNullOrEmpty(tbFN.Text) || string.IsNullOrEmpty(tbLN.Text) || string.IsNullOrEmpty(tbID.Text) || string.IsNullOrEmpty(tbYB.Text))
                return false;

            return true;
        }
    }
}
