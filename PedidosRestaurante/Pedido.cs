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

        public void ImprimePedido()
        {

            Console.WriteLine("*************** Pedido ***************");
            foreach (ItemPedido pedido in pedidos)
            {
                Console.WriteLine(pedido);
            }
            Console.WriteLine();
            Console.WriteLine($"Valor total do pedido: R${calculaCustoPedido():F2}");
            Console.WriteLine("**************************************");

        }
    }
}
