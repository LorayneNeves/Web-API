using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers.MongoDb.Collections
{
    [BsonCollection("Categoria")]
    public class CategoriaCollection : Document
    {
        #region 2 - Propriedades
        public Guid CodigoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        #endregion
    }
}
