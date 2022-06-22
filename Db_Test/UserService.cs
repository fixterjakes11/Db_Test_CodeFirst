using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db_Test
{
    public class UserService
    {
        public static void AddUser(string name, string login, string password)
        {
            using DB.MsSQLContext db = new DB.MsSQLContext();
            db.User.Add(new DB.User { Name = name, Login = login, Password = password, TimeRegistritions = DateTime.Now});
            db.SaveChanges();
        }

        public static List<string> GetUser()
        {
            using DB.MsSQLContext db = new DB.MsSQLContext();
            List<string> rez = new List<string>();
            db.User.ToList().ForEach(r => rez.Add($"Id - {r.UserId} Name - {r.Name} Date - {r.TimeRegistritions}"));
            return rez;
        }

        public static string CheckUser(string login, string password)
        {
            using DB.MsSQLContext db = new DB.MsSQLContext();
            List<string> pas = new List<string>();
            List<string> log = new List<string>();
            db.User.ToList().ForEach(r => log.Add($"{r.Login}"));
            db.User.ToList().ForEach(r => pas.Add($"{r.Password}"));
            if (log.Contains(login))
            {
                if (pas.Contains(password))
                {
                    return "Вы успешно вошли";
                }
                return "Логин или пароль не правильные";
            }
            return "Логин или пароль не правильные";
        }

        public static void AllDelete()
        {
            using DB.MsSQLContext db = new DB.MsSQLContext();
            db.User.RemoveRange(db.User);
            db.SaveChanges();
        }
    }
}
