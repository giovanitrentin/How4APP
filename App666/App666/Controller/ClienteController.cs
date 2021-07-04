using App666.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App666.Controller
{
    public class ClienteController
    {
        public List<Cliente> getLista(WebAPI webAPI)
        {
            //ChamadaHttp(Chamada.PUT, "Atividade", JsonConvert.SerializeObject(item));
            try
            {
                return JsonConvert.DeserializeObject<List<Cliente>>(webAPI.GetHttp("Cliente", ""));
            }
            catch 
            {
                throw;
            }
        }
    }
}
