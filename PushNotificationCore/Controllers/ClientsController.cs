using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PushNotificationCore.Data;
using PushNotificationCore.Models;

namespace PushNotificationCore.Controllers
{
    public class ClientsController : BaseController
    {
        private readonly PushNotifyDbContext _context;

        public ClientsController(PushNotifyDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

       

        // GET: Clients/Create
        public IActionResult Create()
        {
            MessageInfo("Your about to create a client");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SimularException")] Client Client)
        {
            if (ModelState.IsValid)
            {
                if(!Client.SimularException){
                    _context.Add(Client);
                    await _context.SaveChangesAsync();                
                    MessageSuccess("Registred Successfuly !");
                }
                else{
                    MessageError("Exception !"); 
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(Client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Client = await _context.Clients.FindAsync(id);
            if (Client == null)
            {
                return NotFound();
            }
            return View(Client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SimularException")] Client Client)
        {
            if (id != Client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(Client.Id))
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
            return View(Client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Client == null)
            {
                return NotFound();
            }

            return View(Client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(Client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
