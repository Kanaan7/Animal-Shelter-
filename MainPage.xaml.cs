using System;
using Microsoft.Maui.Controls;

namespace Assignment2._1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGoToDashboardClicked(object sender, EventArgs e)
        {
            // Navigate to DashboardPage via Shell routing
            await Shell.Current.GoToAsync("DashboardPage");
        }
    }
}
