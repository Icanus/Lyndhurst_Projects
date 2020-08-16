using Microsoft.EntityFrameworkCore;

namespace Blazor_CRUD_test.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext() { }

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    }

    public class AppContext1 : DbContext
    {
        public AppContext1() { }

        public AppContext1(DbContextOptions<AppContext1> options) : base(options) { }
    }
}
