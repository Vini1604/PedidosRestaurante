using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosRestaurante
{
    class Pedido
    {
        private List<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();

        public Pedido()
        {

        }
        public void AdicionarItemPedido(ItemPedido pedido)
        {
            ItensPedido.Add(pedido);
        }
        public decimal CalculaCustoPedido()
        {
            decimal custoPedido = 0;
            foreach (ItemPedido itemPedido in ItensPedido)
            {
                custoPedido += itemPedido.ValorUnitario * itemPedido.Quantidade;
            }
            return custoPedido;
        }

        /*
        private decimal CalculaCustoTotal()
        {
            decimal custoTotal = 0;
            foreach (Pedido pedido in Pedidos)
            {
                custoTotal += CalculaCustoPedido();
            }
            return custoTotal;
        }
        */

        public override string ToString()
        {

            string notaPedido = "";

            decimal valorPedido = CalculaCustoPedido();
            notaPedido += "*************** Pedido ***************\n";
            foreach (ItemPedido itemPedido in ItensPedido)
            {
                notaPedido += $"{itemPedido}\n";
            }
            notaPedido += $"\nValor total do pedido: R${valorPedido:F2}";
            notaPedido += "\n**************************************";
            notaPedido += "\n";

            return notaPedido;
        }
    }
}
