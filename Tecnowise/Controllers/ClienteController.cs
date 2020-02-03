using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tecnowise.API;
using Tecnowise.Models;

namespace Tecnowise.Controllers
{
    public class ClienteController : Controller
    {
        ClienteApi api = new ClienteApi();

        public IActionResult Cadastro(int id)
        {
            if (id == 0)
            {
                var novo = api.Set(new Cliente());
                id = novo.Id;
            }

            return View(api.Get(id));
        }

        public IActionResult Listagem()
        {
            var lista = api.GetList();
            return View(lista);
        }

        public IActionResult Salvar(Cliente modelo)
        {
            if (api.Update(modelo))
                return RedirectToAction("Listagem");

            return BadRequest();
        }

        public IActionResult Cancelar(int id)
        {
            var cliente = api.Get(id);
            if (string.IsNullOrEmpty(cliente.Nome) && string.IsNullOrEmpty(cliente.Email)
                     && string.IsNullOrEmpty(cliente.Telefone) && string.IsNullOrEmpty(cliente.Endereco)
                     && string.IsNullOrEmpty(cliente.Bairro) && string.IsNullOrEmpty(cliente.Municipio)
                     && string.IsNullOrEmpty(cliente.UF) && string.IsNullOrEmpty(cliente.CEP))
            {
                api.Delete(id);
            }
            return RedirectToAction("Listagem");
        }

        public IActionResult Delete(Cliente modelo)
        {
            if (modelo != null)
            {
                if (api.Delete(modelo.Id))
                    return RedirectToAction("Listagem");

                return BadRequest();
            }

            return BadRequest();
        }
    }
}