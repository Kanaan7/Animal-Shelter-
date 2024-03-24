using System;
using static Assignment2._1.DashboardPage;

namespace Assignment2._1
{
    public partial class EditAnimalPage : ContentPage
    {
        private Animal _animal;

        public EditAnimalPage(Animal animal)
        {
            InitializeComponent();
            _animal = animal;
            BindingContext = this;
            PopulateFields();
        }

        private void PopulateFields()
        {
            // Check if the controls are not null before populating fields
            if (_animal != null && NameEntry != null && AnimalTypePicker != null && AgeEntry != null && GenderEntry != null && DescriptionEntry != null)
            {
                NameEntry.Text = _animal.Name;
                AnimalTypePicker.SelectedIndex = (int)_animal.Type;
                AgeEntry.Text = _animal.Age.ToString();
                GenderEntry.Text = _animal.Gender;
                DescriptionEntry.Text = _animal.Description;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Update the animal object with the values from the UI controls
            _animal.Name = NameEntry.Text;
            _animal.Type = (AnimalType)AnimalTypePicker.SelectedIndex;
            _animal.Age = int.Parse(AgeEntry.Text);
            _animal.Gender = GenderEntry.Text;
            _animal.Description = DescriptionEntry.Text;

            // Display a success message
            await DisplayAlert("Success", "Animal updated successfully.", "OK");

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}
