using App666.Controller;
using App666.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App666
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaPrincipal : ContentPage
    {

        private WebAPI _login;

        public TelaPrincipal(WebAPI login)
        {
            _login = login;

            InitializeComponent();
        }

        void OnButtonAtividadesClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ListaAtividade(_login));
        }

        void OnButtonClienteClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ListaCliente(_login));
        }

        void OnButtonMeusDadosClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MeusDados(_login));
        }

        void OnButtonSairClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TelaLogin(null));
        }
    }
}