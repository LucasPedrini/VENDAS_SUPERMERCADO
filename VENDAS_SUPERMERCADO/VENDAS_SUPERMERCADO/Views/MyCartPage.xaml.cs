﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENDAS_SUPERMERCADO.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VENDAS_SUPERMERCADO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCartPage : ContentPage
    {
        public MyCartPage()
        {
            InitializeComponent();
        }

        private void pckPagto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            int.TryParse(((Button)sender).BindingContext.ToString(), out var codigo);

            if (codigo == 0)
                return;
            if (MeuCarrinho.Lista == null)
                MeuCarrinho.Lista = new List<ItemsOrder>();
            var produto = MeuCarrinho.Lista.Find(x => x.codigoProduto == codigo);
            if (produto == null)
            {
                var novoProduto = new ItemsOrder();
                novoProduto.codigoProduto = codigo;
                novoProduto.qtde = 1;
                MeuCarrinho.Lista.Add(novoProduto);
                return;
            }
            MeuCarrinho.Lista.Find(x => x.codigoProduto == codigo).qtde++;
        }

        private void OnButtonClicked2(object sender, EventArgs e)
        {
            string data = ((Button)sender).BindingContext as string;
            //    productSelected = sender;
            int.TryParse(((Button)sender).BindingContext.ToString(), out var codigo);

            if (codigo == 0)
                return;
            if (MeuCarrinho.Lista == null)
                return;
            var produto = MeuCarrinho.Lista.Find(x => x.codigoProduto == codigo);
            if (produto == null)
                return;
            var item = MeuCarrinho.Lista.FindIndex(x => x.codigoProduto == codigo);
            if (produto.qtde == 1)
            {
                MeuCarrinho.Lista.RemoveAt(item);
            }
            else
            {
                MeuCarrinho.Lista.Find(x => x.codigoProduto == codigo).qtde--;
            }
        }

        private void OnButtonClicked3(object sender, EventArgs e)
        {
            int.TryParse(((Button)sender).BindingContext.ToString(), out var codigo);

            if (codigo == 0)
                return;
            var item = MeuCarrinho.Lista.FindIndex(x => x.codigoProduto == codigo);

            MeuCarrinho.Lista.RemoveAt(item);

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


        }
    }
}