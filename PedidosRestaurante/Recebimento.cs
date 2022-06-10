using System;
using System.Text;

namespace PedidosRestaurante
{
    class Recebimento
    {
        private Pedido _pedido;
        public decimal ValorParcela { get; set; }
        public int Parcela { get; set; }
        public DateTime DataVencimento { get; set; }


        public Recebimento(Pedido pedido ,int parcela)
        {
            Parcela = parcela;
            _pedido = pedido;
            ValorParcela = pedido.CalculaCustoPedido() / Parcela;
        }

        public override string ToString()
        {
            StringBuilder datasVencimento = new StringBuilder();
            datasVencimento.AppendLine("valor da parcela\t\tparcela\t\tdataVencimento");
            for (int i = 1; i <= Parcela; i++)
            {
                DataVencimento = _pedido.DataRecebimento.AddDays(30 * i);
                datasVencimento.AppendLine($"{ValorParcela:F2}\t\t\t\t{i}\t\t{DataVencimento:dd/MM/yyyy}");
            }
            return datasVencimento.ToString();
        }


    }
}
