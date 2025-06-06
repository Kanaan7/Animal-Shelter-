
using System.Collections.ObjectModel;
using Assignment2._1.Models;

namespace Assignment2._1.Services
{
    public class Inventory
    {
        private static Inventory instance;
        public static Inventory Instance => instance ??= new Inventory();

        // This collection is bound to  Dashboard’s CollectionView
        public ObservableCollection<Animal> Animals { get; }

        // Internal counter for assigning unique IDs
        private int nextId = 1;

        private Inventory()
        {
            Animals = new ObservableCollection<Animal>();

            // Seed with sample data:
            Animals.Add(new Animal
            {
                Id = nextId++,
                Name = "Fluffy",
                Type = "Cat",
                Age = 3,
                Gender = "Male",
                Description = "A cute fluffy cat.",
                IsAdopted = false
            });
            Animals.Add(new Animal
            {
                Id = nextId++,
                Name = "Buddy",
                Type = "Dog",
                Age = 5,
                Gender = "Male",
                Description = "A friendly dog.",
                IsAdopted = false
            });
        }

        public void AddAnimal(Animal animal)
        {
            animal.Id = nextId++;
            Animals.Add(animal);
        }

        public Animal GetAnimalById(int id)
        {
            foreach (var a in Animals)
                if (a.Id == id)
                    return a;
            return null;
        }

        public void UpdateAnimal(Animal updated)
        {
            var existing = GetAnimalById(updated.Id);
            if (existing == null) return;

            existing.Name = updated.Name;
            existing.Type = updated.Type;
            existing.Age = updated.Age;
            existing.Gender = updated.Gender;
            existing.Description = updated.Description;
            existing.IsAdopted = updated.IsAdopted;
            // Because Animal implements INotifyPropertyChanged, the UI will update.
        }

        public void DeleteAnimal(int id)
        {
            var existing = GetAnimalById(id);
            if (existing != null) Animals.Remove(existing);
        }
    }
}
