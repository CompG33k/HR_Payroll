using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Payroll.Data;
using HR_Payroll_Library;

namespace HR_Payroll.Controllers
{
    public class DependentsController : Controller
    {
        private readonly HR_PayrollContext _context;

        public DependentsController(HR_PayrollContext context)
        {
            _context = context;
        }

        // GET: Dependents
        public async Task<IActionResult> Index()
        {
            var hR_PayrollContext = _context.Dependent.Include(d => d.Employee);
            return View(await hR_PayrollContext.ToListAsync());
        }

        // GET: Dependents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependent
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // GET: Dependents/Create
        public IActionResult Create()
        {
            ViewData["employeeID"] = new SelectList(_context.Employee, "ID", "ID");
            return View();
        }

        // POST: Dependents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,fname,lname,dcode,employeeID")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                int id = _context.Employee.FirstOrDefault().ID;
                dependent.employeeID = id;
                _context.Add(dependent);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),"Employees",new { ID = id});
            }
            ViewData["employeeID"] = new SelectList(_context.Employee, "ID", "ID", dependent.employeeID);
            return View(dependent);
        }

        // GET: Dependents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependent.FindAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }
            ViewData["employeeID"] = dependent.employeeID;
            return View(dependent);
        }

        // POST: Dependents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,fname,lname,dcode,employeeID")] Dependent dependent)
        {
            if (id != dependent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependentExists(dependent.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { ID = dependent.ID });
            }
            ViewData["employeeID"] = new SelectList(_context.Employee, "ID", "ID", dependent.employeeID);
            return View(dependent);
        }

        // GET: Dependents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependent
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // POST: Dependents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependent = await _context.Dependent.FindAsync(id);
            int? eId = dependent.employeeID;
            _context.Dependent.Remove(dependent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details),"Employees",new { ID = eId });
        }

        private bool DependentExists(int id)
        {
            return _context.Dependent.Any(e => e.ID == id);
        }
    }
}
