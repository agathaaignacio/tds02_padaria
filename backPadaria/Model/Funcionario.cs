using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Funcionario
        {
        private int id;
        private string nome;
        private string cpf;
        private string cargo;

        public Funcionario(int id, string nome, string cpf, string cargo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cargo = cargo;
        }

        public Funcionario(string? nome, string? cpf, string? cargo)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.cargo = cargo;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public Funcionario(int id) // metodo contrutor gambiarra 
        { 
            this.Id = id;
        }

        public static int Inserir(Funcionario funcionario)
        { /* ^ Instrução SQL: Define o comando de inserção (INSERT).
          0 uso de marcações com '@' (ex: @Nome) é uma pratica de segurança crucial chamada de "Parametrização".
          Ela impede ataques de SQL Injection, pois o banco entende o que e comando e o que e apenas texto do usuário. */

            string sql = "INSERT INTO `Funcionario` (`Nome`, `CPF`, `Cargo`) VALUES (@Nome, @CPF, @Cargo)";
            /* Gerenciamento de recursos: Cria o objeto de comando já passando a instrução SQL.
            0 'using' garante que os recursos de memoria ocupados pelo comando sejam liberados ao final do bloco. */

            using (var cmd = new MySqlCommand(sql))
            { /* Vinculação de Dados: Pega as propriedades do objeto C# Cusuario.Nome, usuario.Email, etc.)
                e substitui de forma segura as marcaçoes '@' da string SQL com es valores reais. */

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

                /* Execução: Como o comando de INSERT não retorna tabelas (apenas executa uma ação),
                ele envia o comando configurado para o metodo generico 'executarComando' da classe 'Banco',
                0 método retorna 1 (se o usuario for inserido com sucesso) ou -1 (se houver erro no banco). */

                return Banco.executarComando(cmd);
            }

        } // Inserir

        public static int Deletar(Funcionario funcionario)
        {
            string sql = "DELETE FROM `Funcionario` WHERE  `Id` = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", funcionario.id);

                return Banco.executarComando(cmd);
            }
        } // Deletar

        public static List<Funcionario> ListarTodos()
        {
            string sql = "SELECT * FROM `Funcionario` ";
            List<Funcionario> ListaFuncionario = new();

            using (var cmd = new MySqlCommand(sql))
            {
                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                /* Executa a leitura. 0 bloco 'using' aqui é FUNDAMENTAL para garantir que o reader seja fechado no final, o que por sua vez fecha a conexao com o banco. */
                {
                    while (reader.Read())
                    /* o While vai rodas uma vez par CADA linha que existir na tabela Cliente. */
                    {
                        int id = reader.GetInt32("Id");
                        string nome = validarCampo(reader["Nome"]);
                        string cpf = validarCampo(reader["CPF"]);
                        string cargo = validarCampo(reader["Cargo"]);

                        Funcionario funcionario = new Funcionario(id, nome, cpf, cargo);
                        // Criar o objeto Cliente com os dados extraídos

                        ListaFuncionario.Add(funcionario);
                        // Adicionar este cliente á nossa lista
                    }
                }
                return ListaFuncionario;
            }  
        } // list funcionario

        private static string validarCampo(object campo)
        {
            if (campo == DBNull.Value || campo == null)
            {
                return " ";
            }
            else
            {
                return campo.ToString();
            }
        } // validar campo

        public static Funcionario? ListarPorId(int id)
        {
            string sql = "SELECT * FROM `Funcionario` WHERE `id` = @id";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);

                Funcionario funcionario = null;
                while (reader.Read())
                {
                    // Extrair os dados da linha atual
                    int idBanco = reader.GetInt32("Id");

                    string nome = validarCampo(reader["Nome"]);
                    string cpf = validarCampo(reader["CPF"]);
                    string cargo = validarCampo(reader["Cargo"]);

                    // Cria o objeto Cliente com os dados extraídos
                    funcionario = new Funcionario(idBanco, nome, cpf, cargo);
                }
                return funcionario;
            }
        } // listar por id

        public static int Atualizar(Funcionario funcionario)
        {
            string sql = "UPDATE `Funcionario` SET `Nome` = @Nome, `Cpf` = @CPF, `Cargo` = @Cargo WHERE `Id` = @Id";

            using (var cmd = new MySqlCommand(sql))
            {
                // Vinculação de parâmetros: Protege contra SQL Injection e organiza os dados
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@CPF", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

                // A chave de busca: Quem será atualizado?
                cmd.Parameters.AddWithValue("@Id", funcionario.id);

                return Banco.executarComando(cmd);
                /* Execução: O UPDATE também é uma instrução de ação (como INSERT e DELETE). Ele vai retornar 1 (se encontrou o ID e atualizou com sucesso) ou 0 (se o ID não existia). */
            }
        } // Atualizar

    } //classe funcionario
} // namespace

