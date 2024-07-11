using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EatZilla.Models.CoreClasses;
using EatZilla.Models.DataConnection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MySqlConnector;
using System.Data;

namespace EatZilla.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDatabaseContext _context;
        public static int Uid = 200; 

        public UsersController(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       public IActionResult Create(String Name,String Email,String Phone,String Password)

        {
            User u = new User(Uid++,Name,Email,Phone,Password);
            _context.Add(u);
            _context.SaveChanges();

            return RedirectToAction("Sucess");
        }
        public IActionResult Sucess()
        {
            return View();
        }




        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        public IActionResult Login()
        {
            return View();
        }
        /*[HttpPost]
        public IActionResult Login(String Email,String Password)
        {
            List<User> users = _context.Users.ToList();
            foreach (User x in users)
            {
                if(x.Email.Equals(Email) && x.Password.Equals(Password)){
                    Console.WriteLine("Hello World");
                    return RedirectToAction("LoginSucess");
                }
                

            }
            return RedirectToAction("Create");

           
        }
        public IActionResult LoginSucess()
        {
            return View();
        }*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] User user)
        {
            string connectionString = "Server=localhost;Database=foodeatzilla;Uid=root;Pwd=cdac;";

            List<User> list = new List<User>();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    await cn.OpenAsync();

                    string sql = "SELECT * FROM users WHERE email = @Email AND password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", user.Password);

                        using (MySqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            if (dr.Read())
                            {
                                int userId = dr.GetInt32(dr.GetOrdinal("Id"));
                                string fullName = dr.GetString(dr.GetOrdinal("Name"));

                                // Store user information in session
                                HttpContext.Session.SetInt32("UserId", userId);
                                HttpContext.Session.SetString("FullName", fullName);
                                // If login successful, redirect to Create action in Movies controller
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                                return View(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error during login");
                throw;
            }

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            string fullName = HttpContext.Session.GetString("Name");

            if (userId == null || fullName == null)
            {

                //return RedirectToAction("Login", "User1");
                return View(await _context.dishes.ToListAsync());
            }

            return View(await _context.dishes.ToListAsync());


        }
    }
}
