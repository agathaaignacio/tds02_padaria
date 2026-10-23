using BackPadaria.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class Marca
    {
        private int id;
        private string nome;
        private string descricao;

        public Marca(int id, string nome, string descricao)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
        }

        public Marca(string nome, string descricao)

        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome da marca não pode ser vazio");
            this.nome = nome;
            this.descricao = descricao;

        }

        // Gambiarra para testar
        public Marca(int id)
        {
            this.Id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        public static int Inserir(Marca marca)
        {
            string sql = "INSERT INTO `Marca` (Nome, Telefone) VALUES (@Nome, @Telefone)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                cmd.Parameters.AddWithValue("@Telefone", marca.descricao);

                return Banco.executarComando(cmd);
            }
        } // FIM INSERIR

        public static int Deletar(Marca marca)
        {
            string sql = "DELETE FROM `Marca` WHERE `Id` = @id";
            using (var cmd = new MySqlCommand(sql))

            {
                cmd.Parameters.AddWithValue("@id", marca.id);
                return Banco.executarComando(cmd);
            }
        }

        public static List<Marca> ListarTodos()
        {
            string sql = "SELECT * FROM `Marca`";
            List<Marca> listaMarca = new();
            using (var cmd = new MySqlCommand(sql))
            {
                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    while (reader.Read())

                    {

                        int id = reader.GetInt32("Id");
                        string nome = validarCampo(reader["Nome"]);
                        string descricao = validarCampo(reader["Descricao"]);

                        Marca marca = new (id, nome, descricao);
                        listaMarca.Add(marca);

                    }
                }
                return listaMarca;
            }
        } // FIM LISTAR

        public static Marca? ListarPorId(int id)
        {
            string sql = "SELECT * FROM `Marca` WHERE `id` = @Id";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);
                Marca marca = null;
                while (reader.Read())
                {

                    int idBanco = reader.GetInt32("Id");
                    string nome = validarCampo(reader["Nome"]);
                    string descricao = validarCampo(reader["Descricao"]);
                    marca = new (id, nome, descricao);
                }
                return marca;
            }
        } //FIM LISTAR POR ID

        public static int Atualizar(Marca marca)
        {
            string sql = @"UPDATE Marca SET Nome = @Nome, Descricao = @Descricao, WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);
                cmd.Parameters.AddWithValue("@Id", marca.id);

                return Banco.executarComando(cmd);
            }
        } // FIM ATUALIZAR

        private static string validarCampo(object campo)
        {
            if (campo == DBNull.Value || campo == null)
            {
                return "";
            }
            else

            {
                return campo.ToString();
            }

        } // FIM VALIDAR

    } // classe marca
} // namespace
