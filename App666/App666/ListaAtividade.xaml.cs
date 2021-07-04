using App666.Controller;
using App666.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App666
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAtividade : ContentPage
    {
        private WebAPI _login;
        public IList<Atividade> listaAtividade { get; private set; }

        public ListaAtividade(WebAPI login)
        {
            _login = login;

            InitializeComponent();

            listaAtividade = new AtividadeController().getLista(_login);
            BindingContext = this;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Atividade selectedItem = e.CurrentSelection[0] as Atividade;
            Navigation.PushAsync(new CadastroAtividade(_login, selectedItem));
        }

        private void OnButtonAdicionarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroAtividade(_login, new Atividade()));
        }
    }
}