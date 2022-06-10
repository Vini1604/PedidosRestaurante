using PedidosRestaurante.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosRestaurante
{
    class Pedido
    {
        private List<ItemPedido> _itensPedido;
        public int CodigoPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataCancelamento { get; set; }
        public Cliente Cliente { get; set; }
        public Recebimento Recebimento { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public FormaPagamentoEnum Pagamento { get; set; }
        public Pedido(int codigoPedido, Cliente cliente)
        {
            Cliente = cliente;
            CodigoPedido = codigoPedido;
            _itensPedido = new List<ItemPedido>();
            DataPedido = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
            StatusPedido = StatusPedidoEnum.Novo;
            Pagamento = FormaPagamentoEnum.APagar;
        }
        public void AdicionarItemPedido(ItemPedido pedido)
        {
            _itensPedido.Add(pedido);
        }
        public decimal CalculaCustoPedido()
        {
            decimal custoPedido = 0;
            foreach (ItemPedido itemPedido in _itensPedido)
                custoPedido += itemPedido.ValorUnitario * itemPedido.Quantidade;
            
            return custoPedido;
        }

        public void PagarAVista()
        {
            StatusPedido = StatusPedidoEnum.Pago;
            Pagamento = FormaPagamentoEnum.AVista;
        }

        public void PagarParcelado(int parcela)
        {
            StatusPedido = StatusPedidoEnum.Pago;
            Pagamento = FormaPagamentoEnum.Parcelado;
            DataRecebimento = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
            Recebimento = new Recebimento(this, parcela);
        }
        public override string ToString()
        {
            StringBuilder notaPedido = new StringBuilder();
            notaPedido.AppendLine($"Pedido {CodigoPedido} Cliente {Cliente.Nome} Valor Total: {CalculaCustoPedido():F2}, Data do Pedido: {DataPedido.ToString("dd/MM/yyyy HH:mm:ss")}");
            notaPedido.AppendLine($"Status: {StatusPedido}");
            if (StatusPedido == StatusPedidoEnum.Pago)
            {
                notaPedido.AppendLine($"Forma de Pagamento: {Pagamento}");
                if (Pagamento == FormaPagamentoEnum.Parcelado)
                    notaPedido.AppendLine($"{Recebimento}");

            }
            notaPedido.AppendLine("Itens");
            foreach (var itemPedido in _itensPedido)
                notaPedido.AppendLine($"{itemPedido}");
            
            return notaPedido.ToString();


        }
    }
}
