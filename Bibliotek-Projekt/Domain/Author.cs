using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Author(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        
    }
}
