﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutos : ContentPage
    {
        public ListaProdutos()
        {
            InitializeComponent();
        }

        // Método que é acionado quando clica no botão de "Novo"
        private void Btn_NovoProduto_Clicked(object sender, EventArgs e)
        {
            // Redireciona para a página de adicionar produto
            Navigation.PushAsync(new FormularioCadastro());
        }
    }
}