using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class EntidadeBase
    {
        public Guid CodigoId { get; set; }

        protected EntidadeBase()
        {
            CodigoId = Guid.NewGuid();
        }

    }
}
