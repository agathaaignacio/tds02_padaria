using backPadaria;
using backPadaria.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPadaria.Model
{
    internal class Produto
    {
        private int id;
        private string nome;
        private decimal Preco;
        private string categoria;
        private bool fabricado;
        private int marcaId;


        public Produto(int id, string nome, decimal preco, string categoria, bool fabricado, int marcaId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
            this.Fabricado = fabricado;
            this.MarcaId = marcaId;
        }

        public Produto(string nome, decimal preco, string categoria, bool fabricado, int marcaId)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
            this.Fabricado = fabricado;
            this.MarcaId = marcaId;
        }

        public Produto(int id)
        {
            this.Id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public decimal Preco1 { get => Preco; set => Preco = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public bool Fabricado { get => fabricado; set => fabricado = value; }
        public int MarcaId { get => marcaId; set => marcaId = value; }


        public static int Inserir(Produto produto)
        {
            string sql = "INSERT INTO `Produto` (`Nome`, `Preco`,`Categoria`,`Fabricado`, `MarcaId` )" +
                " VALUES (@Nome, @Preco, @Categoria, @Fabricado, @MarcaId)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", preco.Cpf);
                cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);

                return Banco.executarComando(cmd);
            }

        } // Inserir



    } // classe produto
} // namespace
