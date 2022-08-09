using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppListaSupermercado.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double ValorEstimado { get; set; }
        public double TotalEstimado { get => Quantidade * ValorEstimado; }
        public double? ValorReal { get; set; }
        public double? TotalReal { get => Quantidade * ValorReal; }


        private int _comprado;

        public int Comprado 
        { 
            get
            {
                return _comprado;
               //return (_comprado == 0) ? false : true;
            }

            set
            {
                _comprado = value;
               // _comprado = (value = 0) ? false : true;
            }
        }
    }
}
