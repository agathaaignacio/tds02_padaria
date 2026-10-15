using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Cliente
    {
        private int id;
        private string nome;
        private string cpf;
        private string telefone;
        private string endereco;
        private int pontos;

        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public int Pontos { get => pontos; set => pontos = value; }

        public void AdicionarPontos(int pontos)
        {
            this.Pontos++;
        }

        public static int Inserir(Cliente cliente)
        { /* ^ Instrução SQL: Define o comando de inserção (INSERT).
          0 uso de marcações com '@' (ex: @Nome) é uma pratica de segurança crucial chamada de "Parametrização".
          Ela impede ataques de SQL Injection, pois o banco entende o que e comando e o que e apenas texto do usuário. */


            string sql = "INSERT INTO `Cliente` (`Nome`, `CPF`, `Telefone`, `Endereco`, `Pontos`) " +
                "VALUES (@Nome, @CPF, @Telefone, @Endereco, @Pontos)";
            /* Gerenciamento de recursos: Cria o objeto de comando já passando a instrução SQL.
            0 'using' garante que os recursos de memoria ocupados pelo comando sejam liberados ao final do bloco. */

            using (var cmd = new MySqlCommand(sql))
            { /* Vinculação de Dados: Pega as propriedades do objeto C# Cusuario.Nome, usuario.Email, etc.)
                e substitui de forma segura as marcaçoes '@' da string SQL com es valores reais. */

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Pontos", cliente.Pontos);

                /* Execução: Como o comando de INSERT não retorna tabelas (apenas executa uma ação),
                ele envia o comando configurado para o metodo generico 'executarComando' da classe 'Banco',
                0 método retorna 1 (se o usuario for inserido com sucesso) ou -1 (se houver erro no banco). */
            
                return Banco.executarComando(cmd);
            }
            
        }
    }
}
