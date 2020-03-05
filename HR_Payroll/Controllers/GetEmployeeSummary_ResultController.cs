using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Payroll.Data;
using HR_Payroll_Library;
using System.Data.Entity;

namespace HR_Payroll.Controllers
{
    public class GetEmployeeSummary_ResultController : Controller
    {
        private readonly HR_PayrollContext _context;

        public GetEmployeeSummary_ResultController(HR_PayrollContext context)
        {
            _context = context;
        }

        // GET: GetEmployeeSummary_Result
        public async Task<IActionResult> Index()
        {
            _context.GetEmployeeSummary_Result = SqlHelper.GetEmployeeSummaryResult(_context.Database.GetDbConnection().ConnectionString);
            return View( _context.GetEmployeeSummary_Result);
        }

        // GET: GetEmployeeSummary_Result/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getEmployeeSummary_Result = await _context.GetEmployeeSummary_Result
                .FirstOrDefaultAsync(m => m.ID == id);
            if (getEmployeeSummary_Result == null)
            {
                return NotFound();
            }

            return View(getEmployeeSummary_Result);
        }

        // GET: GetEmployeeSummary_Result/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetEmployeeSummary_Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,fname,lname,StartDate,benefit_enrolled,Dependents,YearsEmployed")] GetEmployeeSummary_Result getEmployeeSummary_Result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(getEmployeeSummary_Result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(getEmployeeSummary_Result);
        }

        // GET: GetEmployeeSummary_Result/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getEmployeeSummary_Result = await _context.GetEmployeeSummary_Result.Select(x=>x.ID == id).ToListAsync();
            if (getEmployeeSummary_Result == null)
            {
                return NotFound();
            }
            return View(getEmployeeSummary_Result);
        }

        // POST: GetEmployeeSummary_Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,fname,lname,StartDate,benefit_enrolled,Dependents,YearsEmployed")] GetEmployeeSummary_Result getEmployeeSummary_Result)
        {
            if (id != getEmployeeSummary_Result.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(getEmployeeSummary_Result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GetEmployeeSummary_ResultExists(getEmployeeSummary_Result.ID))
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
            return View(getEmployeeSummary_Result);
        }

        // GET: GetEmployeeSummary_Result/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getEmployeeSummary_Result = await _context.GetEmployeeSummary_Result
                .FirstOrDefaultAsync(m => m.ID == id);
            if (getEmployeeSummary_Result == null)
            {
                return NotFound();
            }

            return View(getEmployeeSummary_Result);
        }

        // POST: GetEmployeeSummary_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var getEmployeeSummary_Result = await _context.GetEmployeeSummary_Result.Select(x=>x.ID ==id).ToListAsync();
           // _context.GetEmployeeSummary_Result.FirstOrDefaultAsync(getEmployeeSummary_Result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GetEmployeeSummary_ResultExists(int id)
        {
            return _context.GetEmployeeSummary_Result.Any(e => e.ID == id);
        }
    }
}
