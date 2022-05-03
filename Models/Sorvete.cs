using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSorveteria.Models
{
    public class Sorvete
    {
        public int SorveteId { get; set; }
        public string Sabor { get; set; }
        public double Valor { get; set; }
        public float Peso { get; set; }
        public bool Copo { get; set; }
        public int PedidoId { get; set; }   
        public Pedido Pedido { get; set; }
    }
}