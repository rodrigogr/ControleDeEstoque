using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelCategoria
    {
        private int cat_cod;
        private string cat_nome;
        
        public int CatCod
        {
            get{ return cat_cod; }
            set{ cat_cod = value;}
        }
        public string CatNome
        {
            get { return cat_nome; }
            set { cat_nome = value;  }
        }
    }
}
