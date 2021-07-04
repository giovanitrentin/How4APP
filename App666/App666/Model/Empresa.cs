using System;

namespace App666.Model
{
    public class Empresa 
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int usuarioCriacao { get; set; }
        public int usuarioAlteracao { get; set; }
        public bool isAtivo { get; set; }
        public string razaoSocial { get; set; }
        public int idEndereco { get; set; }
        public string cnpj { get; set; }
        public string telefone { get; set; }
        public string webSite { get; set; }
        public string email { get; set; }

    }
}
