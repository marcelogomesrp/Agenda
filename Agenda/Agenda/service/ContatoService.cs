using Agenda.dao;
using Agenda.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.service
{
    public class ContatoService
    {
        private ContatoDao contatoDao;

        public ContatoService()
        {
            contatoDao = new ContatoDao();
        }

        public void Adicionar(Contato contato)
        {
            if(isContatoValido(contato)){
                contatoDao.Adicionar(contato);
            }
        }

        public void Adicionar(String nome, String email, String telefone){
            Contato contato = new Contato()
            {
                Nome = nome,
                Email = email,
                Telefone = telefone
            };
            this.Adicionar(contato);
        }

        public void Atualizar(Contato contato)
        {
            if (hasContatoInDatabase(contato))
            {
                contatoDao.Atualizar(contato);
            }
            else
            {
                throw new Exception("O contato não existe");
            }
        }

        public void Atualizar(int id, String nome, String telefone)
        {
            Contato contato = new Contato()
            {
                Id = id,
                Nome = nome,
                Telefone = telefone
            };
            this.Atualizar(contato);
        }

        public void Excluir(Contato contato)
        {
            if (hasContatoInDatabase(contato))
            {
                contatoDao.Excluir(contato);
            }
            else
            {
                throw new Exception("O contato não existe");
            }
        }

        public IList<Contato> BuscarPorNome(String nome)
        {
            return contatoDao.BuscarPorNome(nome);
        }

        public IList<Contato> BuscarTodos()
        {
            return contatoDao.BuscarTodos();
        }

        public bool isContatoValido(Contato contato)
        {
            if (contato == null)
            {
                throw new Exception("O contato nao pode ser null");
            }
            if (contato.Nome.Length < 3)
            {
                throw new Exception("O nome deve ter mais de 2 caracteres");
            }
            return true;
        }

        public bool hasContatoInDatabase(Contato contato)
        {
            if (contato.Id != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
