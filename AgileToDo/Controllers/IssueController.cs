
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgileToDo.Data;
using AgileToDo.Models;
using System.Diagnostics;

namespace AgileToDo
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IssueController> _logger;

        public IssueController(ApplicationDbContext context, ILogger<IssueController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Issue
        public async Task<IActionResult> Index(bool showResolved = false)
        {
            IQueryable<IssueModel> query = _context.IssueModel;

            if (!showResolved)
            {
                query = query.Where(item => !item.Resolved);
            }

            var sortedData = await query.OrderBy(item => item.Deadline).ToListAsync();

            ViewBag.showResolved = showResolved;

            return View(sortedData);
        }

        // GET: Issue/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueModel = await _context.IssueModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issueModel == null)
            {
                return NotFound();
            }

            return View(issueModel);
        }

        // GET: Issue/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedAt,Deadline,Resolved,ResolvedAt")] IssueModel issueModel)
        {
            if (ModelState.IsValid)
            {
                
                issueModel.CreatedBy = User.Identity?.Name;


                issueModel.Id = Guid.NewGuid();
                issueModel.CreatedAt = DateTime.UtcNow;

                _context.Add(issueModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issueModel);
        }

        // GET: Issue/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueModel = await _context.IssueModel.FindAsync(id);
            if (issueModel == null)
            {
                return NotFound();
            }
            return View(issueModel);
        }

        // POST: Issue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,CreatedAt,Deadline,Resolved,ResolvedAt")] IssueModel issueModel)
        {
            if (id != issueModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issueModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueModelExists(issueModel.Id))
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
            return View(issueModel);
        }

        // GET: Issue/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueModel = await _context.IssueModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issueModel == null)
            {
                return NotFound();
            }

            return View(issueModel);
        }

        // POST: Issue/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var IssueModel = await _context.IssueModel.FindAsync(id);
            if (IssueModel != null)
            {
                _context.IssueModel.Remove(IssueModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "CS, Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkResolved(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var IssueModel = await _context.IssueModel
                .FirstOrDefaultAsync(m => m.Id == id);

            if (IssueModel == null)
            {
                return NotFound();
            }

            IssueModel.Resolved = true;
            IssueModel.ResolvedAt = DateTime.UtcNow;
            IssueModel.ResolvedBy = User.Identity?.Name;

            _context.Update(IssueModel);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool IssueModelExists(Guid id)
        {
            return _context.IssueModel.Any(e => e.Id == id);
        }
    }
}

