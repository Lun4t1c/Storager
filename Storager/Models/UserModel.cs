using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class UserModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int Id_privilege { get; set; }
        #endregion
    }
}
