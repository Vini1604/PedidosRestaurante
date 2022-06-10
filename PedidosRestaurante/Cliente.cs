using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosRestaurante
{
    class Cliente
    {
        public int CodigoCliente { get; set; }
        public string Nome { get; set; }

        public Cliente()
        {
        }

        public Cliente(int codigoCliente, string nome)
        {
            CodigoCliente = codigoCliente;
            Nome = nome;
        }

    }
}
