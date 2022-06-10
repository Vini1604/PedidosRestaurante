using PedidosRestaurante.Enums;
using System;
using System.Collections.Generic;


namespace PedidosRestaurante
{
    class Program
    {
        

        static void RegistrarCliente(List<Cliente> clientes)
        {
            Console.Clear();
            Console.WriteLine("1) Registrar Clientes");
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            clientes.Add(new Cliente(clientes.Count + 1, nome));

        }

        static Pedido EncontraPedido(List<Pedido> pedidos)
        {
            Console.WriteLine("Digite o codigo do pedido: ");
            int codigoPedido = int.Parse(Console.ReadLine());
            var pedido = pedidos.Find(x => x.CodigoPedido == codigoPedido);
            return pedido;
        }

        static void AdicionarItensPedido(Pedido pedido)
        {
            char adicionarItens;
            int quantidade;
            string descricao;
            decimal precoUnitario;
            do
            {
                Console.Clear();
                Console.WriteLine("Adicionar itens");
                Console.Write("Descricao do item: ");
                descricao = Console.ReadLine();
                Console.Write("Preco unitario: R$");
                precoUnitario = decimal.Parse(Console.ReadLine());

                do
                {
                    Console.Write("Quantidade: ");
                    quantidade = int.Parse(Console.ReadLine());

                    if (quantidade > 0)
                        pedido.AdicionarItemPedido(new ItemPedido(descricao, precoUnitario, quantidade));
                    
                    else
                        Console.WriteLine("A quantidade deve ser um valor maior que zero!!");
                    
                } while (quantidade <= 0);
                
                
                
                Console.WriteLine("Pressione F para encerrar o pedido ou outra letra para adicionar mais itens");
                adicionarItens = char.Parse(Console.ReadLine().ToUpper());
            } while (adicionarItens != 'F');
            
        }
        
        static void RegistrarPedido(List<Cliente> clientes, List<Pedido> pedidos)
        {
            Console.Clear();
            Console.WriteLine("2) Cadastrar Pedido");

            Console.Write("Digite o Id do cliente para criar um pedido: ");
            int codigoCliente = int.Parse(Console.ReadLine());
            var cliente = clientes.Find(x => x.CodigoCliente == codigoCliente);
            if (cliente != null)
            {
                Pedido pedido = new Pedido(pedidos.Count + 1, cliente);
                pedidos.Add(pedido);
                AdicionarItensPedido(pedido);
            }
            else
            {
                Console.WriteLine("Nao ha cliente com este codigo");
                Console.ReadKey();
            }

        }

        static bool VerificaStatusPedido(Pedido pedido)
        {
            if (pedido != null && pedido.StatusPedido == StatusPedidoEnum.Novo)
                return true;
       
            else 
            {
                if (pedido != null && pedido.StatusPedido == StatusPedidoEnum.Pago)
                    Console.WriteLine("Este pedido ja esta pago");

                else if (pedido != null && pedido.StatusPedido == StatusPedidoEnum.Cancelado)
                    Console.WriteLine("Este pedido foi cancelado");
               
                else
                    Console.WriteLine("Nao ha pedidos com este codigo");

                Console.ReadKey();
                return false;
            }
            
        }

        static void PagarAvista(Pedido pedido)
        {
            pedido.PagarAVista();
        }

        static void PagarParcelado(Pedido pedido)
        {
            Console.WriteLine("Digite a quantidade de Parcelas: ");
            int parcelas = int.Parse(Console.ReadLine());

            if (parcelas > 0)
                pedido.PagarParcelado(parcelas);
            
            else
                Console.WriteLine("O numero de parcelas deve ser maior que zero!!");

        }
        static void ReceberPagamento(List<Pedido> pedidos)
        {

            FormaPagamentoEnum formaPagamento;

            Console.Clear();
            Console.WriteLine("3) ReceberPagamento");
            var pedido = EncontraPedido(pedidos);
            bool statusPedido = VerificaStatusPedido(pedido);
            if (statusPedido)
            {
                
                do
                {
                    Console.Clear();
                    Console.WriteLine("3.1) 1 - Pagamento a vista: ");
                    Console.WriteLine("3.2) 2 - Pagamento a prazo: ");
                    Console.WriteLine("6 - Sair: ");
                    formaPagamento = Enum.Parse<FormaPagamentoEnum>(Console.ReadLine());
                    switch (formaPagamento)
                    {
                        case FormaPagamentoEnum.AVista:
                            PagarAvista(pedido);
                            break;
                        case FormaPagamentoEnum.Parcelado:
                            PagarParcelado(pedido);
                            break;
                        case FormaPagamentoEnum.CancelarPagamento:
                            break;
                        default:
                            formaPagamento = FormaPagamentoEnum.APagar;
                            Console.WriteLine("Valor Invalido!! Digite novamente");
                            Console.ReadKey();
                            break;
                    }
                } while (formaPagamento == FormaPagamentoEnum.APagar);
                
            }
        }

        static void RelatorioPedidos(List<Pedido> pedidos)
        {
            Console.Clear();
            Console.WriteLine("4) Relatorio Pedidos");
            foreach (var pedido in pedidos)
            {
                Console.WriteLine(pedido);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static bool VerificaCancelamento(Pedido pedido)
        {
            if (pedido != null && pedido.StatusPedido == StatusPedidoEnum.Novo)
                return true;
               
            else
            {
                if (pedido != null && pedido.StatusPedido == StatusPedidoEnum.Pago)
                    Console.WriteLine("Este pedido ja foi pago");

                else if (pedido != null && pedido.StatusPedido == StatusPedidoEnum.Cancelado)
                    Console.WriteLine("Este pedido ja foi cancelado");

                else
                    Console.WriteLine("Nao ha pedidos com este codigo");

                Console.ReadKey();
                return false;
            }
        }
        static void CancelarPedido(List<Pedido> pedidos)
        {

            Console.Clear();
            Console.WriteLine("5) Cancelar Pedido");
            var pedido = EncontraPedido(pedidos);
            bool statusPedido = VerificaCancelamento(pedido);
            if (statusPedido)
            {
                pedido.StatusPedido = StatusPedidoEnum.Cancelado;
                pedido.DataCancelamento = DateTime.Now;
            }
            
        }

        static void SelecionaOpcao(int opcaoMenuPrincipal, List<Cliente> clientes, List<Pedido> pedidos)
        {   
            switch (opcaoMenuPrincipal)
            {
                case 1:
                    RegistrarCliente(clientes);
                    break;
                case 2:
                    RegistrarPedido(clientes, pedidos);
                    break;
                case 3:
                    ReceberPagamento(pedidos);
                    break;
                case 4:
                    RelatorioPedidos(pedidos);
                    break;
                case 5:
                    CancelarPedido(pedidos);
                    break;
                case 6:
                    Console.WriteLine("Obrigado por utilizar o servico!!!");
                    break;
                
                default:
                    Console.WriteLine("Nao ha opcoes para o numero digitado!! Digite novamente");
                    Console.ReadKey();
                    break;
            }
        }

        static void Main(string[] args)
        {
            int opcaoMenuPrincipal;
            List<Pedido> pedidos = new List<Pedido>();
            List<Cliente> clientes = new List<Cliente>();
            do
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao Restaurante Dot Net!!!!");
                Console.WriteLine("Escolha uma das opcoes abaixo: ");
                Console.WriteLine("1 - Cadastrar Cliente: ");
                Console.WriteLine("2 - Cadastrar pedido: ");
                Console.WriteLine("3 - Receber Pagamento: ");
                Console.WriteLine("4 - Relatorio dos pedidos: ");
                Console.WriteLine("5 - Cancelar Pedido: ");
                Console.WriteLine("6 - sair do sistema: ");

                opcaoMenuPrincipal = int.Parse(Console.ReadLine());
                SelecionaOpcao(opcaoMenuPrincipal, clientes, pedidos);

            } while (opcaoMenuPrincipal != 6);
        }
    }
}
