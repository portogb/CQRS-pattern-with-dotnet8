using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public abstract class BaseEntity(Guid id)
    {
        public Guid Id { get; init; } = id;

        protected BaseEntity() : this(Guid.Empty) { }
    }
}
