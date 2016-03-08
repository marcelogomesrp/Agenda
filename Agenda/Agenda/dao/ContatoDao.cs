using Agenda.model;
using Agenda.tools.convert;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.dao
{
    public class ContatoDao : Dao
    {
        String connectionString = ConfigurationManager.ConnectionStrings["DBAgenda"].ToString();

        public void Adicionar(Contato contato)
        {
            String query = "INSERT INTO contato (nome,email,telefone) VALUES(@nome,@email,@telefone)";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome", contato.Nome));
            parameters.Add(new MySqlParameter("email", contato.Email));
            parameters.Add(new MySqlParameter("telefone", contato.Telefone));
            this.ExecuteNonQuery(query, parameters);
        }

        public void Atualizar(Contato contato)
        {
            String query = "UPDATE contato SET nome = @nome, email = @email, telefone = @telefone WHERE id = @id";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome", contato.Nome));
            parameters.Add(new MySqlParameter("email", contato.Email));
            parameters.Add(new MySqlParameter("telefone", contato.Telefone));
            parameters.Add(new MySqlParameter("id", contato.Id));
            this.ExecuteNonQuery(query, parameters);
        }

        public void Excluir(Contato contato)
        {
            String query = "DELETE FROM contato WHERE id = @id";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id", contato.Id));
            this.ExecuteNonQuery(query, parameters);
        }

        public IList<Contato> BuscarTodos()
        {
            IList<Contato> listContatos = new List<Contato>();
            String query = "SELECT id,nome,email,telefone FROM contato";
            DataTable dataTable = ExecuteReader(query, null);
            return new ContatoConvert().ConvertToList(dataTable);
        }

        public IList<Contato> BuscarPorNome(String nome)
        {
            IList<Contato> listContatos = new List<Contato>();
            String query = "SELECT id,nome,email,telefone FROM contato WHERE nome LIKE @nome";
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome", nome));
            DataTable dataTable = ExecuteReader(query, parameters);
            return new ContatoConvert().ConvertToList(dataTable);
        }

    }
}
