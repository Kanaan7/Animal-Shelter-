using System;
using Microsoft.Maui.Controls;
using Assignment2._1.Models;
using Assignment2._1.Services;

namespace Assignment2._1
{
    public partial class AddAnimalPage : ContentPage
    {
        public AddAnimalPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Disable the Save button so the user can’t double‐tap
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

            // 6. Create & add the new animal
            var newAnimal = new Animal
            {
                Name = name,
                Type = type,
                Age = age,
                Gender = gender,
                Description = description
            };

            Inventory.Instance.AddAnimal(newAnimal);

            // 7. Show the success popup
            await DisplayAlert("Success", "Animal added successfully.", "OK");

            // 8. Switch back to the Dashboard tab
            await Shell.Current.GoToAsync("//DashboardPage");
        }
    }
}
