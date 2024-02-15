using agl_test.Common.Models;
using agl_test.Common.Tools;

namespace agl_test
{
    public static class AppFunctions
    {
        public static void GetAnimalsAndSort()
        {
            Console.Write("Enter the number of animals: ");

            if (!int.TryParse(Console.ReadLine(), out int numberOfAnimals))
            {
                Console.WriteLine("Invalid number, please start over");
                return;
            }

            var animals = new List<Animal>();

            // for each animal get its type, name and age
            for (int i = 0; i < numberOfAnimals; i++)
            {
                Console.Write($"Enter animal {i + 1}'s type (1 for cat, 2 for dog): ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice, please start over");
                    return;
                }

                Console.Write($"Enter animal {i + 1}'s name: ");
                string name = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid name, please start over");
                    return;
                }

                Console.Write($"Enter animal {i + 1}'s age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age, please start over");
                    return;
                }

                if (choice == 1)
                    animals.Add(new Cat(name, age));
                else if (choice == 2)
                    animals.Add(new Dog(name, age));
                else
                    Console.WriteLine("Invalid choice. Skipping this animal.");
            }

            if (animals.Count == 0)
            {
                Console.WriteLine("No animals to sort, please start over");
                return;
            }

            // prompt user to choose between name or age sort
            Console.Write("Enter 1 for name sort or 2 for age sort: ");
            if (!int.TryParse(Console.ReadLine(), out int sortChoice))
            {
                Console.WriteLine("Invalid sort choice, please start over");
                return;
            }

            var sortedAnimals = new List<Animal>();

            if (sortChoice == 1)
                sortedAnimals = QuickSort.Sort(animals, a => a.Name);
            else if (sortChoice == 2)
                sortedAnimals = QuickSort.Sort(animals, a => a.Age);
            else
            {
                Console.WriteLine("Invalid sort choice, please start over");
                return;
            }

            // display sorted animals
            Console.WriteLine("\nSorted animals:");
            foreach (var animal in sortedAnimals)
            {
                Console.WriteLine($"{animal.Name} (Age: {animal.Age})");
            }
        }
    }
}
