using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backPadaria.Model;
using BackPadaria.Model;

namespace backPadaria.Service
{
    public static class VendaService
    {
        public static void MenuVendas()
        {
            
            bool sair = false;
            while (!sair)
                // enquanto o valor da variavel sair, ele vai repetir
            {
                Console.Clear();

                Console.WriteLine("»»» PDV - Padaria Farinha & Fogo «««\n");
                Console.WriteLine("0 - Voltar ao MENU PRINCIPAL");
                Console.WriteLine("1 - Iniciar uma nova venda");
                Console.WriteLine("\n -----------------------");
                Console.Write("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "0":
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;                        
                        case "1":
                            IniciarNovaVenda();
                            break;
                    }

                }catch (Exception ex)
                {
                    Console.WriteLine($"\nErro na venda {ex.Message} ");
                    Console.WriteLine("\nPressione uma tecla para continuar...");
                    Console.ReadKey();
                }
            }

        }// fim menu

        public static void IniciarNovaVenda()
        {
            Console.WriteLine("------ NOVA VENDA ------");

            // 1 - IDENTIFICAÇÃO DO FUNCIONÁRIO
            int funcionarioID = 2;

            // 1 - IDENTIFICAÇÃO DO CLIENTE

            Console.WriteLine("ID do cliente (Pressione ENTER se não quiser identificar");

            int idCliente = 0;
            int.TryParse(Console.ReadLine(), out idCliente);

            Cliente ClienteVenda = Cliente.ListarPorId(idCliente);




            // -- INICIALIZANDO O OBJETO COMPRA --
            Compra CompraAtiva = new Compra(DateTime.Now, funcionarioID, ClienteVenda.Id);


            // Loop do carinho de compras
            bool AdicionarMais = true;

            while (AdicionarMais)
            {
                Console.WriteLine("\n ---- Adicionar Produto ----");
                Console.WriteLine("ID do produto ou '0' para finalizar/pagar ");

                int.TryParse(Console.ReadLine(), out int idProduto);

                if(idProduto == 0)
                {
                    AdicionarMais = false;
                    continue;
                }

                Produto? produto = Produto.ListarPorId(idProduto);

                if(produto == null)
                {
                    Console.WriteLine("Produto não encontrado... Tente novamente");
                    continue;
                }

                Console.Write($"{produto.Nome} | Preço {produto.Preco1:C} | Digite a quantidade: ");
                int.TryParse(Console.ReadLine(), out int qtdProduto);

                if(qtdProduto >= 0)
                {
                 CompraAtiva.AdicionarItem(produto, qtdProduto);
                    Console.WriteLine($"Subtotal:{produto.Preco1 * qtdProduto} ");
                    Console.ReadLine();
                    
                }
            } // encerra o laço de produtos

            // 3 Checkout
            if(CompraAtiva.Itens.Count == 0)
            {
                Console.WriteLine("\nVenda cancelada (Nenhum item foi adicionado).");
            }
            else
            {
                Console.WriteLine("\n ---- Resumo da Venda ----");
                foreach(var item in CompraAtiva.Itens)
                {
                    Console.WriteLine($"ID: {item.ProdutoId} | Qtd: {item.Quantidade} | Preço Unit: {item.PrecoCobrado} | Subtotal: {item.CalcularSubtotal():C}");

                }
                decimal totalFinal = CompraAtiva.CalcularTotal();

                Console.WriteLine("-------------------");
                Console.WriteLine($"TOTAL A PAGAR: {totalFinal:C}");
                Console.WriteLine("-------------------");
            }
        }





























    } // classe venda service



} // namespace
