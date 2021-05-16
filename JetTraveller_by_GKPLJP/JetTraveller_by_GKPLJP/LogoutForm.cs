using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetTraveller_by_GKPLJP
{
    public partial class LogoutForm : Form
    {
        private bool choice = false;
        public LogoutForm()
        {
            InitializeComponent();
        }
        
        private void LogoutForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void exit_from_logout_Click(object sender, EventArgs e)
        {
            this.choice = false;
            this.Hide();
        }

        private void new_login_Click(object sender, EventArgs e)
        {
            this.choice = true;
            this.Hide();
        }

        public bool getChoice()
        {
            return choice;
        }
    }
}
