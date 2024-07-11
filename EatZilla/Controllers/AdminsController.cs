using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EatZilla.Models.CoreClasses;
using EatZilla.Models.DataConnection;
using MySqlConnector;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EatZilla.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ApplicationDatabaseContext _context;

        public AdminsController(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admin.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("emailId,pass,id")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("emailId,pass,id")] Admin admin)
        {
            if (id != admin.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.id))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin != null)
            {
                _context.Admin.Remove(admin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.id == id);
        }
    }
    
/*   [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("EmailId,Pass")] Admin admin)
    {
        string connectionString = "Server=localhost;Database=foodeatzilla;Uid=root;Pwd=cdac;";

        try
        {
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                await cn.OpenAsync();

                string sql = "SELECT * FROM admin WHERE emailId = @EmailId AND pass = @Password";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@EmailId", admin.emailId);
                    cmd.Parameters.AddWithValue("@Password", admin.pass);

                    using (MySqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        if (dr.Read())
                        {
                            //int userId = dr.GetInt32(dr.GetOrdinal("Id"));
                           // string fullName = dr.GetString(dr.GetOrdinal("Name"));

                            // Example: Store user information in session
                            *//* HttpContext.Session.SetInt32("UserId", userId);
                             // HttpContext.Session.SetString("FullName", fullName);*//*
                            dr.Close();
                            // If login successful, redirect to Index action in Home controller
                            return RedirectToAction("Index", "Admins");
                        }
                        else
                        {
                            // ModelState.AddModelError(string.Empty, "Invalid email or password.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Error during login");
            // ModelState.AddModelError(string.Empty, "Error during login. Please try again later.");
            // return View(admin); // Return the view with an error message
        }

        return View(admin);
    }*/
}
    /* [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> Login([Bind("EmailId,Pass")] Admin admin)
     {
         string connectionString = "Server=localhost;Database=foodeatzilla;Uid=root;Pwd=cdac;";

         List<Admin> list = new List<Admin>();

         try
         {
             using (MySqlConnection cn = new MySqlConnection(connectionString))
             {
                 await cn.OpenAsync();

                 string sql = "SELECT * FROM admin WHERE emailId = @EmailId AND pass = @Pass";
                 using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                 {
                     cmd.Parameters.AddWithValue("@Email", admin.emailId);
                     cmd.Parameters.AddWithValue("@Password", admin.pass);

                     using (MySqlDataReader dr = await cmd.ExecuteReaderAsync())
                     {
                         if (dr.Read())
                         {
                             int userId = dr.GetInt32(dr.GetOrdinal("Id"));
                             string fullName = dr.GetString(dr.GetOrdinal("Name"));

                             *//*// Store user information in session
                             HttpContext.Session.SetInt32("UserId", userId);
                             HttpContext.Session.SetString("FullName", fullName);*//*
                             // If login successful, redirect to Create action in Movies controller
                             return RedirectToAction("Index", "Home");
                         }
                         else
                         {
                             //ModelState.AddModelError(string.Empty, "Invalid email or password.");

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
         return View(admin);
         //return View(list);
     }*/


