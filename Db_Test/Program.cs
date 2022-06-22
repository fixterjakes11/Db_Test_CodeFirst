using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Db_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool status = true;
            while (status == true)
            {
                Console.WriteLine("Напишите 1 если хотите зарегистрироваться\n2 если хотите вывести список зарешестрированных пользователей" +
                    "\n3 для авторизации\n4 для выхода\n5 для удаление всех записей ");
                string sym = Console.ReadLine();
                switch (sym)
                {
                    case "1":
                        SetUser();
                        break;
                        
                    case "2":
                        PrintUser();
                        break;
                    case "3":
                        CheckUser();
                        break;
                    case "5":
                        UserService.AllDelete();
                        break;
                    case "4":
                        status =false;
                        break;
                }
            }
        }

        public static void SetUser()
        {
            try
            {
                Console.WriteLine("Регистрация:\n Напишите имя:");
                string Name = Console.ReadLine();
                Console.WriteLine("Напишите логин");
                string Login = Console.ReadLine();
                Console.WriteLine("Напишите пароль");
                string Password = Console.ReadLine();
                UserService.AddUser(Name, Login, Password);
                Console.WriteLine("Запись успешно добавлена");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintUser()
        {
            try
            {
                UserService.GetUser().ForEach(x => Console.WriteLine(x));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public static void CheckUser()
        {
            Console.WriteLine("Введите Логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            Console.WriteLine(UserService.CheckUser(login, password));
        }
    }
}
