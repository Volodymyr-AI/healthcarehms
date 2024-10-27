namespace HealthcareHMS.Persistence;

public class DbInitializer
{
    public static void Initialize(HealthcareHMSDbContext context) => context.Database.EnsureCreated();
}