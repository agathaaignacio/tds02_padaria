using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class ClienteService
    {
        public static void MenuCliente()
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("===== GESTÃO DE CLIENTES =====");

                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Todos os Clientes");
                Console.WriteLine("3 - Buscar Cliente por ID");
                Console.WriteLine("4 - Atualizar Cliente");
                Console.WriteLine("5 - Excluir Cliente");
                Console.WriteLine("6 - Visualizar pontuação");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("======================");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar
                            cadastrarClienteMenu();
                            break;

                        case "2": // Listar
                            listarClientesMenu();
                            break;

                        case "3": // buscar
                            BuscarClientePorIDMenu();
                            break;

                        case "4": // Atualizar
                            atualizarClienteMenu();
                            break;

                        case "5": // Excluir
                            deletarClienteMenu();
                            break;

                        case "6": // Visualizar
                            visualizarPontuacaoMenu();
                            break;

                        case "0": // Sair
                            sair = true;
                            Console.WriteLine("Sistema Encerrado! ");
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }
            }
        } // FIM MENU

        private static void cadastrarClienteMenu()
        {
            Console.WriteLine("------ CADASTRAR CLIENTE ----- ");

            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("Digite o endereço do cliente: ");
            string enderecoCliente = Console.ReadLine();

            Console.Write("Digite o cpf do cliente: ");
            string cpfCliente = Console.ReadLine();

            Console.Write("Digite o telefone do cliente: ");
            string telefoneCliente = Console.ReadLine();

            Console.Write("Digite a quantidade de pontos");
            int pontosCliente = int.Parse(Console.ReadLine());


            Cliente NovoCliente = new Cliente(nome: nomeCliente, cpf: cpfCliente, telefone: telefoneCliente, endereco: enderecoCliente, pontos: pontosCliente);

            int resultadoInsert = Cliente.Inserir(NovoCliente);
            Console.Clear();

            if (resultadoInsert > 0) Console.WriteLine("Cliente cadastrado com sucesso!!\n");
        } // FIM CADASTRO CLIENTE

        private static void listarClientesMenu()
        {
            Console.WriteLine("------ LISTA DE CLIENTES ----- ");

            List<Cliente> lista = Cliente.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado no sistema");

            }
            else
            {
                foreach (var cliente in lista)
                {
                    Console.WriteLine($"ID: {cliente.Id} | Nome {cliente.Nome} | CPF: {cliente.Cpf}| Pontos: {cliente.Pontos} ");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        } // FIM LISTAR CLIENTES

        public static void BuscarClientePorIDMenu()
        {
            Console.WriteLine(" ---- Buscar Cliente por ID ---- ");
            Console.WriteLine("Digite o ID do cliente: ");

            int id = int.Parse(Console.ReadLine());

            Cliente cliente = Cliente.ListarPorId(id);
            if (cliente == null)
            {
                Console.WriteLine("Nenhum cliente cadastrado no sistema");

            }
            else
            {
                {
                    Console.WriteLine($"ID: {cliente.Id} | Nome {cliente.Nome} | CPF: {cliente.Cpf} ");
                }
            }

             Console.WriteLine("\n Pressione alguma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();


        } // FIM BUSCAR CLIENTE ID

        private static void atualizarClienteMenu()
        {
            Console.WriteLine("----- ATUALIZAR CLIENTE POR ID -----");
            Console.WriteLine("Digite o id do cliente que deseja atualizar: ");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);
            Console.WriteLine($"-------> {idBusca}");

            Cliente clienteParaAtualizar = Cliente.ListarPorId(idBusca);

            if (clienteParaAtualizar != null)
            {
                Console.WriteLine($"Atualizar dados de {clienteParaAtualizar.Nome}");
                Console.WriteLine("Pressione ENTER sem digitar nada para manter os dados atual ");
                Console.WriteLine($"Novo Endereço: Atual ({clienteParaAtualizar.Endereco} )");

                string novoEndereco = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoEndereco)) clienteParaAtualizar.Endereco = novoEndereco;

                Console.WriteLine($"Novo Telefone Atual: ({clienteParaAtualizar.Telefone}) ");
                string? novoTelefone = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoTelefone)) clienteParaAtualizar.Telefone = novoTelefone;

                int resultadoAtualizacao = Cliente.Atualizar(clienteParaAtualizar);
                if (resultadoAtualizacao > 0) Console.WriteLine("Cliente atualizado com sucesso! ");

            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }

            Console.ReadKey();

        } // FIM ATUALIZAR CLIENTE

        private static void deletarClienteMenu()
        {
            Console.WriteLine("----- EXCLUIR CLIENTE POR ID -----");
            Console.WriteLine("Digite o ID do cliente que deseja excluir: ");
                        int id = int.Parse(Console.ReadLine());

            Cliente clienteParaDeletar = Cliente.ListarPorId(id);
            if (clienteParaDeletar != null)
            {
                Console.WriteLine($"Tem certeza que deseja excluir o cliente {clienteParaDeletar.Nome} (S/N)?");
                string opcao = Console.ReadLine();

                if (opcao.ToUpper() == "S")
                {
                    int clienteDeletado = Cliente.Deletar(clienteParaDeletar);
                    Console.WriteLine("Cliente excluído com sucesso.");
                }
                else if (opcao.ToUpper() == "N")
                {
                    Console.WriteLine("Exclusão cancelada.");
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }

        } // FIM DELETAR

        private static void visualizarPontuacaoMenu()
        {
            Console.WriteLine("----- VISUALIZAR PONTUAÇÃO -----");
            Console.WriteLine("Digite o ID do cliente que deseja consultar:");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Cliente cliente = Cliente.ListarPorId(id);

            if (cliente != null)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"ID do cliente: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Pontuação: {cliente.Pontos}");
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        } // FIM VISUALIZAR PONTUAÇÃO





    } // classe cliente service
    } // namespace