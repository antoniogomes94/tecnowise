using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public Cliente()
        {
            Nome =  "";
            Email =  "";
            Telefone =  "";
            Endereco =  "";
            Complemento =  "";
            Bairro =  "";
            Municipio =  "";
            UF =  "";
            CEP =  "";
        }
    }
}
