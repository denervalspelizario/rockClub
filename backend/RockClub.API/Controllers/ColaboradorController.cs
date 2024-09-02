using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockClub.API.Controllers
{
    [Route("rockclub/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        [HttpPost]
        [Route("adicionarColaborador/")]
        public async Task<ActionResult> AdicaoColaborador()
        {
            return Ok();
        }
    }
}
