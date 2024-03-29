﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppListaSupermercado.Model;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutos : ContentPage
    {
        ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();

        public ListaProdutos()
        {
            InitializeComponent();

            lista_produtos.ItemsSource = produtos;
        }

        protected override void OnAppearing()
        {
            if(produtos.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Produto> temp = await App.Database.GetAllRows();

                    foreach (Produto item in temp)
                    {
                        produtos.Add(item);
                    }

                    atualizando.IsRefreshing = false;
                });

                lista_produtos.ItemsSource = produtos;
            }        
            
        }

        // Método que é acionado quando clica no botão de "Novo"
        private void Btn_NovoProduto_Clicked(object sender, EventArgs e)
        {
            // Redireciona para a página de adicionar produto
            Navigation.PushAsync(new FormularioCadastro());
        }

        private async void Btn_Remover_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();

            MenuItem item_clicado = (MenuItem)sender;

            Produto produto_selecionado = (Produto)item_clicado.BindingContext;

            bool confirmacao = await DisplayAlert("Confirmação", "Deseja excluir o produto da lista?", "Sim", "Não");

            if (confirmacao == true)
            {
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    await App.Database.Delete(produto_selecionado.Id);

                    List<Produto> temp = await App.Database.GetAllRows();

                    foreach (Produto produto in temp)
                    {
                        produtos.Add(produto);
                    }

                    atualizando.IsRefreshing = false;
                });

                lista_produtos.ItemsSource = produtos;
            }
        }

        private void lista_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Produto produto_selecionado = (Produto)e.SelectedItem;

            Navigation.PushAsync(new AbrirProduto
            {
                BindingContext = produto_selecionado
            });
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                CheckBox item_clicado = (CheckBox)sender;

                Produto produto_selecionado = (Produto)item_clicado.BindingContext;

                await App.Database.UpdateComprado(produto_selecionado);

            }catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
            
        }

        private void atualizando_Refreshing(object sender, EventArgs e)
        {
            try
            {
               // Console.WriteLine("Chamou para atualizar.");


                System.Threading.Tasks.Task.Run(async () =>
                {
                    //Console.WriteLine("Dentro da Thread");

                    List<Produto> temp = await App.Database.GetAllRows();

                    //Console.WriteLine("Retornou do SQlite = " + temp.Count);

                    produtos = new ObservableCollection<Produto>();

                    foreach (Produto item in temp)
                    {
                        produtos.Add(item);
                    }

                    atualizando.IsRefreshing = false;
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro aqui", ex.Message, "Ok");
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                atualizando.IsRefreshing = true;
                string busca = e.NewTextValue;

                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Produto> temp = await App.Database.Search(busca);

                    produtos = new ObservableCollection<Produto>();

                    foreach (Produto item in temp)
                    {
                        produtos.Add(item);
                    }
                    atualizando.IsRefreshing = false;
                });
            }catch(Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
            
        }
    }
}