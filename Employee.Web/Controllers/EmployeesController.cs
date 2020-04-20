using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee.Web.Data;
using Employee.Web.Data.Entities;

namespace Employee.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.Employees.FindAsync(id);
                
            if (employeeEntity == null)
            {
                return NotFound();
            }

            return View(employeeEntity);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( EmployeeEntity employeeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeEntity);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.Employees.FindAsync(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }
            return View(employeeEntity);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  EmployeeEntity employeeEntity)
        {
            if (id != employeeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _context.Update(employeeEntity);
                    await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(employeeEntity);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEntity = await _context.Employees.FindAsync(id);
              
            if (employeeEntity == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
