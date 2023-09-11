using System;
using System.Collections.Generic;

namespace Grupp_ja_liikmed
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();

            List<Liik> allCandidates = new List<Liik>();

            for (int i = 0; i < 40; i++)
            {
                string name1 = GenerateRandomName(random);
                int age1 = random.Next(18, 60);

                Liik liik1 = new Liik(name1, age1);

                allCandidates.Add(liik1);
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Group 1 Candidates:");
            PrintColoredNames(allCandidates);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGroup 2 Candidates:");
            PrintColoredNames(allCandidates);
            Console.ResetColor();

            string groupName1 = GenerateRandomName(random);
            int maxAmount1 = random.Next(1, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Group group1 = new Group(maxAmount1, allCandidates);
            Console.WriteLine($"\nGroup 1 Max Spaces: {maxAmount1} ");

            string groupName2 = GenerateRandomName(random);
            int maxAmount2 = random.Next(1, 21);
            Group group2 = new Group(maxAmount2, allCandidates);
            Console.WriteLine($"Group 2 Max Spaces: {maxAmount2}\n");
            Console.ResetColor();

            while (group1.HasAvailableSpace() || group2.HasAvailableSpace())
            {
                if (group1.HasAvailableSpace() && allCandidates.Count > 0)
                {
                    int randomIndex = random.Next(allCandidates.Count);
                    Liik member = allCandidates[randomIndex];
                    if (group1.AddMember(member.Name, member.Age))
                    {
                        allCandidates.RemoveAt(randomIndex);
                    }
                }

                if (group2.HasAvailableSpace() && allCandidates.Count > 0)
                {
                    int randomIndex = random.Next(allCandidates.Count);
                    Liik member = allCandidates[randomIndex];
                    if (group2.AddMember(member.Name, member.Age))
                    {
                        allCandidates.RemoveAt(randomIndex);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Group 1 Successfully joined members: {string.Join(", ", group1.Members)}");
            Console.WriteLine($"Group 2 Successfully joined members: {string.Join(", ", group2.Members)}  \n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(group1.GetOldestMember());
            Console.WriteLine(group2.GetOldestMember());
            Console.ResetColor();
        }

        static string GenerateRandomName(Random random)
        {
            string[] names = { "John", "Mary", "Samantha", "Robert", "Emily", "Maksim", "Luca", "Alex", "Martin", "Yarik", "Sasha", "Timur", "Arkadii", "Archi", "Artur", "Albert", "Stark", "Tony", "Alik", "Mart", "Kirill", "Oleg" };
            return names[random.Next(names.Length)];
        }

        static void PrintColoredNames(List<Liik> members)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            foreach (Liik member in members)
            {
                string name = member.Name;
                if (uniqueNames.Contains(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    uniqueNames.Add(name);
                }
                Console.Write($"{member.Name}, ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
