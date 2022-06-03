using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosRestaurante
{
    class ItemPedido
    {
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public ItemPedido(string descricao, decimal valorUnitario, int quantidade)
        {
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return $"Item: {Descricao}, Valor Unitario: R${ValorUnitario:F2}, Quantidade: {Quantidade}";
        }
    }
}
