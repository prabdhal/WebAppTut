using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTut.Models;

namespace WebAppTut.Data
{
    // Push the 'Category' model to the database (SQL Server)
    public class ApplicationDbContext : DbContext
    {
        // Configuration required in order to use the DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Properties to push models to the database
        public DbSet<Category> Category { get; set; }
    }
}

/* NOTES
 * How To Connect to DB
 * 
 * 1. Create a model for a data table [Create First Model]
 * 2. Add a connection string to the 'appsetting.json' file [Add Connection String]
 * 3. Create a 'Data' folder to store your DbContext [Setup DbContext]
 * 4. Create an 'ApplicationDbContext.cs' file inorder to 
 *    create and push data to our database (SQL Server)
 *    - will need to install a package called 'EntityFrameworkCore.SQLServer'
 *      which will install the 'EntityFrameworkCore' automatically as well
 * 5. Create property to push model to the database (example found in line 20)
 * 6. Add the database context to the 'ConfigureServices' method in 'Startup.cs' [Complete Configuration]
 *    passing the connection string as well
 * 7. Add a migration to push the DbContext to the database [Push Data To Database]
 *    by running 'add-migration addDataToDatabase' in the Package Manager Console
 *    - will need to install 'Microsoft.EntityFrameworkCore.Tools'
 *    
 *    
 * If You Need To Make Changes To Database
 * 
 * 1. First make changes
 * 2. Add a migration (step 7)
 * 3. Run update-database to push the migration to the database
 */