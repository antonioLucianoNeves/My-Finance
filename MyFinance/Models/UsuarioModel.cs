using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System.Data;

namespace MyFinance.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public int Email { get; set; }
        public string Senha { get; set; }
        public string Data_nascimento { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME, EMAIL, SENHA, DATA_NASCIMENTO FROM USUARIO WHERE EMAIL='{Email}' AND SENHA{Senha}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if(dt != null)
            {
                if(dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Nome = dt.Rows[0]["Nome"].ToString();
                    DateTime dateTime = DateTime.Parse(dt.Rows[0]["DATA_NASCIMENTO"].ToString());
                    return true;
                }     
            }
            return false;
        }
    }
}
