using Storager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Misc
{
    public class SortModeAndOrder
    {
        public eSortMode Mode { get; set; } = eSortMode.NAME;
        public eSortOrder Order { get; set; } = eSortOrder.ASCENDING;
    }
}
