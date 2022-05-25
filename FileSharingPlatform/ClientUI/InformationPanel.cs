using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUI
{
    public partial class InformationPanel : UserControl
    {
        public InformationPanel()
        {
            InitializeComponent();
        }
        public InformationPanel(string ID,string path) : this() {
            //根据ID+path查找  回fileitem对象。
            //根据此对象，初始化三个标签的内容
        }

    }
}
