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

        [HttpGet("{cpf_cnpj_prestador_servico}")]
        public async Task<ActionResult<nfse>> GetCnpj (string cpf_cnpj_prestador_servico)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var nfse = await connection.QueryFirstAsync<nfse>("select * from NotaFiscal where cpf_cnpj_prestador_servico = @cpf_cnpj_prestador_servico",
             new { cpf_cnpj_prestador_servico = cpf_cnpj_prestador_servico }    );
            return Ok(nfse);
        }
    }
}
