using DrivingSchoolApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Tests.TestHelpers
{
    public static class TestDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            return new ApplicationDbContext(options);
        }
    }
}
