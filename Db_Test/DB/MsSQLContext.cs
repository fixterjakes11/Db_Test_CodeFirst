using Microsoft.EntityFrameworkCore;


namespace Db_Test.DB
{
    public class MsSQLContext :DbContext
    {
        static string Adress = "COMPUTER\\SQLEXPRESS";
        static string Name = "Db_Test";

        string connectionString = $"Server = {Adress}; Database = {Name}; Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<User> User { get; set; }

    }
}
