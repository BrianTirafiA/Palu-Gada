﻿using PaluGada.model;
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

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for ConfirmationLO.xaml
    /// </summary>
    public partial class ConfirmationLO : Window
    {
        public ConfirmationLO()
        {
            InitializeComponent();
        }

        private void yesbtn(object sender, RoutedEventArgs e)
        {
            Session.ResetSession();

            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name != "Confirm")
                {
                    w.Close();
                }
            }
            MainWindow login = new MainWindow();
            Application.Current.MainWindow = login;
            login.Show();
            this.Close();

        }


        private void nobtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}