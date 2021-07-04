using System;

namespace App666.Model
{
    public class Atividade
    {

        public int id { get; set; }
        public int idCliente { get; set; }
        public int idVendedor { get; set; }
        public int idStatus { get; set; }
        public int idTipoContato { get; set; }
        public DateTime dataContato { get; set; }
        public string descricaoContato { get; set; }
        public DateTime dataRetorno { get; set; }
        public DateTime dataProximoContato { get; set; }
        public bool isContatoFinalizado { get; set; }
        public string nome { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int usuarioCriacao { get; set; }
        public int usuarioAlteracao { get; set; }
        public bool isAtivo { get; set; }
        public int idContatoCliente { get; set; }
    }
}
