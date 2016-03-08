using Agenda.dao;
using Agenda.model;
using Agenda.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
  create table contato (
     id int not null auto_increment,
     nome varchar(255),
     email varchar(255),
     telefone varchar(255),
     primary key(id)
  );
  
 */

namespace AgendaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato c = new Contato()
            {
                Nome = "Marcelo G",
                Email = "marcelogomesrp@gmail.com",
                Telefone = "(16) 982450587"
            };

            ContatoService contatoService = new ContatoService();
            contatoService.Adicionar(c);

            foreach (Contato contato in contatoService.BuscarTodos())
            {
                Console.WriteLine("--> " + contato.ToString());
            }
            Console.WriteLine("---");

            foreach (Contato contato in contatoService.BuscarPorNome("M%"))
            {
                Console.WriteLine("--> " + contato.ToString());
            }
            Console.WriteLine("Fim");
            Console.ReadKey();
        }
    }
}
