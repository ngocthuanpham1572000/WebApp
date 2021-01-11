using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiSPController : Controller
    {
        private readonly EcommerceDB _context;

        public LoaiSPController(EcommerceDB context)
        {
            _context = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.ListLSP = _context.LoaiSP.ToList();
            base.OnActionExecuted(context);
        }

        // GET: Admin/LoaiSP
        public async Task<IActionResult> Index(int? id)
        {
            LoaiSP loaiSP = null;
            if (id != null)
            {
                loaiSP = await _context.LoaiSP
                    .FirstOrDefaultAsync(m => m.MaLoai == id);

            }
            return View(loaiSP);
        }

        // GET: Admin/LoaiSP/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loaiSP = await _context.LoaiSP
        //        .FirstOrDefaultAsync(m => m.MaLoai == id);
        //    if (loaiSP == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(loaiSP);
        //}

        // GET: Admin/LoaiSP/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Admin/LoaiSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,TrangThai")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Admin/LoaiSP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSP = await _context.LoaiSP.FindAsync(id);
            if (loaiSP == null)
            {
                return NotFound();
            }
            return View(loaiSP);
        }

        // POST: Admin/LoaiSP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,TrangThai")] LoaiSP loaiSP)
        {
            if (id != loaiSP.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSPExists(loaiSP.MaLoai))
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
            return View("Index");
        }

        // GET: Admin/LoaiSP/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loaiSP = await _context.LoaiSP
        //        .FirstOrDefaultAsync(m => m.MaLoai == id);
        //    if (loaiSP == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(loaiSP);
        //}

        //// POST: Admin/LoaiSP/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var loaiSP = await _context.LoaiSP.FindAsync(id);
        //    _context.LoaiSP.Remove(loaiSP);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool LoaiSPExists(int id)
        {
            return _context.LoaiSP.Any(e => e.MaLoai == id);
        }
    }
}
