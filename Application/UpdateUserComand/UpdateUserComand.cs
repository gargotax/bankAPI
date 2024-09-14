using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UpdateUserComand
{
    public class UpdateUserComand
    {
        public Guid Id { get;}
        public string Name { get;}
        public UpdateUserComand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
