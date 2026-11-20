using Microsoft.AspNetCore.Mvc;

namespace Contoso.Api.Controllers;

// With Microsoft.AspNetCore.Mvc.Versioning 5.1.0, the attribute ApiVersion
// is in the namespace Microsoft.AspNetCore.Mvc. With Asp.Versioning.Mvc 8.1.0,
// it is in the namespace Asp.Versioning. Renovate does not change this file.
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/orders")]
public class OrdersController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult Get(int id) => Ok(new { id });
}
