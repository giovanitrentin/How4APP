using System;
using System.Collections.Generic;

namespace App666.Model
{
    public class Cliente  
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime? dataCriacao { get; set; }
        public DateTime? dataAlteracao { get; set; }
        public int usuarioCriacao { get; set; }
        public int usuarioAlteracao { get; set; }
        public bool isAtivo { get; set; }
        public string razaoSocial { get; set; }
        public int tipoDocumento { get; set; }
        public string documento { get; set; }
        public int idEndereco { get; set; }
        public string telefone { get; set; }
        public string webSite { get; set; }
        public string email { get; set; }
        public DateTime? fundacao { get; set; }
    }
}
