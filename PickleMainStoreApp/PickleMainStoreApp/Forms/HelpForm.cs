using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickleMainStoreApp.Forms
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = "../../Assets/warning1.png";
            pictureBox2.ImageLocation = "../../Assets/warning2.png";
            pictureBox3.ImageLocation = "../../Assets/warning3.png";
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
