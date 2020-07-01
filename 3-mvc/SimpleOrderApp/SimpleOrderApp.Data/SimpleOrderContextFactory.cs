using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SimpleOrderApp.Data.Model;

namespace SimpleOrderApp.Data
{
    public class SimpleOrderContextFactory : IDesignTimeDbContextFactory<SimpleOrderContext>
    {
        // whoever calls this method gains ownership of the context (and must dispose it)
        public SimpleOrderContext CreateDbContext(string[] args = default)
        {
            var options = new DbContextOptionsBuilder<SimpleOrderContext>()
                .UseSqlite("Data Source=C:\\revature\\simpleorder.db")
                .Options;

            return new SimpleOrderContext(options);
        }
    }
}
