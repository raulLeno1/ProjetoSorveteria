using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSorveteria.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public double Valor { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Sorvete> Sorvetes { get; set; }
    }
}