using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace nfse_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NfseController : ControllerBase
    {
        private readonly IConfiguration _config;

        public NfseController(IConfiguration config) {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<nfse>>> GetAllNfse()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var nfse = await connection.QueryAsync<nfse>("select * from NotaFiscal");
            return Ok(nfse);
        }
    }
}
