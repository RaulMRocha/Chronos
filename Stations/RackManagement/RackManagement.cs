using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronos.Stations.RackManagement
{
    public partial class RackManagement : UserControl
    {
        public bool ConnectToProd { get; set; }
        public RackManagement()
        {
            InitializeComponent();
        }
    }
}
