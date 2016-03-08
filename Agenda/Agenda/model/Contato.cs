using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.model
{
    public class Contato
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }

        public override string ToString()
        {
            return String.Format("Contato[Id:{0}, Nome:{1}, Email:{2}, Telefone:{3}", Id, Nome, Email, Telefone);
        }
    }
}
