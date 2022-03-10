using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class StorageRackModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Code { get; set; }
        public ushort LevelsCount { get; set; }
        #endregion
    }
}
