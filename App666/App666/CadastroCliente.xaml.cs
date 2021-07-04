using App666.Controller;
using App666.Model;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App666
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroCliente : ContentPage
    {
        public WebAPI _login { get; private set; }
        public Cliente _cliente { get; private set; }

        public CadastroCliente(WebAPI login, Cliente cliente)
        {
            _login = login;
            _cliente = cliente;
            InitializeComponent();

            BindingContext = cliente;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            try
            {
                //PUT, //Atualiza --- POST, //Insert
                if (_cliente.id == 0)
                {
                    string mensagem = _login.ChamadaHttp(WebAPI.Chamada.POST, "Cliente", JsonConvert.SerializeObject(_cliente));
                    if (mensagem.Contains("ERRO"))
                    {
                        _login.mensagemDeErro = "Ocorreu algum erro ao atualizar os dados!";
                        _login.mostraMensagemErro = true;
                        Navigation.PushAsync(new CadastroCliente(_login, _cliente));
                    }
                    else
                    {
                        Navigation.PushAsync(new ListaCliente(_login));
                    }
                }
                else
                {
                    string mensagem = _login.ChamadaHttp(WebAPI.Chamada.PUT, "Cliente", JsonConvert.SerializeObject(_cliente));
                    if (mensagem.Contains("ERRO"))
                    {
                        _login.mensagemDeErro = "Ocorreu algum erro ao atualizar os dados!";
                        _login.mostraMensagemErro = true;
                        Navigation.PushAsync(new CadastroCliente(_login, _cliente));
                    }
                    else
                    {
                        Navigation.PushAsync(new ListaCliente(_login));
                    }
                }
            }
            catch (Exception)
            {
                _login.mensagemDeErro = "Ocorreu algum erro ao atualizar os dados!";
                _login.mostraMensagemErro = true;
                Navigation.PushAsync(new CadastroCliente(_login, _cliente));
            }
        }
    }
}