using System;
using Microsoft.EntityFrameworkCore;

namespace dotnetserver.DataAccess
{
    public class Repository : DbContext
    {
        // the base key word refers to the constructor of the father class "DBcontext" 
        public Repository(DbContextOptions<Repository> options): base(options)
        {

           
        }
       public  DbSet<SuperHeros> superHeroses { get; set; }
    }
}

