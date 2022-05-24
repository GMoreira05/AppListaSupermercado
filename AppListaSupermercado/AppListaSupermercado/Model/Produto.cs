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
        public double TotalEstimado { get; set; }
        public double? ValorReal { get; set; }
        public double? TotalReal { get; set; }
        public bool Comprado { get; set; }
    }
}
