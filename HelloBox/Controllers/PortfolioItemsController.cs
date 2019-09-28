using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloBox.Data;
using HelloBox.Models;

namespace HelloBox.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;
        
        public PortfolioItemsController(ApplicationDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _hostingEnvironment = env;
        }

        // GET: PortfolioItems
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(await _context.PortfolioItems.ToListAsync());
            }
            else
            {
                return Redirect ("~/Identity/Account/Login");
            }
        }

        // GET: PortfolioItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (User.Identity.IsAuthenticated){
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = await _context.PortfolioItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
            }
            else
            {
                return Redirect ("~/Identity/Account/Login");
            }
        }

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated){
            return View();
        }
        else
        {
            return Redirect ("~/Identity/Account/Login");
        }
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,DatePublished,PicturePath,Content")] PortfolioItem portfolioItem,IFormFile file)
        {
            if (User.Identity.IsAuthenticated){
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                portfolioItem.PicturePath = Path.Combine(baseUrl + "/uploads/", file.FileName);
                portfolioItem.DatePublished =  DateTime.Now.ToString("dd/MM/yyyy");
                _context.Add(portfolioItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioItem);
            }
            else
            {
            return Redirect ("~/Identity/Account/Login");
            }
        }

        // GET: PortfolioItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }
                
                var portfolioItem = await _context.PortfolioItems.FindAsync(id);
                if (portfolioItem == null)
                {
                    return NotFound();
                }

                return View(portfolioItem);
            }
            else
                {
                    return Redirect ("~/Identity/Account/Login");
                }
        }

        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,DatePublished,PicturePath,Content")] PortfolioItem portfolioItem,IFormFile file)
        {
            if (User.Identity.IsAuthenticated)
            {
            if (id != portfolioItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    portfolioItem.PicturePath = Path.Combine(baseUrl + "/uploads/", file.FileName);
                    portfolioItem.DatePublished =  DateTime.Now.ToString("dd/MM/yyyy");
                    _context.Update(portfolioItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(portfolioItem.Id))
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
            return View(portfolioItem);
            }
            else
            {
                return Redirect ("~/Identity/Account/Login");
            }
        }

        // GET: PortfolioItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = await _context.PortfolioItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
            }
            else
            {
                return Redirect ("~/Identity/Account/Login");
            }
        }

        // POST: PortfolioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
            var portfolioItem = await _context.PortfolioItems.FindAsync(id);
            _context.PortfolioItems.Remove(portfolioItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            else
            {
                return Redirect ("~/Identity/Account/Login");
            }
        }

        private bool PortfolioItemExists(int id)
        {
            return _context.PortfolioItems.Any(e => e.Id == id);
        }
    }
}
