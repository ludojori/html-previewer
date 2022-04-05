using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using html_previewer_app.Data;
using html_previewer_app.Models;

namespace html_previewer_app.Controllers
{
    public class HtmlCodeSampleModelsController : Controller
    {
        private readonly html_previewer_appContext _context;

        public HtmlCodeSampleModelsController(html_previewer_appContext context)
        {
            _context = context;
        }

        // GET: HtmlCodeSampleModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.HtmlCodeSampleModel.ToListAsync());
        }

        // GET: HtmlCodeSampleModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var htmlCodeSampleModel = await _context.HtmlCodeSampleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (htmlCodeSampleModel == null)
            {
                return NotFound();
            }

            return View(htmlCodeSampleModel);
        }

        // GET: HtmlCodeSampleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HtmlCodeSampleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,CreatedOn,LastModified")] HtmlCodeSampleModel htmlCodeSampleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(htmlCodeSampleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(htmlCodeSampleModel);
        }

        // GET: HtmlCodeSampleModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var htmlCodeSampleModel = await _context.HtmlCodeSampleModel.FindAsync(id);
            if (htmlCodeSampleModel == null)
            {
                return NotFound();
            }
            return View(htmlCodeSampleModel);
        }

        // POST: HtmlCodeSampleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Code,CreatedOn,LastModified")] HtmlCodeSampleModel htmlCodeSampleModel)
        {
            if (id != htmlCodeSampleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(htmlCodeSampleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HtmlCodeSampleModelExists(htmlCodeSampleModel.Id))
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
            return View(htmlCodeSampleModel);
        }

        // GET: HtmlCodeSampleModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var htmlCodeSampleModel = await _context.HtmlCodeSampleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (htmlCodeSampleModel == null)
            {
                return NotFound();
            }

            return View(htmlCodeSampleModel);
        }

        // POST: HtmlCodeSampleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var htmlCodeSampleModel = await _context.HtmlCodeSampleModel.FindAsync(id);
            _context.HtmlCodeSampleModel.Remove(htmlCodeSampleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HtmlCodeSampleModelExists(string id)
        {
            return _context.HtmlCodeSampleModel.Any(e => e.Id == id);
        }
    }
}
