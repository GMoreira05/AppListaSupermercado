using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppListaSupermercado.Model;
using AppListaSupermercado.Helper;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioCadastro : ContentPage
    {
        public FormularioCadastro()
        {
            InitializeComponent();
        }

        private async void Btn_AddProduto_Clicked(object sender, EventArgs e)
        {
            Produto p = new Produto();
            p.Descricao = txt_Descricao.Text;
            p.ValorEstimado = Convert.ToDouble(txt_ValorEstimado.Text);
            p.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
            p.TotalEstimado = Convert.ToDouble(txt_ValorEstimado.Text) * Convert.ToDouble(txt_Quantidade.Text);

            await App.Database.Insert(p);

            await DisplayAlert("Sucesso", "Produto foi salvo no Banco de Dados", "OK");

            await Navigation.PushAsync(new ListaProdutos());
        }
    }
}