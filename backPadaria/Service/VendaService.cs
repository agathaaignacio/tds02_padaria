using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Console.WriteLine("==== PDV - Padaria Pão & Cia ====\n");
                Console.WriteLine("0 - Voltar ao MENU PRINCIPAL");
                Console.WriteLine("1 - Iniciar uma nova venda");
                Console.WriteLine("\n================================");
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
             
            // 1 



        }





























    } // classe venda service



} // namespace
