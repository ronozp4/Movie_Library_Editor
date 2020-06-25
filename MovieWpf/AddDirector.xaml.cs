﻿using System;
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
    /// Interaction logic for AddDirector.xaml
    /// </summary>
    public partial class AddDirector : Window
    {
        public Director director;
        public AddDirector()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isFilled() == true)
            {
                try
                {
                    director = new Director
                    {
                        FirstName = tbFN.Text.Trim(),
                        LastName = tbLN.Text.Trim(),
                        Id = Convert.ToInt32(tbID.Text.Trim())
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
                MessageBox.Show("You must enter a director's name");
        }

        private bool isFilled() // is all text boxes filled?
        {
            if (string.IsNullOrEmpty(tbFN.Text) || string.IsNullOrEmpty(tbLN.Text) || string.IsNullOrEmpty(tbID.Text))
                return false;

            return true;
        }
    }
}
