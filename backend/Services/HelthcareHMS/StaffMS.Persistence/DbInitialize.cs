namespace StaffMS.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(StaffMSDbContext context) => context.Database.EnsureCreated();
    }
}
