using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria
{
    internal class Banco
    {
        private static string stringDeConexao = "Server=10.91.45.48;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678";// string de conexao é o caminho para conectar com o banco

        public static void connectAndTest()
        {
            using (var connection = new MySqlConnection(stringDeConexao)) 
            {
                try
                {
                    Console.WriteLine("Tentando conecta ao banco de dados");

                    connection.Open();

                    Console.WriteLine("Conexão bem sucedida");

                    using (var command = new MySqlCommand("SELECT VERSION();", connection))
                    {
                        string? version = command.ExecuteScalar()?.ToString();
                        Console.WriteLine($"Versao do MariaDB {version}");

                    }

                    
                }catch (MySqlException ex) 
                {
                    Console.WriteLine("Erro ao conectar no banco de dados.");
                    Console.WriteLine(ex.Message);

                    // testee
                }
                }
            }


        public static int executarComando(MySqlCommand command)
        /* ^ Declaração do método: público e estático, retorna um número inteiro (linhas afetadas)
        e recebe um objeto MySqlCommand com a instrução SQL já configurada como parâmetro. */

        {
            /* O bloco 'using' garante que a conexão será automaticamente fechda e liberada da memória
            ao final do bloco, mesmo que ocorre erros no meio do processo. 
            
             Criar a conexão utilizando a variavel de ambiente. */

            using (var conexao = new MySqlConnection(stringDeConexao))

            {
                // Vinculação: Diz ao comando SQL em qual conexão ele deve ser executado.
                command.Connection = conexao;


                // Tratamento de erros: Inicia um bloco de tentativas para proteger o programa de falhas abruptas.
                try 
                {
                    // Abertura da conexão: Estabelece efetivamente a comunicação com o servidor MySql.
                    conexao.Open();
                    
                    /* Execução: O ExecuteNonQuery dispara comandos de ação (INSERT, UPDATE, DELETE). Ele não retorna
                     registros, mas sim o número inteiro de linhas que foram alteradas, e o 'return' devolve esse número
                     para quem chamou o método. */

                    return command.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine($"Erro de Banco de dados {ex.Message}");

                    return -1;
                }



            }
        }

        public static int  executarComandoComRetornoId(MySqlCommand command)
        /* Declaracao do metodo: publico e estático, projetado especificamente para executar comandos(geralmente INSERTs seguidos de SELECT LAST_INSERT_ID()) e retornar o ID gerado pelo banco. */
        {
            using (var conexao = new MySqlConnection(stringDeConexao))
            {
                command.Connection = conexao;

                try
                {
                    conexao.Open();
                    object objRetorno = command.ExecuteScalar();
                    /* ExecuteScalar executa o comando e retorna APENAS a primeira coluna da primeira Linha do resultado. E perfeito para pegar um unico valor (como um ID recem-gerado).
                    Ele retorna um tipo 'object' porque nao sabe de antemao qual o tipo do dado no banco. */

                    int retorno = 0;

                    if (objRetorno != null && objRetorno != DBNull.Value)
                    /* Verificação de segurança: Checa se o banco realmente retornou algo. Verifica tanto se o objeto C# nao e nulo (null) quanto se não é um nulo do próprio banco de dados (DBNull.Value). */
                    {
                        retorno = int.Parse(objRetorno.ToString());
                        /* Se passou na verificacão, converte o objeto (que veio como texto/objeto) para um numero inteiro (int) */

                        return retorno;
                    }

                }
                catch(MySqlException ex)
                {
                    Console.WriteLine($"Erro de Banco de Dados {ex.Message}");
                    return -1;
                }
            }
        }

            public static MySqlDataReader executarComRetornoDeDados(MySqlCommand command)
            /* Metodo central para executar comandos de consulta (SELECT) no banco de dados.
        Ele retorna um MySqLDataReader, que e uma especie de "ponteiro" para ler os dados linha por linha. */
        {
            var conexao = new MySqlConnection(stringDeConexao);
            /*  Cria a conexão com o banco. ATENÇÃO: Aqui NÃO usamos o bloco 'using' para a conexão. Se usássemos, a conexão seria fechada antes de retornar os dados, e o programa quebraria ao tentar ler a tabela. */

            command.Connection = conexao;

            try
            {
                conexao.Open();
                /* Abre a porta de comunicação com o MysSQL */

                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                /* Executa a consulta e retorna o "Leitor" de dados. O CommandBehavior.CloseConnection é a peça-chave deste método: ele avisa ao leitor que assim que ele (o leitor) for fechado ou descartado la na tela/classe que o chamou,
                    A conexao com o banco deve ser fechada automaticamente junto com ele. */
            }
            catch(MySqlException ex)
            {
                conexao.Dispose();
                /* O Dispose() já executa o Close() e libera a memória. */

                Console.WriteLine($"Erro na leitura de dados: {ex.Message}");

                /* Ao inves de retornar null, relança o erro (throw) para que o metodo que chamou este ExecuteReader saiba que a pesquisa falhou e possa tratar a tela do usuário. */

                throw;
            }
 
        }

        } // Classe

    } // Namespace


