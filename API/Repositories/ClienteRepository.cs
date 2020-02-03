using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IClienteRepository
    {
        Cliente Get(int id);
        Cliente Set(Cliente model);
        List<Cliente> GetList();
        void Update(Cliente model);
        void Delete(int id);
    }

    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public void Delete(int id)
        {
            dbSet.Remove(Get(id));
            contexto.SaveChanges();
        }

        public Cliente Get(int id)
        {
            return dbSet.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<Cliente> GetList()
        {
            return dbSet
                .ToList();
        }

        public Cliente Set(Cliente model)
        {
            dbSet.Add(model);
            contexto.SaveChanges();
            return model;
        }

        public void Update(Cliente model)
        {
            dbSet.Update(model);
            contexto.SaveChanges();
        }

        public void LimparCadastrosVazios()
        {
            var clientes = dbSet.ToList<Cliente>();
            foreach (var cliente in clientes)
            {
                if (string.IsNullOrEmpty(cliente.Nome) && string.IsNullOrEmpty(cliente.Email) 
                    && string.IsNullOrEmpty(cliente.Telefone) && string.IsNullOrEmpty(cliente.Endereco)
                    && string.IsNullOrEmpty(cliente.Bairro) && string.IsNullOrEmpty(cliente.Municipio)
                    && string.IsNullOrEmpty(cliente.UF) && string.IsNullOrEmpty(cliente.CEP))
                {
                    dbSet.Remove(cliente);
                }
            }
            contexto.SaveChanges();
        }
    }
}
