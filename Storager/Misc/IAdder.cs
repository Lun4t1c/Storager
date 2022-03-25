using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Misc
{
    public abstract class IAdder : Screen
    {
        public System.Action AssignedAction { get; set; } = null;
        protected abstract void InsertIntoDb();

        protected void Confirm()
        {
            AssignedAction?.Invoke();

            InsertIntoDb();
        }
    }
}
