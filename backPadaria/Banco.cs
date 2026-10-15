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




        }

    }


