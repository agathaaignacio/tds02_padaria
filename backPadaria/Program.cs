using backPadaria.Model;
using backPadaria.Service;

namespace backPadaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o endereço do cliente: ");
            string enderecoCliente = Console.ReadLine();

            Console.WriteLine("Digite o cpf do cliente: ");
            string cpfCliente = Console.ReadLine();

            Console.WriteLine("Digite o telefone do cliente: ");
            string telefoneCliente = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de pontos");
            int pontosCliente = int.Parse(Console.ReadLine());


            // Refatoração :  reescrever
            Cliente cliente1 = new Cliente(
                nome: nomeCliente, cpf: cpfCliente, telefone: telefoneCliente, endereco: enderecoCliente, pontos: pontosCliente); */

            /* Cliente clienteParaDeletar = new Cliente(5);

            if(Cliente.Deletar(clienteParaDeletar) >= 1)
            {
                Console.WriteLine("Cliente excluido com sucesso. Ok");
            }
            else
            {
                Console.WriteLine("Deu bom não. Cliente presente! "); 
            } */

            /* List<Cliente> clientes = Cliente.ListarTodos();
                 foreach(Cliente cliente in clientes)
             {
                 Console.WriteLine($"Id: {cliente.Id}");
                 Console.WriteLine($"Nome:  {cliente.Nome}");
                 Console.WriteLine($"CPF:  {cliente.Cpf}");
                 Console.WriteLine($"Telefone:  {cliente.Telefone}");
                 Console.WriteLine($"Endereço:  {cliente.Endereco}");
                 Console.WriteLine($"Pontos:  {cliente.Pontos}");

                 Console.WriteLine("---------------------------------------");

             } 
            Cliente? cli01 = Cliente.ListarPorId(4);

            if(cli01 != null)
            {
                Console.WriteLine($"ID: {cli01.Id}");
                Console.WriteLine($"Nome:  {cli01.Nome}");
                Console.WriteLine($"CPF:  {cli01.Cpf}");
                Console.WriteLine($"Telefone:  {cli01.Telefone}");
                Console.WriteLine($"Endereço:  {cli01.Endereco}");
                Console.WriteLine($"Pontos:  {cli01.Pontos}");
            }
            else
            {
                Console.WriteLine("O cliente não foi encontrado !! ");
            }

            Cliente? meuCliente = Cliente.ListarPorId(4);

            if(meuCliente != null)
            {
                meuCliente.Endereco = "Rua Barão de Alagoas, 171";
                meuCliente.Telefone = "1196352-4588";

                int resultado = Cliente.Atualizar(meuCliente);
                if(resultado > 0)
                {
                    Console.WriteLine("Cliente Atualizado com Sucesso!");
                }
            } */

            //------------------------ MENU SERVICE -----------------------------------------

             //ClienteService.MenuCliente();

            // FuncionarioService.MenuFuncionario();


            //-----------------------------------------------------------------------------

            /*  ***** FUNCIONARIO *****
               --- Adicionar Funcionario  --- 
            Console.WriteLine("Digite o nome do funcionario: ");
            string nomeFuncionario = Console.ReadLine();

            Console.WriteLine("Digite o cpf do funcionario: ");
            string cpfFuncionario = Console.ReadLine();

            Console.WriteLine("Digite o cargo do funcionario: ");
            string cargoFuncionario = Console.ReadLine();

           Refatoração :  reescrever
            Funcionario funcionario1 = new Funcionario(nome: nomeFuncionario, cpf: cpfFuncionario, cargo: cargoFuncionario);

            Funcionario.Inserir(funcionario1); 

            // --- Deletar Funcionario ---
            Funcionario funcionarioParaDeletar = new Funcionario(3);

            if(Funcionario.Deletar(funcionarioParaDeletar) >= 1)
            {
                Console.WriteLine("Funcionario excluido com sucesso. Ok");
            }
            else
            {
                Console.WriteLine("Deu bom não. Funcionario presente! "); 
            } 
            
              --- Listar Funcionarios ---
            List<Funcionario> funcionarios = Funcionario.ListarTodos();
                 foreach(Funcionario funcionario in funcionarios)
             {
                 Console.WriteLine($"Id: {funcionario.Id}");
                 Console.WriteLine($"Nome:  {funcionario.Nome}");
                 Console.WriteLine($"CPF:  {funcionario.Cpf}");
                 Console.WriteLine($"Cargo:  {funcionario.Cargo}");
                 Console.WriteLine("---------------------------------------");

             }  

               // --- Listar Por ID --- 
            Funcionario? funci = Funcionario.ListarPorId(2);

            if(funci != null)
            {
                Console.WriteLine($"ID: {funci.Id}");
                Console.WriteLine($"Nome:  {funci.Nome}");
                Console.WriteLine($"CPF:  {funci.Cpf}");
                Console.WriteLine($"Cargo:  {funci.Cargo}");
            }
            else
            {
                Console.WriteLine("O funcionario não foi encontrado !! ");
            }*/




        } // void main
    } // classe program
} // namespace
