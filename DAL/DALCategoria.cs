using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Model;

namespace DAL
{
    public class DALCategoria
    {
        private DALConexao conexao;

        public DALCategoria(DALConexao cx)
        {
            conexao = cx;
        }
        public void Incluir(ModelCategoria model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into categoria(cat_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", model.CatNome) ;
            conexao.Conectar();
            model.CatCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        } 
        public void Alterar(ModelCategoria model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update categoria set cat_nome = @nome where cat_cod = @codigo;";
            cmd.Parameters.AddWithValue("@nome", model.CatNome);
            cmd.Parameters.AddWithValue("@codigo", model.CatCod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Conectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from categoria where cat_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Conectar();
        }
        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from categoria where cat_nome like '%" + valor + "%'", 
                conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public ModelCategoria CarregarModeloCategoria(int codigo)
        {
            ModelCategoria model = new ModelCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select *from categoria where cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                model.CatCod = Convert.ToInt32(registro["cat_cod"]);
                model.CatNome = Convert.ToString(registro["cat_nome"]);
            }
            conexao.Desconectar();
            return model;
        }
    }
}
