using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace characters
{
    internal class person
    {
        static List<person> persons = new List<person>();
        private string name;
        private int x;
        private int y;
        private bool relationships = true;
        private int quantity_lifes;
        private int hp;
        private int damage;
        private int max_hp;
        private string fraction = "neutral";
        public person(string name, int x, int y, int quantity_lifes, int damage, int hp)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.quantity_lifes = quantity_lifes;
            this.damage = damage;
            this.hp = hp;
            this.max_hp = hp;
            this.fraction = "Neutral";
            persons.Add(this);
        }        
        Random rand = new Random();
        private int get_x()
        {
            return x;
        }
        private int get_y()
        {
            return y;
        }

        private void printInfo()
        {
            Console.WriteLine("name:" + this.name);
            Console.WriteLine("X: " + x);
            Console.WriteLine("Y: " + y);
            Console.WriteLine("Relationships: " + relationships);
            Console.WriteLine("Quanitity of lifes:" + quantity_lifes);
            Console.WriteLine("Health: " + hp);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Max health:" + max_hp);
        }
        private void movex(int x)
        {
            this.x += x;
        }
        private void movey(int y)
        {
            this.y += y;
        }
        private void del()
        {
            hp = 0;
            x = -1;
            y = -1;
            if (quantity_lifes == 1)
            {
                person_counter--;
            }
            if(quantity_lifes > 0)
            {
                person_counter++;
            }
        }
        private int get_quantity_lifes()
        {
            return quantity_lifes;
        }
        private void uron(int uron)
        {
            hp -= uron;
            if (hp <= 0)
                hp = 0;
        }
        private void doc(int doc)
        {
            hp += doc;
            if (hp >= max_hp)
            {
                hp = max_hp;
            }
        }
        private void vost()
        {
            hp = max_hp;
        }
        private void respawn()
        {
            quantity_lifes -= 1;
            x = 0;
            y = 0;
        }
        private int taken_damage(int damage)
        {
            this.hp -= damage;
            if (this.hp < 0)
                hp = 0;
            return hp;
        }
        int person_counter=1;
        public void input()
        {
            Console.WriteLine("Enter how many persons you will have");
            int person_num = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your character. You have: " + person_counter);
            int selected_character = int.Parse(Console.ReadLine());
            while (true)
            {
                try
                {
                    if ((person_num == 0) && (person_num < 0))
                    {
                        Console.WriteLine("Only positive numbers ");
                        return;
                    }
                    if (persons.Count != person_num)
                    {
                        for (int i = 1; i < person_num; i++)
                        {
                            Console.Clear();
                            Console.WriteLine($"Enter name for person " + (i + 1));
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter X for person " + (i + 1));
                            int x_pers = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Y for person " + (i + 1));
                            int y_pers = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter quantity of lifes for person " + (i + 1));
                            int quantyty_lifes1 = int.Parse(Console.ReadLine());
                            int hp_pers = rand.Next(30, 70);
                            int damage_pers = rand.Next(70, 100);
                            person persona = new person(name,x_pers,y_pers,quantyty_lifes1,damage_pers,hp_pers);
                            person_counter++;
                        }
                    }
                        if ((selected_character <= 0) || (selected_character > person_num))
                        {
                            Console.WriteLine("You doesn't have this character");
                            Console.WriteLine("Press any button to exit");
                            Console.ReadKey();
                            break;
                        }

                        if (persons[selected_character - 1].hp == 0)
                        {
                            if (persons[selected_character - 1].get_quantity_lifes() == 1)
                            {
                                if (person_counter == 0)
                                {
                                    Console.WriteLine("You lose");
                                    Console.ReadLine();
                                    return;
                                }
                            }
                            if (persons[selected_character - 1].get_quantity_lifes() > 1)
                            {
                                Console.WriteLine("You have " + persons[selected_character - 1].get_quantity_lifes() + " lifes. Want to continue?(y/n)");
                                string y_n = Console.ReadLine();
                                switch (y_n)
                                {
                                    case "y":
                                        persons[selected_character - 1].vost();
                                        persons[selected_character - 1].respawn();
                                        Console.WriteLine("Your healt: " + persons[selected_character - 1].hp);
                                        Console.WriteLine("Press any button to continue");
                                        Console.ReadKey();
                                        break;
                                    case "n":
                                        persons[selected_character - 1].del();
                                        Console.WriteLine("Character is dead");
                                        person_counter--;
                                        break;
                                }
                            }
                        }
                        if (person_counter > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("A - to bring out info about character\nS - to move for X\nD - to move for Y\nF - to kill character\nG - to damage yourself\nH - to heal yourself\nJ - to get full health\nK - to swap character\n");
                            ConsoleKey need_button = Console.ReadKey().Key;
                            int for_x = 0;
                            int for_y = 0;
                            int damage_deal;
                            int heal = 0;
                            Console.WriteLine();
                            switch (need_button)
                            {
                                case ConsoleKey.A:
                                    persons[selected_character - 1].printInfo();
                                    Console.WriteLine("Press any button to continue");
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.S:
                                    Console.WriteLine("Specify how much the character must pass for X: ");
                                    for_x = int.Parse(Console.ReadLine());
                                    persons[selected_character - 1].movex(for_x);
                                    Console.WriteLine("X: " + persons[selected_character - 1].x);
                                    Console.WriteLine("Press any button to continue");
                                    enemy_exist(selected_character);
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.D:
                                    Console.WriteLine("Specify how much the character must pass for Y: ");
                                    for_y = int.Parse(Console.ReadLine());
                                    persons[selected_character - 1].movey(for_y);
                                    Console.WriteLine("Y: " + persons[selected_character - 1].y);
                                    Console.WriteLine("Press any button to continue");
                                    enemy_exist(selected_character);
                                    Console.ReadKey();
                                    
                                    break;
                                case ConsoleKey.F:
                                    persons[selected_character - 1].del();
                                    person_counter--;
                                    Console.WriteLine("Character is dead. Take another one");
                                    Console.WriteLine("Press any button to continue");
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.G:
                                    Console.WriteLine("Are you sure? How many damage should be done");
                                    damage_deal = int.Parse(Console.ReadLine());
                                    persons[selected_character - 1].uron(damage_deal);
                                    break;
                                case ConsoleKey.H:
                                    Console.WriteLine("How many healtpoints need to regen?");
                                    heal = int.Parse(Console.ReadLine());
                                    persons[selected_character - 1].doc(heal);
                                    Console.WriteLine("HP now: " + persons[selected_character - 1].hp);
                                    Console.WriteLine("Press any button to continue");
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.J:
                                    persons[selected_character - 1].vost();
                                    Console.WriteLine("HP now: " + persons[selected_character - 1].hp);
                                    Console.WriteLine("Press any button to continue");
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.K:
                                    Console.WriteLine("Which character you want to take?");
                                    selected_character = int.Parse(Console.ReadLine());
                                    if (selected_character > person_num)
                                    {
                                        Console.WriteLine("You doesn't have this character");
                                        Console.WriteLine("Press any button to continue");
                                        Console.ReadKey();
                                        break;
                                    }
                                    Console.WriteLine("Now you " + selected_character + " character");
                                    Console.WriteLine("Press any button to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                    }
                

                catch
                {
                    Console.WriteLine("Something wrong");
                    Console.WriteLine("Press any button to continue");
                    break;
                }
            }
        }
        private string enemy_fraction()
        {
            string fraction_name ="neutral";
            int fract = rand.Next(3);
            if (fract == 1)
            {
                fraction_name = "orc";
                return fraction_name;
            }
            if(fract == 2) 
            {
                fraction_name = "neutral";
                return fraction_name;
            }
            return fraction_name;
        }
        private void enemy_exist(int selected_character)
        {
            int enemy_counter = 0;
            int enemy = rand.Next(4);
            int enemy_hp = rand.Next(20, 50);
            int enemy_damage = rand.Next(10, 30);
            if (enemy == 3)
            {
                while (enemy_hp > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You on the same coordinates with enemy");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("W - to hit character\nE - to get out from this coordinates\nR - to call for help");
                    if (enemy_hp < 0)
                    {
                        Console.WriteLine("You kill him");
                        enemy_counter++;
                        Console.WriteLine("Press any button to continue");
                        Console.ReadKey();
                        break;
                    }
                    ConsoleKey select_key = Console.ReadKey().Key;
                    Console.WriteLine();
                    int team_damage = 0;
                    switch (select_key)
                    {
                        case ConsoleKey.W:
                            if (persons[selected_character - 1].fraction == enemy_fraction())
                            {
                                Console.WriteLine("You from the same fraction");
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            if (team_damage > 0)
                            {
                                Console.WriteLine($"HP enemy character:   {enemy_hp - team_damage}");
                                Console.WriteLine("You were attacked in response");
                                for (int j = 0; j < person_counter; j++)
                                {
                                    Console.WriteLine("HP your character: " + persons[j].taken_damage(enemy_damage / person_counter));
                                }
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine($"HP enemy character:   {enemy_hp - persons[selected_character - 1].damage}");
                            Console.WriteLine("You were attacked in response");
                            Console.WriteLine("HP your character: " + persons[selected_character - 1].taken_damage(enemy_damage));
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.E:
                            persons[selected_character - 1].movex(1);
                            Console.WriteLine("X now:" + persons[selected_character - 1].get_x());
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.R:
                            for (int i = 0; i < person_counter; i++)
                            {
                                persons[i].x = persons[selected_character - 1].x;
                                persons[i].y = persons[selected_character - 1].y;
                                team_damage += persons[i].damage;
                            }
                            Console.WriteLine("Now on this coordinates: " + person_counter + " your characters");
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                    }
                    break;
                }
            if (enemy_counter == 5)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("You win.");
                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
            }
                
            }  
            }
            }
        }

