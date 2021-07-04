using App666.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App666.Controller
{
    public class AtividadeController
    {
        public List<Atividade> getLista(WebAPI webAPI)
        {
            //ChamadaHttp(Chamada.PUT, "Atividade", JsonConvert.SerializeObject(item));
            try
            {
                return JsonConvert.DeserializeObject<List<Atividade>>(webAPI.GetHttp("Atividade", ""));
            }
            catch 
            {
                throw;
            }
        }

    }
}
