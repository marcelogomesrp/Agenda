using Agenda.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.tools.convert
{
    public class ContatoConvert
    {
        public IList<Contato> ConvertToList(DataTable dataTable)
        {
            IList<Contato> contatos = new List<Contato>();
            foreach (DataRow dr in dataTable.Rows)
            {
                contatos.Add(ConvertToContato(dr));
            }
            return contatos;
        }


        public Contato ConvertToContato(DataRow dataRow)
        {
            Contato contato = new Contato();
            contato.Id = Convert.ToInt32(dataRow["id"]);
            contato.Nome = Convert.ToString(dataRow["nome"]);
            contato.Email = Convert.ToString(dataRow["email"]);
            contato.Telefone = Convert.ToString(dataRow["telefone"]);
            return contato;
        }
    }
}
