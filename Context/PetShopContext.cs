using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Context
{
    //Criar uma conexão
    public class PetShopContext
    {
        SqlConnection con = new SqlConnection();

        public PetShopContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-9LK3UQP\SQLEXPRESS;Initial Catalog=PetShop;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
