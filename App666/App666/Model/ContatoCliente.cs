using System;

namespace App666.Model
{
    public class ContatoCliente 
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int usuarioCriacao { get; set; }
        public int usuarioAlteracao { get; set; }
        public bool isAtivo { get; set; }
        public int idCliente { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public DateTime aniversario { get; set; }

    }
}
