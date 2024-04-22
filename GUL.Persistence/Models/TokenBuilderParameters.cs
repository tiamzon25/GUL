using GUL.Shared.Configuration;
using System.Security.Claims;

namespace Point.Of.Sale.Persistence.Models;

public record TokenBuilderParameters
{
    public List<Claim> Claims { get; set; }
    public PosConfiguration Configuration { get; set; }
    public TimeSpan ExpiresIn { get; set; }
}
