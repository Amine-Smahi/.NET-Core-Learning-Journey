using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers {
    public class EmployeeController : Controller {
        private readonly ApplicationDbContext _context;

        public EmployeeController (ApplicationDbContext context) {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index () {
            return View (await _context.Employee.ToListAsync ());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var employees = await _context.Employee
                .FirstOrDefaultAsync (m => m.Id == id);
            if (employees == null) {
                return NotFound ();
            }

            return View (employees);
        }

        // GET: Employee/Create
        public IActionResult Create () {
            if (User.Identity.IsAuthenticated) {
                return View ();
            } else {
                return RedirectToAction (actionName: "Index");
            }
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Name,City,Department,Salary")] Employees employees) {
            if (ModelState.IsValid) {
                _context.Add (employees);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (employees);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var employees = await _context.Employee.FindAsync (id);
            if (employees == null) {
                return NotFound ();
            }
            return View (employees);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("Id,Name,City,Department,Salary")] Employees employees) {
            if (id != employees.Id) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (employees);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!EmployeesExists (employees.Id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (employees);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var employees = await _context.Employee
                .FirstOrDefaultAsync (m => m.Id == id);
            if (employees == null) {
                return NotFound ();
            }

            return View (employees);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var employees = await _context.Employee.FindAsync (id);
            _context.Employee.Remove (employees);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool EmployeesExists (int id) {
            return _context.Employee.Any (e => e.Id == id);
        }
    }
}