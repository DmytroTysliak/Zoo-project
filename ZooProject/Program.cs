using System;
using System.Xml.Linq;

namespace Zoo
{
    class Project
    {
        public static void Main()
        {
            ZooManager manager = new ZooManager();
            manager.Work();
        }
    }

    interface IAnimal
    {
        string Name { get; }
        int Energy { get; }
        bool CanFeed();
    }
  


    abstract class Animal : IAnimal 
    {
        private string _name;
        public int Energy { get; private set; }
        public Animal(string name)
        {
            _name = name;
            Energy = 100;
        }

        public string Name
        {
            get { return _name; }
        }

        public virtual bool CanFeed()
        {
            if (Energy >= 20)
            {
                Energy -= 20;
                return true; 
            }
            else
            {
                return false; 
            }
        }
    }

    class ZooManager
    {
        private List<IAnimal> _animals = new List<IAnimal>();
        private int _userChoice;

        public void Work()
        {
            while (_userChoice != 4)
            {
                Console.WriteLine("Welcome to the super zoo!");
                Console.WriteLine("1. Add a new lion.\n2. Feed the lion.\n3. See the list of animals.\n4. End the program.");

                switch (_userChoice = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        SetName();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        FeedLion();
                        Console.Clear();
                        break;
                    case 3:
                        SeeAllAnimals();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("The zoo is closing!");
                        break;
                    default:
                        Console.WriteLine("Wrong option!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
            }
        }

        public void SetName()
        {
            Console.Write("Write down a name of new lion: ");
            string name = Console.ReadLine();
            _animals.Add(new Lion(name));
            Console.WriteLine($"Animal \"{name}\" add!\n");
        }

        public void SeeAllAnimals()
        {
            Console.WriteLine("\nThe list of animals:");
            if (_animals.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                for (int i = 0; i < _animals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_animals[i].Name} (Energy: {_animals[i].Energy})");
                }
            }
            Console.WriteLine();
        }

        public void FeedLion()
        {
            SeeAllAnimals();
            if (_animals.Count == 0)
            {
                Console.WriteLine("The zoo is empty.");
                return;
            }
            Console.Write("Choose the animal you want to feed: ");
            bool success = int.TryParse(Console.ReadLine(), out int choice);
            int index = choice - 1;

            if (!success || index < 0 || index >= _animals.Count)
            {
                Console.WriteLine("Incorrect number of lion!");
                return;
            }

            IAnimal selectedAnimal = _animals[index];
            if (selectedAnimal.CanFeed())
            {
                Console.WriteLine("The lion said : Ppppppppppp");
                Console.WriteLine($"{selectedAnimal.Name} has been fed. Energy is now {selectedAnimal.Energy}.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{selectedAnimal.Name} doesn't have enough energy to be fed.");
                Console.ReadKey();
            }

        }

       
    }

    class Lion : Animal
    {
        public Lion(string name) : base(name) { }

        public override bool CanFeed()
        {
            if (base.CanFeed())
            {
                Console.WriteLine("The lion said : Ppppppppppp");
                return true;
            }
            return false;
        }
    }
}