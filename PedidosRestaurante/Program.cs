using System;

namespace PedidosRestaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            string descricaoItem;
            int quantidade;
            decimal precoUnitario;
            char registrarPedido = 'N';
            Pedido pedido = new Pedido();

            Console.WriteLine("Bem vindo ao Restaurante Dot Net!!!!");
            Console.WriteLine("Entre com as informacoes dos itens do seu pedido: ");

            do
            {
                Console.Write("Item: ");
                descricaoItem = Console.ReadLine();
                Console.Write("Preco Unitario: R$");
                precoUnitario = decimal.Parse(Console.ReadLine());
                Console.Write("Quantidade: ");
                quantidade = int.Parse(Console.ReadLine());
                pedido.AdicionarPedido(new ItemPedido(descricaoItem, precoUnitario, quantidade));

                Console.WriteLine();
                Console.Write("Deseja adicionar mais itens ao seu pedido (s/n)?");
                registrarPedido = char.Parse(Console.ReadLine().ToUpper());

            } while (registrarPedido == 'S');
  
            Console.WriteLine();
            Console.WriteLine(pedido);
        }
    }
}
