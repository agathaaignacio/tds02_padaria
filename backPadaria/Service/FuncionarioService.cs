using backPadaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class FuncionarioService
    {
        public static void MenuFuncionario()
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("===== GESTÃO DE FUNCIONÁRIOS =====");

                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Listar Todos os Funcionário");
                Console.WriteLine("3 - Buscar Funcionário por ID");
                Console.WriteLine("4 - Atualizar Funcionário");
                Console.WriteLine("5 - Excluir Funcionário");
                Console.WriteLine("0 - Sair do Programa");

                Console.WriteLine("======================");
                Console.WriteLine("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcao)
                    {
                        case "1": // Cadastrar Funcionario
                            cadastrarFuncionarioMenu();
                            break;

                        case "2": // Listar Funcionario
                            listarFuncionarioMenu();
                            break;

                        case "3": // Buscar Funcionario
                            BuscarFuncionarioPorIDMenu();
                            break;

                        case "4": // Atualizar Funcionario
                            atualizarFuncionarioMenu();
                            break;

                        case "5": // Excluir Funcionario
                            deletarFuncionarioMenu();
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

        private static void cadastrarFuncionarioMenu()
        {
            Console.WriteLine("------ CADASTRAR FUNCIONÁRIO ----- ");

            Console.Write("Digite o nome do Funcionário: ");
            string nomeFuncionario = Console.ReadLine();

            Console.Write("Digite o cpf do Funcionário: ");
            string cpfFuncionario = Console.ReadLine();

            Console.Write("Digite o cargo do Funcionário: ");
            string cargoFuncionario = Console.ReadLine();

            Funcionario NovoFuncionario = new Funcionario(nome: nomeFuncionario, cpf: cpfFuncionario, cargo: cargoFuncionario);

            int resultadoInsert = Funcionario.Inserir(NovoFuncionario);
            Console.Clear();

            if (resultadoInsert > 0) Console.WriteLine("Funcionário cadastrado com sucesso!!\n");
        } // FIM CADASTRO FUNCIONARIO

        private static void listarFuncionarioMenu()
        {
            Console.WriteLine("------ LISTA DE FUNCIONÁRIOS ----- ");

            List<Funcionario> lista = Funcionario.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Funcionário cadastrado no sistema");

            }
            else
            {
                foreach (var funcionario in lista)
                {
                    Console.WriteLine($"ID: {funcionario.Id} | Nome {funcionario.Nome} | CPF: {funcionario.Cpf}| Cargo: {funcionario.Cargo} ");
                }
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        } // FIM LISTAR FUNCIONARIO

        public static void BuscarFuncionarioPorIDMenu()
        {
            Console.WriteLine(" ---- BUSCAR FUNCIONÁRIO POR ID ---- ");
            Console.WriteLine("Digite o ID do Funcionário: ");

            int id = int.Parse(Console.ReadLine());

            Funcionario funcionario = Funcionario.ListarPorId(id);
            if (funcionario == null)
            {
                Console.WriteLine("Nenhum Funcionário cadastrado no sistema");

            }
            else
            {
                {
                    Console.WriteLine($"ID: {funcionario.Id} | Nome {funcionario.Nome} | CPF: {funcionario.Cpf} ");
                }
            }

            Console.WriteLine("\n Pressione alguma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();


        } // FIM BUSCAR CLIENTE ID

        private static void atualizarFuncionarioMenu()
        {
            Console.WriteLine("----- ATUALIZAR FUNCIONÁRIO POR ID -----");
            Console.WriteLine("Digite o id do funcionario que deseja atualizar: ");

            int idBusca = 0;
            int.TryParse(Console.ReadLine(), out idBusca);

            Funcionario funcionarioParaAtualizar = Funcionario.ListarPorId(idBusca);

            if (funcionarioParaAtualizar != null)
            {
                Console.WriteLine($"Atualizar dados do {funcionarioParaAtualizar.Nome}");
                Console.WriteLine("Pressione ENTER sem digitar nada para manter os dados atual ");
                Console.WriteLine($"Novo Cargo: Atual ({funcionarioParaAtualizar.Cargo} )");

                string novoCargo = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoCargo)) funcionarioParaAtualizar.Cargo = novoCargo;

                int resultadoAtualizacao = Funcionario.Atualizar(funcionarioParaAtualizar);
                if (resultadoAtualizacao > 0) Console.WriteLine("Funcionário atualizado com sucesso! ");

            }
            else
            {
                Console.WriteLine("Funcionário não encontrado");
            }

            Console.ReadKey();

        } // FIM ATUALIZAR CLIENTE

        private static void deletarFuncionarioMenu()
        {
            Console.WriteLine("----- EXCLUIR FUNCIONÁRIO POR ID -----");
            Console.WriteLine("Digite o ID do Funcionário que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Funcionario funcionarioParaDeletar = Funcionario.ListarPorId(id);
            if (funcionarioParaDeletar != null)
            {
                Console.WriteLine($"Tem certeza que deseja excluir o Funcionário {funcionarioParaDeletar.Nome} (S/N)?");
                string opcao = Console.ReadLine();

                if (opcao.ToUpper() == "S")
                {
                    int clienteDeletado = Funcionario.Deletar(funcionarioParaDeletar);
                    Console.WriteLine("Funcionário excluído com sucesso.");
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
                Console.WriteLine("Funcionário não encontrado.");
            }

        } // FIM DELETAR






    } // classe cliente service
} // namespace