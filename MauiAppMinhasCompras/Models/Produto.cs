using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _description;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {
            get => _description;
            set { if (value == null)
                {
                    throw new Exception("Description cannot be null");
                }
             }

        }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get => Quantity * (double)Price; }
        public DateTime DataCadastro
        {
            get; set;
        }
    }
}
