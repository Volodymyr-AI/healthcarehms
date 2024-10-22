using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(HospitalDbContext context) => context.Database.EnsureCreated();
    }
}
