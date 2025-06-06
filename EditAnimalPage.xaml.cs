using System;
using Microsoft.Maui.Controls;
using Assignment2._1.Models;
using Assignment2._1.Services;

namespace Assignment2._1
{
    [QueryProperty(nameof(AnimalId), "animalId")]
    public partial class EditAnimalPage : ContentPage
    {
        // Backing field for the animal ID
        private int _animalId;

        // This property is set by Shell when navigating with a query parameter
        public string AnimalId
        {
            get => _animalId.ToString();
            set
            {
                if (int.TryParse(value, out var id))
                {
                    _animalId = id;
                    LoadAnimal(id);
                }
            }
        }

        public EditAnimalPage()
        {
            InitializeComponent();
        }

      
        private void LoadAnimal(int id)
        {
            var animal = Inventory.Instance.GetAnimalById(id);
            if (animal == null)
                return;

            // Populate each input control with the existing values
            NameEntry.Text = animal.Name;
            AnimalTypeEntry.Text = animal.Type;
            AgeEntry.Text = animal.Age.ToString();

            // Set the Picker selection (Male=0, Female=1)
            if (animal.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                GenderPicker.SelectedIndex = 0;
            else if (animal.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                GenderPicker.SelectedIndex = 1;
            else
                GenderPicker.SelectedIndex = -1;

            DescriptionEditor.Text = animal.Description;
        }

       
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Disable button immediately to prevent multiple taps
            if (sender is Button saveBtn)
                saveBtn.IsEnabled = false;

            // 1. Validate Name
            string name = NameEntry.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Missing Name", "Please enter the animal’s name.", "OK");
                if (sender is Button btn1) btn1.IsEnabled = true;
                return;
            }

            // 2. Validate Type
            string type = AnimalTypeEntry.Text?.Trim();
            if (string.IsNullOrWhiteSpace(type))
            {
                await DisplayAlert("Missing Type", "Please enter the animal’s type (e.g. Dog, Cat).", "OK");
                if (sender is Button btn2) btn2.IsEnabled = true;
                return;
            }

            // 3. Validate Age
            if (!int.TryParse(AgeEntry.Text?.Trim(), out int age) || age < 0)
            {
                await DisplayAlert("Invalid Age", "Please enter a valid age (non‐negative whole number).", "OK");
                if (sender is Button btn3) btn3.IsEnabled = true;
                return;
            }

            // 4. Validate Gender
            if (GenderPicker.SelectedIndex < 0)
            {
                await DisplayAlert("Missing Gender", "Please select a gender (Male or Female).", "OK");
                if (sender is Button btn4) btn4.IsEnabled = true;
                return;
            }
            string gender = GenderPicker.Items[GenderPicker.SelectedIndex];

            // 5. Description (optional)
            string description = DescriptionEditor.Text?.Trim() ?? string.Empty;

            // 6. Create an updated Animal object (preserving the same Id)
            var updatedAnimal = new Animal
            {
                Id = _animalId,
                Name = name,
                Type = type,
                Age = age,
                Gender = gender,
                Description = description,
                 
            };

            // 7. Update the inventory
            Inventory.Instance.UpdateAnimal(updatedAnimal);

            // 8. Show success alert
            await DisplayAlert("Success", "Animal updated successfully.", "OK");

            // 9. Navigate back to the Dashboard tab (absolute route)
            await Shell.Current.GoToAsync("//DashboardPage");
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            // Confirm deletion
            bool answer = await DisplayAlert(
                "Delete Animal",
                "Are you sure you want to delete this animal?",
                "Yes",
                "No");

            if (!answer)
                return;

            // Remove from inventory
            Inventory.Instance.DeleteAnimal(_animalId);

            // Show deletion confirmation
            await DisplayAlert("Deleted", "Animal has been deleted.", "OK");

            // Navigate back to the Dashboard tab
            await Shell.Current.GoToAsync("//DashboardPage");
        }
    }
}
