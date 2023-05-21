using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace nfse_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NfseController : ControllerBase
    {
        private readonly IConfiguration _config;

        public NfseController(IConfiguration config) {
            _config = config;
        }
        
        [HttpGet]
        [Route("getNfse")]
        public async Task<ActionResult<List<nfse>>> getNfse()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var nfse = await connection.QueryAsync<nfse>("select * from NotaFiscal");
            return Ok(nfse);
        }
       
        [HttpGet]
        [Route("getCnpj")]
        public async Task<ActionResult<nfse>> GetCnpj (string cpf_cnpj_prestador_servico)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var nfse = await connection.QueryFirstAsync<nfse>("select * from NotaFiscal where cpf_cnpj_prestador_servico = @cpf_cnpj_prestador_servico",
             new { cpf_cnpj_prestador_servico = cpf_cnpj_prestador_servico }    );
            return Ok(nfse);
        }

        [HttpPost]
        [Route("CreateNfse")]
        public async Task<ActionResult<List<nfse>>> CreateNfse(nfse nfse)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("INSERT INTO NotaFiscal (nome_prestador_servico, cpf_cnpj_prestador_servico, inscricao_prestador_servico, nome_tomador_servico, cpf_cnpj_tomador_servico, inscricao_tomador_servico, numero_nfse, data_emissao_nfse, valor_total_nfse, descricao_servico_prestado, valor_unitario_servico, quantidade_unidades_servico, valor_total_servico, ISS, aliquota_iss, valor_iss_pago, Observacoes) values (@nome_prestador_servico, @cpf_cnpj_prestador_servico, @inscricao_prestador_servico, @nome_tomador_servico, @cpf_cnpj_tomador_servico, @inscricao_tomador_servico, @numero_nfse, @data_emissao_nfse, @valor_total_nfse, @descricao_servico_prestado, @valor_unitario_servico, @quantidade_unidades_servico, @valor_total_servico, @ISS, @aliquota_iss, @valor_iss_pago, @Observacoes)",
                nfse);
            return Ok(nfse);
        }

    }
}
