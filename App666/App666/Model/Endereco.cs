using System;

namespace App666.Model
{
    public class Endereco 
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int usuarioCriacao { get; set; }
        public int usuarioAlteracao { get; set; }
        public bool isAtivo { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }

    }
}
