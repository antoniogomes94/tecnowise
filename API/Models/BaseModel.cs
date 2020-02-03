using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
}
