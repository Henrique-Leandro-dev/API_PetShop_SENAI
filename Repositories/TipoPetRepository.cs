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
    public class TipoPetRepository : ITipoPet
    {
        // Chamar a classe de conexão do banco
        PetShopContext conexao = new PetShopContext();

        // Chamar o objeto reponsável por receber as linhas de comandos
        SqlCommand cmd = new SqlCommand();

        public TipoPet Alterar(int id, TipoPet tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoDePet SET " +
                "Descricao = @descricao WHERE IdTipoDePet = @id ";
            cmd.Parameters.AddWithValue("@descricao", tp.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return tp;
        }

        public TipoPet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";
            
            //Atribur as variaveis que vem como argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoPet tp = new TipoPet();

            while(dados.Read())
            {
                tp.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                tp.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return tp;
        }

        public TipoPet Cadastrar(TipoPet tp)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoDePet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", tp.Descricao);
 
            // Será este comando o responsável por injetar os dados no banco efetivamente
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return tp;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();



            conexao.Desconectar();
        }

        public List<TipoPet> LerTodos()
        {
            // Abrir uma conexao
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoDePet";
            
            SqlDataReader dados = cmd.ExecuteReader();

            //Criar a lista para guardar os tipo Pets
            List<TipoPet> tipoPets = new List<TipoPet>();

            while(dados.Read())
            {
                tipoPets.Add(
                    new TipoPet()
                    {
                       IdTipoDePet  = Convert.ToInt32(dados.GetValue(0)),
                       Descricao    = Convert.ToString(dados.GetValue(1))   
                    }
                    );
            }


            // Fechar uma conexão
            conexao.Desconectar();

            return tipoPets;
        }
    }
}
