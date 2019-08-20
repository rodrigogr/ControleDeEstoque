using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BBL
{
    public class BLLCategoria
    {
        private DALConexao conexao;
        private DALCategoria dALCategoria;
        public BLLCategoria(DALConexao cx)
        {
            conexao = cx;
        }
        public void Incluir(ModelCategoria model)
        {
            if (model.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome é obrigatório!");
            }
            dALCategoria = new DALCategoria(conexao);
            dALCategoria.Incluir(model);
        }
        public void Alterar(ModelCategoria model)
        {
            dALCategoria = new DALCategoria(conexao);
            dALCategoria.Alterar(model);
        }
        public void Excluir(int codigo)
        {
            dALCategoria = new DALCategoria(conexao);
            dALCategoria.Excluir(codigo);
        }
        public DataTable Localizar(string valor)
        {
            dALCategoria = new DALCategoria(conexao);
            return dALCategoria.Localizar(valor);
        }
        public ModelCategoria CarregarModeloCategoria(int codigo)
        {
            dALCategoria = new DALCategoria(conexao);
            return dALCategoria.CarregarModeloCategoria(codigo);
        }
    }
}
