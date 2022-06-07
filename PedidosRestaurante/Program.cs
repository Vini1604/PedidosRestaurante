using System;
using System.Collections.Generic;

namespace PedidosRestaurante
{
    class Program
    {
        static decimal PrecoTotalPedidos(List<Pedido> pedidos)
        {
            decimal precoTotal = 0;
            foreach (Pedido pedido in pedidos)
            {
                precoTotal += pedido.CalculaCustoPedido();
            }
            return precoTotal;
        }
        
        
        
        static void Main(string[] args)
        {
            string descricaoItem;
            int quantidade;
            decimal precoUnitario;
            char registrarItemPedido = 'N', registrarPedido = 'N';
            List<Pedido> pedidos = new List<Pedido>();
            decimal precoTotal;

            do
            {
                Console.WriteLine("Bem vindo ao Restaurante Dot Net!!!!");
                Console.WriteLine("Entre com as informacoes dos itens do seu pedido: ");
                Pedido pedido = new Pedido();
                do
                {
                    Console.Write("Item: ");
                    descricaoItem = Console.ReadLine();
                    Console.Write("Preco Unitario: R$");
                    precoUnitario = decimal.Parse(Console.ReadLine());
                    Console.Write("Quantidade: ");
                    quantidade = int.Parse(Console.ReadLine());
                    pedido.AdicionarItemPedido(new ItemPedido(descricaoItem, precoUnitario, quantidade));

                    Console.WriteLine();
                    Console.Write("Deseja adicionar mais itens ao seu pedido (s/n)?");
                    registrarItemPedido = char.Parse(Console.ReadLine().ToUpper());

                } while (registrarItemPedido == 'S');
                
                pedidos.Add(pedido);
                Console.WriteLine();
                Console.WriteLine("Deseja adicionar mais um pedido (s/n)?");
                registrarPedido = char.Parse(Console.ReadLine().ToUpper());
                Console.Clear();

            } while (registrarPedido == 'S');

            foreach (Pedido pedido in pedidos)
            {
                Console.WriteLine(pedido);
            }
            precoTotal = PrecoTotalPedidos(pedidos);
            Console.WriteLine($"Valor total: R${precoTotal:F2}");
        }
    }
}
