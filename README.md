# PedidosRestaurante
## Situacao Problema 
Faça um sistema de pedidos de restaurante em um projeto Console, esse sistema será usado pelo GARÇON.

- Criar uma classe "ItemPedido" com as propriedades “descricao”, “valor_unitario” e “quantidade”.
- Criar uma classe "Pedido" com as propriedades codigo, data do pedido, data do recebimento, data do cancelamento e cliente e uma variável privada do tipo lista (List<>) de “ItemPedido” e métodos para incluir item no pedido e para totalizar o pedido – este, retorna um valor Double com o total de todos os itens da lista.
- Criar classe de "Recebimento" com a propriedade valorParcela, parcela, dataVencimento.
- Criar classe de "Cliente" com a propriedade Codigo, Nome.

Inclua também um construtor em "Pedido" para instanciar uma nova lista na propriedade criada.

Crie um programa em que seja possível informar VAÁRIOS itens de um pedido (N..N).

O usuário informa descrição, valor e quantidade.

O que vem depois do // São comentários para ajudar na implementação, NÃO COLOCAR NO MENU.

O sistema deve ser o seguinte menu:
1 - Cadastrar cliente // Cadastro do cliente, o usuário informa o nome e o código do cliente
2 - Criar pedido // O programa solicita o código do cliente e cria o pedido com a situação NOVO e o código do pedido + 1 com base no ultimo criado, após isso o sistema solicita os itens do pedido, informe F para voltar ao menu principal
2 - receber pedido (pagamento) // O sistema deve receber o código do pedido e marcar o pedido como PAGO e deve criar na classe Recebimento um registro caso seja avista, e caso seja a prazo deve ser inserido N linhas com base na quantidade de parcelas que o garçom informar, lembrar de divir o valor pela quantidade de parcelas 
   3.1 - AVISTA
   3.2 - PARCELADO, PEDIR AO GARÇON A QUANTIDADE DE X
   9 - SAIR
5 - Relatório dos pedidos criados // Formato do pedido
                                     Pedido 99 Cliente: XXXXXXXXXXXXXXXXXXXXXXX Valor total: 999.999.999,99 Data do pedido DD/MM/YYYY HH:MM:SS 
                                     Forma de pagamento: Avista
                                     Itens
                                     Descrição              valor Unitário             quantidade
                                     xxxxxxxxxxxxxxxxx      999.999.999,99                  99999
                      

                                     Pedido 99 Cliente: XXXXXXXXXXXXXXXXXXXXXXX Valor total: 999.999.999,99 Data do pedido DD/MM/YYYY HH:MM:SS 
                                     Forma de pagamento: Parcelado
                                                         valor da parcela            parcela       datavencimento
                                                           999.999.999,00               999        dd/mm/yyyy
                                                           999.999.999,00               999        dd/mm/yyyy
                                                           999.999.999,00               999        dd/mm/yyyy
                                     Itens
                                     Descrição              valor Unitário             quantidade
                                     xxxxxxxxxxxxxxxxx      999.999.999,99                  99999

                                     Pedido 99 Cliente: XXXXXXXXXXXXXXXXXXXXXXX Valor total: 999.999.999,99 Data do pedido DD/MM/YYYY HH:MM:SS 
                                     Forma de pagamento: Parcelado
                                                         valor da parcela            parcela       datavencimento
                                                           999.999.999,00               999        dd/mm/yyyy
                                                           999.999.999,00               999        dd/mm/yyyy
                                                           999.999.999,00               999        dd/mm/yyyy
                                     Itens
                                     Descrição              valor Unitário             quantidade
                                     xxxxxxxxxxxxxxxxx      999.999.999,99                  99999
 
6 - cancelar (desistencia) // O sistema solicita o numero do pedido e marca o pedido como CANCELADO
7 - Sair do sistema