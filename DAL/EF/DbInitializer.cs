using DAL.Entities;

namespace DAL.EF;

public class DbInitializer
{
    public static void Initialize(ApplicationContext context)
    {
        // Если вы используете миграции, лучше заменить EnsureCreated на Migrate
        context.Database.EnsureCreated();

        if (context.Users.Any())
        {
            return; // Пользователи уже есть, инициализация не нужна
        }

        var user = new User
        {
            Email = "admin@example.com",
            Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
            Phone = "8(800)555-34-32"
        };

        context.Users.Add(user);
        context.SaveChanges();
    }
}