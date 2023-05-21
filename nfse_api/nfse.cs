namespace nfse_api
{
    public class nfse
    {
        public int id { get; set; }
        public string nome_prestador_servico { get; set; }
        public string cpf_cnpj_prestador_servico { get; set; }
        public string inscricao_prestador_servico { get; set; }
        public string nome_tomador_servico { get; set; }
        public string cpf_cnpj_tomador_servico { get; set; }
        public string inscricao_tomador_servico { get; set;}
        public string numero_nfse { get; set; }
        public string data_emissao_nfse { get; set; }
        public string valor_total_nfse { get; set; }
        public string descricao_servico_prestado { get; set; }
        public string valor_unitario_servico { get; set; }
        public string quantidade_unidades_servico { get; set; }
        public string valor_total_servico { get; set; }
        public string ISS { get; set; }
        public string aliquota_iss { get; set; }
        public string valor_iss_pago { get; set; }
        public string Observacoes {get; set;}

    }
}
