using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetapp.Controllers;

public class ExpressRequest
{
    public int? ClientPhone { get; set; }
}

public class ExpressResponse
{
    public string? ExpressName { get; set; }
    public string? ExpressNumber { get; set; }
}

public class ExpressController : ControllerBase
{
    private readonly ExpressContext _context;

    public ExpressController(ExpressContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<ExpressResponse>> PostExpress(ExpressRequest data)
    {
        if (data.ClientPhone != null)
        {
            var exp = await _context.Expresses.FirstOrDefaultAsync(e => e.ClientPhone == data.ClientPhone.Value);

            if (exp != null)
            {
                return new ExpressResponse
                {
                    ExpressName = exp.ExpressName,
                    ExpressNumber = exp.ExpressNumber,
                };
            }
            else
            {
                return new EmptyResult();
            }
        }
        else
        {
            return BadRequest();
        }
    }
}
