﻿using System;
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
            int comprado = (chk_comprado.IsChecked) ? 1 : 0;

            Produto p = new Produto
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                ValorEstimado = Convert.ToDouble(txt_valor_estimado.Text),
                ValorReal = Convert.ToDouble(txt_valor_real.Text),
                Comprado = comprado
            };

            await App.Database.Update(p);

            await DisplayAlert("Sucesso", "Atualizado no SQLite", "OK");

            await Navigation.PushAsync(new ListaProdutos());
        }
    }
}