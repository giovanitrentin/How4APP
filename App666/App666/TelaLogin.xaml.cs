using Xamarin.Forms.Xaml;
using App666.Controller;
using Xamarin.Forms;
using System;

namespace App666
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaLogin : ContentPage
    {
        public WebAPI _webAPI { get; private set; }

        public TelaLogin(WebAPI webAPI)
        {
            _webAPI = webAPI;
            if (_webAPI == null)
            {
                _webAPI = new WebAPI();
                _webAPI.login.login = "giovani.trentin";
                _webAPI.login.senha = "123456";
            }
            
            InitializeComponent();

            BindingContext = this;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            try
            {
                if (_webAPI.FazLoginNoSistema(_webAPI.login.login, _webAPI.login.senha))
                {
                    _webAPI.limpaMensagemDeErro();
                    Navigation.PushAsync(new TelaPrincipal(_webAPI));
                }
                else
                {
                    _webAPI.mensagemDeErro = "Login ou senha errada!!";
                    _webAPI.mostraMensagemErro = true;
                    Navigation.PushAsync(new TelaLogin(_webAPI));
                }
            }
            catch  
            {
                _webAPI.mensagemDeErro = "Ocorreu algum erro ao realizar o Login, verifique sua conexão!";
                _webAPI.mostraMensagemErro = true;
                Navigation.PushAsync(new TelaLogin(_webAPI));
            }
           
        }
    }
}