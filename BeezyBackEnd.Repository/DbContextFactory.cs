using BeezyBackEnd.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyBackEnd.Repository
{
    class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();

        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseSqlServer(DataConnectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
