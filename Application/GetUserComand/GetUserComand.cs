using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.GetUserComand
{
    public class GetUserComand
    {
        public Guid Id { get;}
        public GetUserComand(Guid id)
        {
            Id = id;
        }
    }
}
