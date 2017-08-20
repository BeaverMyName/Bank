using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] users = new string[0, 4];
            string[] log_pas = new string[2];

            while (true)
            {
                Console.Clear();
                Enter(log_pas);

                if (log_pas[0] == "Admin" && log_pas[1] == "123")
                    users = Admin(users);
                else
                {
                    for (int i = 0; i < users.GetLength(0); i++)
                    {
                        if (log_pas[0] == users[i, 0] && log_pas[1] == users[i, 1])
                            User(users, i);
                        else if(i == users.GetLength(0) - 1)
                        {
                            Console.WriteLine("User not found! Press any key to try again...");
                            Console.ReadKey();
                        }
                    }
                }

            }
        }

        static string[] Enter(string[] log_pas)
        {
            Console.WriteLine("Enter login: ");
            log_pas[0] = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            log_pas[1] = Console.ReadLine();

            Console.Clear();

            return log_pas;
        }

        static string[,] Admin(string[,] users)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\tMenu\n\nPress:\n\n'1' - List of users\n'2' - To block user\n'3' - To unblock user\n'4' - Add new user\n'5' - Delete user\n'6' - Quit from account");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        ListUsers(users);
                        Console.WriteLine("Press any key to quit from list of users...");
                        Console.ReadKey();
                        break;
                    case "2":
                        while (true)
                        {
                            BlockUsers(users);
                            string end = End();
                            if (end == "yes")
                                break;
                        }
                        break;
                    case "3":
                        while (true)
                        {
                            UnblockUsers(users);
                            string end = End();
                            if (end  == "yes")
                                break;
                        }
                        break;
                    case "4":
                        while (true)
                        {
                            users = AddUsers(users);
                            string end = End();
                            if (end == "yes")
                                break;
                        }
                        break;
                    case "5":
                        while (true)
                        {
                            users = DeleteUsers(users);
                            string end = End();
                            if (end == "yes")
                                break;
                        }
                        break;
                    case "6": return users;
                }
            }
        }

        static void ListUsers(string[,] users)
        {
            Console.Clear();
            Console.WriteLine("\tList of users:\n");

            for (int i = 0; i < users.GetLength(0); i++)
            {
                Console.Write((i+1) + ". " + users[i, 0] + " ");
                Console.Write(users[i, 2] + " ");
                Console.WriteLine(users[i, 3]);
            }
            Console.WriteLine("");
        }

        static string[,] BlockUsers(string[,] users)
        {
            Console.Clear();
            ListUsers(users);

            if (users.GetLength(0) != 0)
            {
                while (true)
                {
                    Console.WriteLine("Enter number of user to block him");

                    if (Int32.TryParse(Console.ReadLine(), out int block))
                    {
                        if (block <= users.GetLength(0) && block != 0)
                        {
                            users[block - 1, 3] = "blocked";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("User not found! Press any key to try again...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! Press any key to try again...");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("List is empty! Press any key to return in menu...");
                Console.ReadKey();
            }

            return users;
        }

        static string[,] UnblockUsers(string[,] users)
        {
            Console.Clear();
            ListUsers(users);

            if (users.GetLength(0) != 0)
            {
                while (true)
                {
                    Console.WriteLine("Enter number of user to unblock him:");
                    if (Int32.TryParse(Console.ReadLine(), out int unblock))
                    {
                        if (unblock <= users.GetLength(0) && unblock != 0)
                        {
                            users[unblock - 1, 3] = null;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("User not found! Press any key to try again...");
                            Console.ReadKey();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("List is empty! Press any key to return in menu...");
                Console.ReadKey();
            }

            return users;
        }

        static string[,] AddUsers(string[,] users)
        {
            Console.Clear();
            ListUsers(users);

            string[,] new_users = new string[users.GetLength(0) + 1, 4];

            for (int i = 0; i < users.GetLength(0); i++)
                for (int j = 0; j < 4; j++)
                    new_users[i, j] = users[i, j];

            Console.WriteLine("Enter login of new user:");
            new_users[users.GetLength(0), 0] = Console.ReadLine();

            Console.WriteLine("\nEnter password of new user:");
            new_users[users.GetLength(0), 1] = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nEnter account of new user:");

                if (Int32.TryParse(Console.ReadLine(), out int account))
                {
                    new_users[users.GetLength(0), 2] = Convert.ToString(account);
                    break;
                }
                Console.WriteLine("Error! Press any key to try again...");
                Console.ReadKey();
            }

            return new_users;
        }

        static string[,] DeleteUsers(string[,] users)
        {
            Console.Clear();
            ListUsers(users);

            if (users.GetLength(0) != 0)
            {
                string[,] new_users = new string[users.GetLength(0) - 1, 4];

                while (true)
                {
                    Console.WriteLine("Enter number of user to delete him:");

                    if (Int32.TryParse(Console.ReadLine(), out int delete))
                    {
                        if (delete <= users.GetLength(0))
                        {
                            for (int i = 0; i < new_users.GetLength(0); i++)
                                for (int j = 0; j < 4; j++)
                                {
                                    if (i < delete - 1)
                                        new_users[i, j] = users[i, j];
                                    else
                                        new_users[i, j] = users[i + 1, j];
                                }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("User not found! Press any key to try again...");
                            Console.ReadKey();
                        }
                    }
                }
                return new_users;
            }
            else
            {
                Console.WriteLine("List is empty! Press any key to return in menu...");
                Console.ReadKey();
            }

            return users;
        }

        static string End()
        {
            while (true)
            {
                Console.WriteLine("Return to menu?(yes/no)");
                string end = Console.ReadLine();
                if (end == "yes" || end == "no")
                    return end;
                Console.Clear();
            }
        }

        static string[,] User(string[,] users, int index)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Your account: " + users[index, 2] + "\n");

                if (users[index, 3] != "blocked")
                {
                    Console.WriteLine("\tMenu\n\nPress:\n\n'1' - To replenish a bank account\n'2' - To withdraw money from account\n'3' - To quit from account");
                    string menu = Console.ReadLine();

                    switch (menu)
                    {
                        case "1":
                            while (true)
                            {
                                Replenish(users, index);
                                string end = End();
                                if (end == "yes")
                                    break;
                            }
                            break;
                        case "2":
                            while (true)
                            {
                                Withdraw(users, index);
                                string end = End();
                                if (end == "yes")
                                    break;
                            }
                            break;
                        case "3":
                            return users;
                    }
                }
                else
                {
                    Console.WriteLine("Your account was blocked! Press any key to quit from account...");
                    Console.ReadKey();
                    return users;
                }
            }
        }

        static string[,] Replenish(string[,] users, int index)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Your account: " + users[index, 2] + "\n");

                Console.WriteLine("Enter amount of money:");

                if (Int32.TryParse(Console.ReadLine(), out int new_money))
                {
                    int money = Convert.ToInt32(users[index, 2]);
                    money += new_money;
                    users[index, 2] = Convert.ToString(money);
                    break;
                }
                else
                {
                    Console.WriteLine("Error! Press any key to try again...");
                    Console.ReadKey();
                }
            }
            return users;
        }

        static string[,] Withdraw(string[,] users, int index)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Your account: " + users[index, 2] + "\n");

                Console.WriteLine("Enter amount of money:");

                if (Int32.TryParse(Console.ReadLine(), out int new_money))
                {
                    int money = Convert.ToInt32(users[index, 2]);
                    money -= new_money;
                    users[index, 2] = Convert.ToString(money);
                    break;
                }
                else
                {
                    Console.WriteLine("Error! Press any key to try again...");
                    Console.ReadKey();
                }
            }
            return users;
        }
    }
}

