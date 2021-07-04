using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using App666.Controller;
using Xamarin.Forms;
using App666.Model;
using System;

namespace App666
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCliente : ContentPage
    {
        private WebAPI _login;

        public IList<Cliente> _listaClientes { get; private set; }

        public ListaCliente(WebAPI login)
        {
            _login = login;
            _listaClientes = new ClienteController().getLista(_login);

            InitializeComponent();

            BindingContext = this;
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente selectedItem = e.CurrentSelection[0] as Cliente;
            Navigation.PushAsync(new CadastroCliente(_login, selectedItem));
        }

        private void OnButtonAdicionarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroCliente(_login, new Cliente()));            
        }
    }
}