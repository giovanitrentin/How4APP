using App666.Controller;
using App666.Model;
using Newtonsoft.Json;
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
    public partial class CadastroAtividade : ContentPage
    {
        private WebAPI _login;

        public Atividade _atividade { get; private set; }
        public Cliente _clienteSelecionado { get; private set; }
        public List<Cliente> _listaCliente { get; private set; }

        public CadastroAtividade(WebAPI login, Atividade atividade)
        {            
            _login = login;
            _atividade = atividade;
            if (_atividade.id == 0)
            {
                _atividade.dataContato = DateTime.Now;
                _atividade.dataRetorno = DateTime.Now;
            }
            _listaCliente = new ClienteController().getLista(_login);
            if (_atividade != null && _atividade.idCliente > 0)
            {
                foreach (Cliente item in _listaCliente)
                {
                    if (item.id == _atividade.idCliente)
                    {
                        _clienteSelecionado = item;
                    }
                }
            }

            InitializeComponent();

            BindingContext = this;
        }

        private void OnButtonClickedCliente(object sender, EventArgs e)
        {
            _clienteSelecionado = (Cliente)PickerCtl.SelectedItem;
            _atividade.idCliente = _clienteSelecionado.id;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            //PUT, //Atualiza --- POST, //Insert
            if (_atividade.id == 0)
            {
                string mensagem = _login.ChamadaHttp(WebAPI.Chamada.POST, "Atividade", JsonConvert.SerializeObject(_atividade));
                if (mensagem.Contains("ERRO"))
                {
                    
                }
                else
                {
                    Navigation.PushAsync(new ListaAtividade(_login));
                }
            }
            else
            {
                string mensagem = _login.ChamadaHttp(WebAPI.Chamada.PUT, "Atividade", JsonConvert.SerializeObject(_atividade));
                if (mensagem.Contains("ERRO"))
                {

                }
                else
                {
                    Navigation.PushAsync(new ListaAtividade(_login));
                }
            }
        }
    }
}