using static Assignment2._1.DashboardPage;

namespace Assignment2._1
{
    public partial class AddAnimalPage : ContentPage
    {
        public AddAnimalPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            Animal newAnimal = new Animal
            {
                Name = NameEntry.Text,
                Type = (AnimalType)AnimalTypePicker.SelectedIndex,
                Age = int.Parse(AgeEntry.Text),
                Gender = GenderEntry.Text,
                Description = DescriptionEntry.Text
            };

            Inventory.Instance.AddAnimal(newAnimal);

            await DisplayAlert("Success", "Animal added successfully.", "OK");
            await Navigation.PopAsync();
        }
    }
}
