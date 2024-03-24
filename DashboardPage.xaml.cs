using System;
using System.Collections.ObjectModel;

namespace Assignment2._1
{
    public partial class DashboardPage : ContentPage
    {
        // Define the Animal class 
        public class Animal
        {
            public string Name { get; set; }
            public AnimalType Type { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Description { get; set; }
            public bool IsAdopted { get; set; }
        }

        public enum AnimalType
        {
            Cat,
            Dog,
            Rabbit,
            // Add more 
        }

        // Define the Inventory class
        public class Inventory
        {
            private static Inventory instance;
            public static Inventory Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Inventory();
                    }
                    return instance;
                }
            }

            public ObservableCollection<Animal> Animals { get; private set; }

            private Inventory()
            {
                Animals = new ObservableCollection<Animal>();
                // Add some initial animals for testing
                Animals.Add(new Animal { Name = "Fluffy", Type = AnimalType.Cat, Age = 3, Gender = "Male", Description = "A cute fluffy cat", IsAdopted = false });
                Animals.Add(new Animal { Name = "Buddy", Type = AnimalType.Dog, Age = 5, Gender = "Male", Description = "A friendly dog", IsAdopted = false });
            }

            public void AddAnimal(Animal animal)
            {
                Animals.Add(animal);
            }
        }

        public ObservableCollection<Animal> Animals { get; set; }

        public DashboardPage()
        {
            InitializeComponent();
            Animals = Inventory.Instance.Animals; // Set the Animals collection directly
            BindingContext = this; // Set the binding context
        }

        private async void OnAddAnimalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAnimalPage());
        }

        private async void OnAnimalSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                Animal selectedAnimal = (Animal)e.CurrentSelection[0];
                await Navigation.PushAsync(new EditAnimalPage(selectedAnimal));
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            // Retrieve the selected animal from the command parameter
            var selectedAnimal = (Animal)((Button)sender).CommandParameter;

            // Navigate to the EditAnimalPage, passing the selected animal
            await Navigation.PushAsync(new EditAnimalPage(selectedAnimal));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Update the Animals collection with the latest data
            OnPropertyChanged(nameof(Animals));
        }
    }
}
