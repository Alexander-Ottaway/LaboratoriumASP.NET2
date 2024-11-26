using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Models.Movies;

namespace WebApp2.Controllers;

[ApiController]
[Route("/api/companies")]
public class MovieApiController: ControllerBase
{
    private readonly MoviesDbContext _context;

    public MovieApiController(MoviesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetFiltered(string fragment)
    {
        return Ok(
            _context.ProductionCompanies.Where(c => c.CompanyName != null && c.CompanyName.Contains(fragment))
                .AsNoTracking()
                .AsAsyncEnumerable()
        );
    }
}