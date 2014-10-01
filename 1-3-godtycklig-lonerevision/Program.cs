
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace godtycklig_lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            // Beskriver vilken konsol tangent som har tryckts ned.
            ConsoleKeyInfo quitProgram;

            // Användaren matar in antal löner som hämtas ReadInt metoden.
            // Tryck någon tangent för omstart av programmet.
            do
            {
                int amountOfSalaries = ReadInt("Ange antal löner att mata in: ");
                ProcessSalaries(amountOfSalaries);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck på någon tangent för ny beräkning - ESC avslutar");
                quitProgram = Console.ReadKey();
                Console.ResetColor();
                Console.Clear();

                //ESC avslutar programmet.
            } while (quitProgram.Key != ConsoleKey.Escape);


        }

        // Användaren matar in de löner som som angetts i ReadInt.
        // Arrayer skapas.
        private static void ProcessSalaries(int count)
        {
            Console.WriteLine("\n");
            int[] salaries = new int[count];

            for (int i = 0; i < count; i++)
            {
                String prompt = String.Format("Ange lön nummer {0}: ", i + 1);
                salaries[i] = ReadInt(prompt);
            }
            // Arrayer sorteras.
            Array.Sort(salaries);
            int median = 0;
            int average = 0;
            int splitSalaries = 0;

            //Jämför om talet är jämt eller ojämt.
            switch (salaries.Length % 2)
            {
                // Om talet är jämt.
                case 0:
                    median = (salaries[salaries.Length / 2] + salaries[salaries.Length / 2 - 1]) / 2;
                    break;
                // Om talet är ojämt.
                case 1:
                    median = salaries[salaries.Length / 2];
                    break;
                // Skriver ut alla uträkningar.
            }
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("Medianlön:\t {0,10:c0}", median);

            average = Convert.ToInt32(salaries.Average());
            Console.WriteLine("Medellön:\t {0,10:c0}", average);

            splitSalaries = salaries.Max() - salaries.Min();
            Console.WriteLine("Lönespridning:\t {0,10:c0}", splitSalaries);
            Console.WriteLine("\n-------------------------------");

            //Skriver ut lönerna i arrayen
            for (int cols = 0; cols < salaries.Length; cols++)
            {
                Console.Write("{0,6} ", salaries[cols]);

                // Byter rad efter att tre punkter har skrivits ut.
                if (cols % 3 == 2)
                {
                    Console.WriteLine();
                }

            } Console.WriteLine("\n");

        }

        // Om användarens inmatning inte är ett heltal i for av nummer så skrivs ett felmeddelande ut.
        private static int ReadInt(string prompt)
        {
            int userInput = 0;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    userInput = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Kan inte tolkas som ett heltal");
                    Console.ResetColor();
                }
            }

            // Användaren får ett nytt försök att mata in.
            return userInput;
        }

    }

}