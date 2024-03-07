using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiDotnet.models;
using Microsoft.EntityFrameworkCore;

namespace apiDotnet.data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):  base(options)
        {

        }
        
        public DbSet<User> Users {get; set;}
    }
}