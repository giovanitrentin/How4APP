using App666.Controller;
using App666.Model;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App666
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusDados : ContentPage
    {

        public WebAPI _login { get; set; }

        public MeusDados(WebAPI login)
        {
            _login = login;
             
            InitializeComponent();

            BindingContext = this;
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            try 
            {
                string mensagem = _login.ChamadaHttp(WebAPI.Chamada.PUT, "Vendedor", JsonConvert.SerializeObject(_login.token.vendedor));
                if (mensagem.Contains("ERRO"))
                {
                    _login.mensagemDeErro = "Você não pode altear os dados, você está logado! Contate o Admintrador!";
                    _login.mostraMensagemErro = true;
                    Navigation.PushAsync(new MeusDados(_login));
                }
                else
                {
                    _login.mensagemDeErro = "";
                    _login.mostraMensagemErro = false;
                    Navigation.PushAsync(new TelaLogin(null));
                }
            }
            catch  
            {
                _login.mensagemDeErro = "Ocorreu algum erro ao gravar os dados!";
                _login.mostraMensagemErro = true;
                Navigation.PushAsync(new MeusDados(_login));
            }
        }
    }
}