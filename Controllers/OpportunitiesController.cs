using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRMDemo.Data;
using CRMDemo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDemo.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opportunities - Lista todas as oportunidades com seus clientes
        public async Task<IActionResult> Index()
        {
            var opportunities = await _context.Opportunities
                .Include(o => o.Customer)
                .ToListAsync();
            return View(opportunities);
        }

        // GET: Pipeline View 
        public async Task<IActionResult> Pipeline()
        {
            var opportunities = await _context.Opportunities
                .Include(o => o.Customer)
                .ToListAsync();

            return View(opportunities);
        }

        // GET: Opportunities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // GET: Opportunities/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new Microsoft.AspNetCore.Mvc.Rendering
                .SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Opportunities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Value,Stage,ExpectedCloseDate,CustomerId")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                opportunity.CreatedAt = DateTime.Now;
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new Microsoft.AspNetCore.Mvc.Rendering
                .SelectList(_context.Customers, "Id", "Name", opportunity.CustomerId);
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new Microsoft.AspNetCore.Mvc.Rendering
                .SelectList(_context.Customers, "Id", "Name", opportunity.CustomerId);
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Value,Stage,ExpectedCloseDate,CustomerId,CreatedAt")] Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.Id))
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
            ViewData["CustomerId"] = new Microsoft.AspNetCore.Mvc.Rendering
                .SelectList(_context.Customers, "Id", "Name", opportunity.CustomerId);
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunities
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity != null)
            {
                _context.Opportunities.Remove(opportunity);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunities.Any(e => e.Id == id);
        }

        // POST: Update Stage 
        [HttpPost]
        public async Task<IActionResult> UpdateStage(int id, OpportunityStage newStage)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                return NotFound();
            }

            opportunity.Stage = newStage;
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}