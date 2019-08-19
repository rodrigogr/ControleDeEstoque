using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DALConexao
    {
        private string _stringConexao;
        private SqlConnection _conexao;

        public DALConexao(string dadosConexao)
        {
            _conexao = new SqlConnection();
            _stringConexao = dadosConexao;
            _conexao.ConnectionString = dadosConexao;
        }
        public string StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }
        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }
        public void Conectar()
        {
            _conexao.Open();
        }
        public void Desconectar()
        {
            _conexao.Close();
        }
    }
}
