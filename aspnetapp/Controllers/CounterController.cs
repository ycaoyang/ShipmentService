#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CounterRequest
{
    public string Action { get; set; }
}
public class CounterResponse
{
    public int Data { get; set; }
}

namespace aspnetapp.Controllers
{
    [Route("api/count")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ExpressContext _context;

        public CounterController(ExpressContext context)
        {
            _context = context;
        }

        private async Task<Counter> GetCounterWithInit()
        {
            var counters = await _context.Counters.ToListAsync();
            if (counters.Any())
            {
                return counters[0];
            }
            else
            {
                var counter = new Counter { Count = 0, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
                _context.Counters.Add(counter);
                await _context.SaveChangesAsync();
                return counter;
            }
        }

        // GET: api/count
        [HttpGet]
        public async Task<ActionResult<CounterResponse>> GetCounter()
        {
            var counter = await GetCounterWithInit();
            return new CounterResponse { Data = counter.Count };
        }

        // POST: api/Counter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CounterResponse>> PostCounter(CounterRequest data)
        {
            if (data.Action == "inc")
            {
                var counter = await GetCounterWithInit();
                counter.Count += 1;
                counter.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return new CounterResponse { Data = counter.Count };
            }
            else if (data.Action == "clear")
            {
                var counter = await GetCounterWithInit();
                counter.Count = 0;
                counter.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return new CounterResponse { Data = counter.Count };
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
