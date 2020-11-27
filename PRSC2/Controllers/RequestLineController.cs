using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRSC2.Data;

namespace PRSC2.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLineController : ControllerBase
    {
        private readonly PRSC2Context _context;

        public RequestLineController(PRSC2Context context)
        {
            _context = context;
        }

        // GET: api/RequestLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestLine>>> GetRequestLine()
        {
            
            return await _context.RequestLine.ToListAsync();
            
        }

        // GET: api/RequestLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestLine>> GetRequestLine(int id)
        {
            var requestline = await _context.RequestLine.FindAsync(id);

            if (requestline == null)
            {
                return NotFound();
            }
            await RecalculateTotal(requestline.RequestId, _context.Request.Find(requestline.RequestId));
            return requestline;
        }

        // PUT: api/RequestLine/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestLine(int id, RequestLine requestline)
        {
            if (id != requestline.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestLineExists(id))
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

        // POST: api/RequestLine
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RequestLine>> PostRequestline(RequestLine requestline)
        {
            _context.RequestLine.Add(requestline);
            await _context.SaveChangesAsync();
            await RecalculateTotal(requestline.RequestId, _context.Request.Find(requestline.RequestId));

            return CreatedAtAction("GetRequestLine", new { id = requestline.Id }, requestline);
        }

        private Task RecalculateTotal(int requestId, Request request)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/RequestLine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestLine>> DeleteRequestline(int id)
        {
            var requestline = await _context.RequestLine.FindAsync(id);
            if (requestline == null)
            {
                return NotFound();
            }

            _context.RequestLine.Remove(requestline);
            await _context.SaveChangesAsync();
            await RecalculateTotal(requestline.RequestId, _context.Request.Find(requestline.RequestId));

            return requestline;
        }


        private bool RequestLineExists(int id)
        {
            return _context.RequestLine.Any(e => e.Id == id);
        }
    }
}
