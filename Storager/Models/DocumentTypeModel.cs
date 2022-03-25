using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class DocumentTypeModel
    {
        #region Database columns
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        #endregion


        #region Properties
        public string DisplayName { get { return FullName + " (" + ShortName + ')'; } }
        public string DisplayNameInverted { get { return '(' + ShortName + ") " + FullName; } }
        #endregion
    }
}
