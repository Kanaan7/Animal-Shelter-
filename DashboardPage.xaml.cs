using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Assignment2._1.Models;
using Assignment2._1.Services;

namespace Assignment2._1
{
    public partial class DashboardPage : ContentPage
    {
        public ObservableCollection<Animal> Animals { get; }
        public Command<int> EditCommand { get; }

        public DashboardPage()
        {
            InitializeComponent();

            Animals = Inventory.Instance.Animals;
            BindingContext = this;

            EditCommand = new Command<int>(OnEditClicked);
        }

        private async void OnAddAnimalClicked(object sender, EventArgs e)
        {
            // Absolute route: jump to the AddAnimalPage tab
            await Shell.Current.GoToAsync("//AddAnimalPage");
        }

        private async void OnEditClicked(int animalId)
        {
            // Navigate to EditAnimalPage with query
            await Shell.Current.GoToAsync($"EditAnimalPage?animalId={animalId}");
        }

        private async void OnAnimalSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Animal selected)
            {
                await Shell.Current.GoToAsync($"EditAnimalPage?animalId={selected.Id}");
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
