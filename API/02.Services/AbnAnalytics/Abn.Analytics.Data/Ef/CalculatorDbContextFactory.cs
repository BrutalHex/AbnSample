using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Data.Ef
{
 
    public class CalculatorDbContextFactory : IDesignTimeDbContextFactory<CalculatorDbContext>
    {
        public CalculatorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>();


            optionsBuilder.UseSqlServer();
            return new CalculatorDbContext(optionsBuilder.Options);
        }
    }
}
