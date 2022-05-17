﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppListaSupermercado.Helper;
using System.IO;

namespace AppListaSupermercado
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.ListaProdutos());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
