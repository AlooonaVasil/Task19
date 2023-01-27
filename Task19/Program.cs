using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Code = 1, Marka = "AMD",Processor = "Phenom", Frequency = 4.5, RAM = 7150,HDD = 3200, Videocard = 19520, Price = 66500,Count = 15},
                new Computer(){Code = 2, Marka = "Bull",Processor = "Pentium", Frequency = 3.4, RAM = 8150,HDD = 2785, Videocard = 18999, Price = 62435,Count = 10},
                new Computer(){Code = 3, Marka = "Dell",Processor = "Phenom", Frequency = 3.7, RAM = 6000,HDD = 3230, Videocard = 19919, Price = 50000,Count = 7},
                new Computer(){Code = 4, Marka = "Fujitsu",Processor = "Phenom", Frequency = 4.2, RAM = 7278,HDD = 3075, Videocard = 17754, Price = 75000,Count = 35},
                new Computer(){Code = 5, Marka = "HP",Processor = "Pentium", Frequency = 4.5, RAM = 7150,HDD = 3040, Videocard = 15922, Price = 63000,Count = 8},
                new Computer(){Code = 6, Marka = "Hitachi",Processor = "POWER4", Frequency = 3.7, RAM = 6000,HDD = 2910, Videocard = 19700, Price = 51000,Count = 26},
                new Computer(){Code = 7, Marka = "IBM",Processor = "POWER4", Frequency = 3.4, RAM = 5489,HDD = 3120, Videocard = 20310, Price = 45000,Count = 14},
                new Computer(){Code = 8, Marka = "Intel",Processor =  "Intel Core i7", Frequency = 4.9, RAM = 6000,HDD = 2709, Videocard = 20812, Price = 49000,Count = 30},
            };

            Console.WriteLine("Введите интересующий процессор");
            string processor = Console.ReadLine();
            List<Computer> computers1 = computers.Where(x => x.Processor == processor).ToList();
            if (computers1.Count == 0)
            {
                Console.WriteLine("Подходящих компьютеров нет");
            }
            else
            {
                Console.WriteLine("Список подходящих компьютеров:");
                Print(computers1);
            }

            Console.WriteLine("Введите интересующее ОЗУ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = computers.Where(x => x.RAM >= ram).ToList();
            if (computers2.Count == 0)
            {
                Console.WriteLine("Подходящих компьютеров нет");
            }
            else
            {
                Console.WriteLine("Список подходящих компьютеров:");
                Print(computers2);
            }

            List<Computer> computers3 = computers.OrderBy(x => x.Price).ToList();
            Console.WriteLine("Cписок компьютеров, отсортированный по увеличению стоимости:");
            Print(computers3);

            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(x => x.Processor);
            Console.WriteLine("Cписок компьютеров, сгруппированный по типу процессора:");
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer comp in gr)
                {
                    Console.WriteLine($"{comp.Code} {comp.Marka} {comp.Processor} {comp.Frequency} {comp.RAM} {comp.HDD} {comp.Videocard} {comp.Price} {comp.Count}");
                }
            }
            
            Computer computerMax = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine("Самый дорогой компьютер:");
            Console.WriteLine($"{computerMax.Code} {computerMax.Marka} {computerMax.Processor} {computerMax.Frequency} {computerMax.RAM} {computerMax.HDD} " +
                              $"{computerMax.Videocard} {computerMax.Price} {computerMax.Count}");

            Console.WriteLine("Самый бюджетный компьютер:");
            Computer computerMin = computers.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computerMin.Code} {computerMin.Marka} {computerMin.Processor} {computerMin.Frequency} {computerMin.RAM} {computerMin.HDD} " +
                              $"{computerMin.Videocard} {computerMin.Price} {computerMin.Count}");
            
            Console.WriteLine();
            if (computers.Any(x => x.Count >= 30) == true)
            {
                Console.WriteLine("Есть хотя бы один компьютер в количестве не менее 30 штук");
            }
            else
            {
                Console.WriteLine("Нет ни одного компьютера в количестве не менее 30 штук");
            }
            Console.ReadKey();

            static void Print(List<Computer> computers)
            {
                foreach (Computer comp in computers)
                {
                    Console.WriteLine($"{comp.Code} {comp.Marka} {comp.Processor} {comp.Frequency} {comp.RAM} {comp.HDD} {comp.Videocard} {comp.Price} {comp.Count}");
                }
                Console.WriteLine();
            }
        }
    }
}
