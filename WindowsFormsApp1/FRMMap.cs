using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FRMMap : Form
    {
        mapClass map;
        public FRMMap()
        {
            InitializeComponent();
        }

        private void BTNMapSubmit_Click(object sender, EventArgs e)
        {
            map = new mapClass(20, PTBMap, PGBMapProgress);
            map.generate(2, 2, 5);

        }
    }
}
