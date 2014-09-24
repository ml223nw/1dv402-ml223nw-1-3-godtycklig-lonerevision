
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
            int amountOfSalaries = ReadInt("Ange antal löner att mata in: ");
            ProcessSalaries(amountOfSalaries);
        }

        private static void ProcessSalaries(int count)
        {
            Console.WriteLine("\n");
            int[] salaries = new int[count];

            for (int i = 0; i < count; i++)
            {
                String prompt = String.Format("Ange lön nummer {0}: ", i + 1);
                salaries[i] = ReadInt(prompt);
            }
            //Sortera array
            Array.Sort(salaries);
            int median = 0;
            int average = 0;
            int splitSalaries = 0;

            //Jämför om talet är jämt eller ojämt.
            switch (salaries.Length % 2)
            {
                //Om talet är jämt.
                case 0:
                    median = (salaries[salaries.Length / 2] + salaries[salaries.Length / 2 - 1]) / 2;
                    break;
                //Om talet är ojämt.
                case 1:
                    median = salaries[salaries.Length / 2];
                    break;
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

               //När tre punkter har skrivits ut, byt rad
               if (cols % 3 == 2) //Tex när cols är 2, 5, 8 osv..
               {
                   Console.WriteLine();
               }

            } Console.WriteLine("\n");

         } 

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

            return userInput;
        }

    }

}