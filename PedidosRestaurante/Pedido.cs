using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosRestaurante
{
    class Pedido
    {
        private List<ItemPedido> pedidos { get; set; } = new List<ItemPedido>();

        public void AdicionarPedido(ItemPedido pedido)
        {
            pedidos.Add(pedido);
        }

        private decimal calculaCustoPedido ()
        {
            decimal custoTotal = 0;
            foreach (ItemPedido pedido in pedidos)
            {
                custoTotal += pedido.ValorUnitario * pedido.Quantidade;
            }
            return custoTotal;
        }

        public override string ToString()
        {

            decimal valorTotal = calculaCustoPedido();
            string notaPedido = "";
            notaPedido += "*************** Pedido ***************\n";
            foreach (ItemPedido pedido in pedidos)
            {
                notaPedido += $"{pedido}\n";
            }
            notaPedido += $"\nValor total do pedido: R${valorTotal:F2}";
            notaPedido += "\n**************************************";

            return notaPedido;
        }
    }
}
