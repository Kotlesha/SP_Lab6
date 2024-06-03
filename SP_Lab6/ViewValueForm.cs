using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Lab6
{
    public partial class ViewValueForm : Form
    {
        public ViewValueForm(string valueName, string value)
        {
            InitializeComponent();
            this.valueName.Text = valueName;
            this.value.Text = value;
        }
    }
}
