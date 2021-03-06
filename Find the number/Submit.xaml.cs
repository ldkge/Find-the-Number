﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Find_the_number.ScoreService;

namespace Find_the_number
{
    public partial class Submit : PhoneApplicationPage
    {
        public Submit()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            score.Text = App.score.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScoreServiceClient client = new ScoreServiceClient();
            client.AddScoreCompleted += client_AddScoreCompleted;
            client.AddScoreAsync(name.Text, App.score);          
        }

        private void client_AddScoreCompleted(object sender, AddScoreCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null || !e.Result)
            {
                MessageBox.Show("An error occured while submitting your score. Please try again.");
            }
            else
            {
                MessageBox.Show("Score submitted successfully.");
            }
            App.score = 0;
            NavigationService.Navigate(new Uri("/Leaderboard.xaml", UriKind.Relative));
        }
    }
}