using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DWAApi.Data;
using DWAApi.Models;

namespace DWAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly UserContext _context;

        public UserInfoController(UserContext context)
        {
            _context = context;
        }

        // GET: UserInfoes
        
        public async Task<IActionResult> Index()
        {
            var userContext = _context.UserInfos.Include(u => u.User);
            return View(await userContext.ToListAsync());
        }

        // GET: UserInfoes/Details/5
        [HttpGet]
        [Route("dick")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UserInfos == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfos
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: UserInfoes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login");
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,SkinColour,EUSizeS,EUSizeT,EUSizeL,CircleHip,CircleChest,CircleCalf,UserId,Id")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.Id = Guid.NewGuid();
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login", userInfo.UserId);
            return View(userInfo);
        }

        // GET: UserInfoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UserInfos == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login", userInfo.UserId);
            return View(userInfo);
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Age,SkinColour,EUSizeS,EUSizeT,EUSizeL,CircleHip,CircleChest,CircleCalf,UserId,Id")] UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Login", userInfo.UserId);
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UserInfos == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfos
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UserInfos == null)
            {
                return Problem("Entity set 'UserContext.UserInfos'  is null.");
            }
            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo != null)
            {
                _context.UserInfos.Remove(userInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(Guid id)
        {
          return (_context.UserInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
