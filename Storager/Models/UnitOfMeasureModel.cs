using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class UnitOfMeasureModel
    {
        #region Database columns
        public byte Id { get; set; }
        public string UnitName { get; set; }
        public string ShortName { get; set; }
        #endregion
    }
}
