using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppListaSupermercado.Model;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbrirProduto : ContentPage
    {
        public AbrirProduto()
        {
            InitializeComponent();
        }

        private async void Btn_Salvar_Clicked(object sender, EventArgs e)
        {
            Produto p = new Produto
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                ValorEstimado = Convert.ToDouble(txt_valor_estimado.Text),
                TotalEstimado = Convert.ToDouble(txt_valor_estimado.Text) * Convert.ToDouble(txt_quantidade.Text),
                ValorReal = Convert.ToDouble(txt_valor_real.Text),
                TotalReal = Convert.ToDouble(txt_valor_real.Text) * Convert.ToDouble(txt_quantidade.Text),
                Comprado = chk_comprado.IsChecked
            };

            await App.Database.Update(p);

            await DisplayAlert("Sucesso", "Atualizado no SQLite", "OK");

            await Navigation.PushAsync(new ListaProdutos());
        }
    }
}