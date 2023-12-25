using System.Xml.Linq;

namespace characters
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                List<person> persons = new List<person>();
                Random random = new Random();
                Console.WriteLine("Enter name of 1 person");
                string name = Console.ReadLine();
                Console.WriteLine("Enter coordinate X for 1 person");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter coodinate Y for 1 person");
                int y = int.Parse(Console.ReadLine());  
                Console.WriteLine("Enter quantity lifes for 1 person");
                int quantity = int.Parse(Console.ReadLine()); 
                string fraction = "";
                Console.WriteLine("Enter which fracture u will be\nQ - Neutral\nW - Enemy");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        fraction = "Neutral";
                            break;
                    case ConsoleKey.W:
                        fraction = "Orc";
                        break;
                }
                int damage = random.Next(30,70);
                int hp = random.Next(70, 100);
                person person = new person(name,x,y,quantity,damage,hp,fraction);
                person.input();
            }
            catch
            {
                Console.WriteLine("Something wrong");
            }
        }
    }
}