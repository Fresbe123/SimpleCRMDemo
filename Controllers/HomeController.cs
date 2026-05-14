using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CRMDemo.Data;
using CRMDemo.Models;

namespace CRMDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.CustomerCount = await _context.Customers.CountAsync();
        ViewBag.OpportunityCount = await _context.Opportunities.CountAsync();
        ViewBag.PipelineValue = await _context.Opportunities
            .Where(o => o.Stage != OpportunityStage.ClosedLost
                     && o.Stage != OpportunityStage.ClosedWon)
            .Select(o => (double)o.Value)
            .SumAsync();

        ViewBag.RecentOpportunities = await _context.Opportunities
            .Include(o => o.Customer)
            .OrderByDescending(o => o.CreatedAt)
            .Take(5)
            .ToListAsync();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}