using System;
using System.Collections.Generic;

class NamesAndAges
{
    static void Main(string[] args)
    {
        Dictionary<string, int> people = new Dictionary<string, int>();
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\n--- Dictionary Menu ---");
            Console.WriteLine("1 - Populate the Dictionary (6 entries)");
            Console.WriteLine("2 - Display Dictionary Contents (3 enumeration methods)");
            Console.WriteLine("3 - Remove a Key");
            Console.WriteLine("4 - Add a New Key and Value");
            Console.WriteLine("5 - Add a Value to an Existing Key (replace or add years)");
            Console.WriteLine("6 - Sort the Keys and display");
            Console.WriteLine("0 - Exit");
            Console.Write("Please choose a number (0 - 6): ");

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid choice. Enter a number 0-6.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    people.Clear();
                    Console.WriteLine("Please enter key/value pairs for 6 people.");
                    for (int i = 1; i <= 6; i++)
                    {
                        Console.WriteLine($"\nPerson {i} of 6");

                        Console.Write("Enter a name: ");
                        string? name = Console.ReadLine();

                        Console.Write("Enter an age for the person: ");
                        string? ageInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Name cannot be empty. Try again.");
                            i--;
                            continue;
                        }

                        if (!int.TryParse(ageInput, out int age))
                        {
                            Console.WriteLine("The entered age must be a valid integer. Try again.");
                            i--;
                            continue;
                        }

                        if (people.ContainsKey(name))
                        {
                            Console.WriteLine($"'{name}' already exists. Overwriting existing age.");
                            people[name] = age;
                        }
                        else
                        {
                            people.Add(name, age);
                        }

                        Console.WriteLine($"Added: {name}, {age}");
                    }

                    Console.WriteLine("Dictionary populated with 6 people.");
                    break;

                case 2:
                    Console.WriteLine("\n--- Displaying dictionary (method 1: KeyValuePair foreach) ---");
                    foreach (KeyValuePair<string, int> person in people)
                    {
                        Console.WriteLine($"Name: {person.Key}, Age: {person.Value}");
                    }

                    Console.WriteLine("\n--- Displaying dictionary (method 2: iterate over Keys) ---");
                    foreach (string key in people.Keys)
                    {
                        Console.WriteLine($"Name: {key}, Age: {people[key]}");
                    }

                    Console.WriteLine("\n--- Displaying dictionary (method 3: using enumerator explicitly) ---");
                    var enumerator = people.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        Console.WriteLine($"Name: {current.Key}, Age: {current.Value}");
                    }
                    break;

                case 3:
                    Console.Write("\nEnter the name (key) to remove: ");
                    string? removeKey = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(removeKey))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        break;
                    }

                    if (people.Remove(removeKey))
                    {
                        Console.WriteLine($"'{removeKey}' removed from dictionary.");
                    }
                    else
                    {
                        Console.WriteLine($"No entry found for '{removeKey}'.");
                    }
                    break;

                case 4:
                    Console.Write("\nEnter the new name (key) to add: ");
                    string? newKey = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newKey))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        break;
                    }

                    Console.Write("Enter the age (value) for that name: ");
                    string? newAgeInput = Console.ReadLine();
                    if (!int.TryParse(newAgeInput, out int newAge))
                    {
                        Console.WriteLine("Invalid age. Must be an integer.");
                        break;
                    }

                    if (people.ContainsKey(newKey))
                    {
                        Console.Write($"'{newKey}' already exists. Overwrite? (y/n): ");
                        string? ans = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(ans) && ans.Trim().ToLower() == "y")
                        {
                            people[newKey] = newAge;
                            Console.WriteLine($"'{newKey}' updated to age {newAge}.");
                        }
                        else
                        {
                            Console.WriteLine("Add cancelled.");
                        }
                    }
                    else
                    {
                        people.Add(newKey, newAge);
                        Console.WriteLine($"Added: {newKey}, {newAge}");
                    }
                    break;

                case 5:
                    Console.Write("\nEnter the existing name (key) to modify: ");
                    string? existKey = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(existKey))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        break;
                    }

                    if (!people.ContainsKey(existKey))
                    {
                        Console.WriteLine($"No entry found for '{existKey}'.");
                        break;
                    }

                    Console.WriteLine("Choose action: (1) Replace age  (2) Add years to current age");
                    Console.Write("Enter 1 or 2: ");
                    string? modeInput = Console.ReadLine();
                    if (modeInput == "2")
                    {
                        Console.Write("Enter number of years to add: ");
                        string? addInput = Console.ReadLine();
                        if (!int.TryParse(addInput, out int addYears))
                        {
                            Console.WriteLine("Invalid number.");
                            break;
                        }
                        people[existKey] += addYears;
                        Console.WriteLine($"'{existKey}' age incremented. New age: {people[existKey]}");
                    }
                    else // default to replace if anything else
                    {
                        Console.Write("Enter new age to replace existing: ");
                        string? replaceInput = Console.ReadLine();
                        if (!int.TryParse(replaceInput, out int replacedAge))
                        {
                            Console.WriteLine("Invalid age.");
                            break;
                        }
                        people[existKey] = replacedAge;
                        Console.WriteLine($"'{existKey}' age replaced. New age: {replacedAge}");
                    }
                    break;

                case 6:
                    Console.WriteLine("\n--- Sorted keys (ascending) ---");
                    List<string> sortedKeys = new List<string>(people.Keys);
                    sortedKeys.Sort(StringComparer.OrdinalIgnoreCase);
                    foreach (string key in sortedKeys)
                    {
                        Console.WriteLine($"Name: {key}, Age: {people[key]}");
                    }
                    break;

                case 0:
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Choose a number 0-6.");
                    break;
            }
        }
    }
}
