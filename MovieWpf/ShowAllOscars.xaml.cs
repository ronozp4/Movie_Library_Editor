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
    /// Interaction logic for ShowAllOscars.xaml
    /// </summary>
    public partial class ShowAllOscars : Window
    {
        public ShowAllOscars()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (MoviesDBEntities ctx = new MoviesDBEntities())
            {
                var oscars = from m in ctx.Oscars
                             from a in ctx.Actors
                             where a.Id == m.ActorId_Id
                             from ac in ctx.Actresses
                             where ac.Id == m.ActressId_Id
                             from d in ctx.Directors
                             where d.Id == m.DirectorId_Id
                             from mo in ctx.Movies
                             where mo.MovieSerial == m.MovieId_MovieSerial
                             select new { Actor = a.FirstName + " " + a.LastName, Actress = ac.FirstName + " " + ac.LastName, Director = d.FirstName + " " + d.LastName, Movie = mo.Title, m.Year };

                Oscars_dg.ItemsSource = oscars.ToList();
            }
        }
    }
}
