using App666.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App666.Controller
{
    public class WebAPI
    {
        public string link = "https://bsite.net/giovanitrentin/";
        //public string link = "http://localhost:5000/";
        public Token token { get; set; }
        public Login login { get; set; }
        public string mensagemDeErro { get; set; }
        public bool mostraMensagemErro { get; set; }

        public WebAPI()
        {
            mensagemDeErro = "";
            mostraMensagemErro = false;
            login = new Login();
        }

        public void limpaMensagemDeErro()
        {
            mensagemDeErro = "";
            mostraMensagemErro = false;
        }

        public bool FazLoginNoSistema(string user, string senha)
        {
            Login login = new Login();
            login.login = user;
            login.senha = senha;

            string json = JsonConvert.SerializeObject(login);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //"login": "giovani.trentin",
            //"senha": "123456",
            string retorno = ChamadaHttp(Chamada.POST, "Vendedor/Login", json);

            if (!retorno.Equals("ERRO"))
            {
                token = JsonConvert.DeserializeObject<Token>(retorno);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetHttp(string entidade, string id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("token", token.token);
            System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(link + entidade + (id.Equals("") ? "" : "/" + id)).Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "ERRO";
            }
        }

        public string ChamadaHttp(Chamada chamada, string entidade, string json)
        {
            HttpClient httpClient = new HttpClient();
            if (token != null)
            {
                httpClient.DefaultRequestHeaders.Add("token", token.token);
            }
            System.Net.Http.HttpResponseMessage response = null;
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            if (chamada == Chamada.POST) { response = httpClient.PostAsync(link + entidade, httpContent).Result; }
            if (chamada == Chamada.PUT) { response = httpClient.PutAsync(link + entidade, httpContent).Result; }
            // if (chamada == Chamada.DELETE) { response = httpClient.DeleteAsync((link + entidade, httpContent).Result; }

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "ERRO " + response.RequestMessage;
            }
        }

        public enum Chamada
        {
            POST, //Insert
            PUT, //Atualiza
            DELETE
        }

    }
}
