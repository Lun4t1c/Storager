using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowSettingsViewModel : Conductor<object>
    {
        #region Properties

        #endregion

        #region Constructor
        public WindowSettingsViewModel(Enums.eSettingsPages page = Enums.eSettingsPages.General)
        {
            switch (page)
            {
                case Enums.eSettingsPages.General:
                    Console.WriteLine("Switching to general");
                    break;

                case Enums.eSettingsPages.Database:
                    Console.WriteLine("Switching to database");
                    break;

                default:
                    Console.WriteLine("Default");
                    break;
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}
