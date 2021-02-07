using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTut.Data;
using WebAppTut.Models;

namespace WebAppTut.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Populate the ApplicationDbContext property
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // This will view the "Category" table linked to our database (SQL Server)
        public IActionResult Index()
        {
            // This will retrieve all of the categories from the db
            // and will store them in the objList
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
        
        // POST - CREATE
        [HttpPost]  // Indicate that this is POST method
        [ValidateAntiForgeryToken]  // built-in security which checks if token is valid
        public IActionResult Create(Category obj)   // access category to where we will post data to
        {
            // checks if all the rules defined in the model
            // are valid, if they are then submit data to db
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);  // Add method provided EntityFrameworkCore
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - EDIT 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST- EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
/* NOTES
 * How To Get All Categories
 * 
 * 1. Get the DbContext from the DI Container previously stored
 *    - line 13 to 19
 * 2. Retrieve all of the table data from the database and store 
 *    into a list (Ex. 'objList' on line 25) then pass to View()
 * 3. Fetch the data, passed from the controller, inside the view
 *    - Since we passed 'category' data to the View method, 
 *      we need to fetch that data from the view for the controller
 *    - Example can be found in 'Index.cshtml' file where we retrieve 
 *      the 'Category' table data from SQL Server
 */ 