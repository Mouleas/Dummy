using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Dao;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptModelsController : ControllerBase
    {
        private readonly UserDbContext _context;

        public DeptModelsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/DeptModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeptModel>>> GetDeptModel()
        {
          if (_context.DeptModel == null)
          {
              return NotFound();
          }
            return await _context.DeptModel.ToListAsync();
        }

        // GET: api/DeptModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeptModel>> GetDeptModel(int id)
        {
          if (_context.DeptModel == null)
          {
              return NotFound();
          }
            var deptModel = await _context.DeptModel.FindAsync(id);

            if (deptModel == null)
            {
                return NotFound();
            }

            return deptModel;
        }

        // PUT: api/DeptModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeptModel(int id, DeptModel deptModel)
        {
            if (id != deptModel.DeptId)
            {
                return BadRequest();
            }

            _context.Entry(deptModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptModelExists(id))
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

        // POST: api/DeptModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeptModel>> PostDeptModel([FromBody] DeptModelDao deptModelDao)
        {
            DeptModel deptModel = new()
            {
                DeptName = deptModelDao.DeptName,
            };
          if (_context.DeptModel == null)
          {
              return Problem("Entity set 'UserDbContext.DeptModel'  is null.");
          }
            _context.DeptModel.Add(deptModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeptModel", new { id = deptModel.DeptId }, deptModel);
        }

        // DELETE: api/DeptModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeptModel(int id)
        {
            if (_context.DeptModel == null)
            {
                return NotFound();
            }
            var deptModel = await _context.DeptModel.FindAsync(id);
            if (deptModel == null)
            {
                return NotFound();
            }

            _context.DeptModel.Remove(deptModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptModelExists(int id)
        {
            return (_context.DeptModel?.Any(e => e.DeptId == id)).GetValueOrDefault();
        }
    }
}
