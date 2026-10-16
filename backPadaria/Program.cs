using backPadaria.Model;

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

            List<Cliente> clientes = Cliente.ListarTodos();
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






        } // void main
    } // classe program
} // namespace
