using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chronos.Data.Shared;

namespace Chronos.Modules.Consolidation
{
    public partial class LineConsolidation : UserControl
    {
        private IChronosGlobal _chronosGlobal;

        public LineConsolidation(IChronosGlobal chronosGlobal)
        {
            InitializeComponent();
        }
    }
}
