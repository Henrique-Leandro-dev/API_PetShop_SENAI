using API_PetShop.Context;
using API_PetShop.Domains;
using API_PetShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Repositories
{
    public class RacaRepository : IRaca
    {

        PetShopContext conexao = new PetShopContext();

        SqlCommand cmd = new SqlCommand();
        public Raca Alterar(int id, Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET " +
                "Descricao = @descricao, " +
                "IdTipoDePet = @idtipodepet WHERE IdRaca = @id ";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", r.IdTipoDePet);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
            }

            conexao.Desconectar();

            return r;
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao, IdTipoDePet) " +
                "VALUES" +
                "(@descricao, @idtipodepet)";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", r.IdTipoDePet);

            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return r;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();



            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> Racas = new List<Raca>();

            while (dados.Read())
            {
                Racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = Convert.ToString(dados.GetValue(1)),
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(2))
                    }
                    );
            }


            // Fechar uma conexão
            conexao.Desconectar();
            return Racas;
        }
    }
}
