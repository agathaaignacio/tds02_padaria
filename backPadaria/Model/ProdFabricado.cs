using BackPadaria.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Model
{
    internal class ProdFabricado
    {
        private int produtoId;
        private string descricaoProducao;

        public int ProdutoId { get => produtoId; set => produtoId = value; }
        public string descricaoProducao1 { get => descricaoProducao; set => descricaoProducao = value; }

        public ProdFabricado(int produtoId, string descricaoProducao)
        {
            this.ProdutoId = produtoId;
            this.descricaoProducao = descricaoProducao;
        }

        public static int Inserir(ProdFabricado prodFabricado)
        {
            string sql = "INSERT INTO `ProdutoFabricado` (produtoId, descricaoProducao) VALUES " +
                "(@produtoId, @descricaoProducao)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@produtoId", prodFabricado.produtoId);
                cmd.Parameters.AddWithValue("@descricaoProducao", prodFabricado.descricaoProducao);

                return Banco.executarComando(cmd);
            }
        } // FIM INSERIR

        public static int Deletar(ProdFabricado prodFabricado)
        {
            string sql = "DELETE FROM `ProdutoFabricado` WHERE `Id` = @id";
            using (var cmd = new MySqlCommand(sql))

            {
                cmd.Parameters.AddWithValue("@produtoId", prodFabricado.produtoId);
                return Banco.executarComando(cmd);
            }
        }

        public static List<ProdFabricado> ListarTodos()
        {
            string sql = "SELECT * FROM `Marca`";
            List<ProdFabricado> listaProdFabricado = new();
            using (var cmd = new MySqlCommand(sql))
            {
                using (MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd))
                {

                    while (reader.Read())

                    {

                        int produtoId = reader.GetInt32("produtoId");
                        string descricaoProducao = validarCampo(reader["descricaoProducao"]);

                        ProdFabricado prodFabricado= new(produtoId, descricaoProducao);
                        listaProdFabricado.Add(prodFabricado);

                    }
                }
                return listaProdFabricado;
            }
        } // FIM LISTAR


        public static ProdFabricado? ListarPorId(int produtoId)
        {
            string sql = "SELECT * FROM `ProdutoFabricado` WHERE `id` = @Id";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@produtoId", produtoId);
                MySqlDataReader reader = Banco.executarComRetornoDeDados(cmd);
                ProdFabricado prodFabricado = null;
                while (reader.Read())
                {

                    int idBanco = reader.GetInt32("Id");
                    string descricaoProducao = validarCampo(reader["Nome"]);

                    prodFabricado = new(produtoId, descricaoProducao);
                }
                return prodFabricado;
            }
        } //FIM LISTAR POR ID

        public static int Atualizar(ProdFabricado prodFabricado)
        {
            string sql = @"UPDATE ProdutoFabricado SET descricaoProducao = @descricaoProducao, WHERE produtoId = @produtoId";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@produtoId", prodFabricado.produtoId);
                cmd.Parameters.AddWithValue("@descricaoProducao", prodFabricado.descricaoProducao);

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





    } // classe prodfa
} // namespace