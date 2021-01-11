using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoaiSP_APIController : ControllerBase
    {
        private readonly EcommerceDB _context;

        public LoaiSP_APIController(EcommerceDB context)
        {
            _context = context;
        }

        // GET: api/LoaiSP_API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSP>>> GetLoaiSP()
        {
            return await _context.LoaiSP.ToListAsync();
        }

        // GET: api/LoaiSP_API/5
        [Route("GetLoaiSP/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSP>> GetLoaiSP(int id)
        {
            var loaiSP = await _context.LoaiSP.FindAsync(id);

            if (loaiSP == null)
            {
                return NotFound();
            }

            return loaiSP;
        }

        // PUT: api/LoaiSP_API/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("PutLoaiSP/{id}")]
        [HttpPut("{id}")]
      

        public async Task<IActionResult> PutLoaiSP(int id,[FromBody] LoaiSP loaiSP)
        {
            if (id != loaiSP.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loaiSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSPExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoaiSP_API
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoaiSP>> PostLoaiSP(LoaiSP loaiSP)
        {
            _context.LoaiSP.Add(loaiSP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSP", new { id = loaiSP.MaLoai }, loaiSP);
        }

        // DELETE: api/LoaiSP_API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiSP>> DeleteLoaiSP(int id)
        {
            var loaiSP = await _context.LoaiSP.FindAsync(id);
            if (loaiSP == null)
            {
                return NotFound();
            }

            _context.LoaiSP.Remove(loaiSP);
            await _context.SaveChangesAsync();

            return loaiSP;
        }

        private bool LoaiSPExists(int id)
        {
            return _context.LoaiSP.Any(e => e.MaLoai == id);
        }
    }
}
