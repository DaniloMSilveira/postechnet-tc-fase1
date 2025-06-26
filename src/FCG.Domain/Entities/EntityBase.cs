using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCG.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}