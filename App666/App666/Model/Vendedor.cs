using System;

namespace App666.Model
{
    public class Vendedor 
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int usuarioCriacao { get; set; }
        public int usuarioAlteracao { get; set; }
        public bool isAtivo { get; set; }
        public int idEmpresa { get; set; }
        public DateTime nascimento { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

    }
}
