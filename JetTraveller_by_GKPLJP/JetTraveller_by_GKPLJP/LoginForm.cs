using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetTraveller_by_GKPLJP
{
    public partial class LoginForm : Form
    {
        private List<string[]> users = new List<string[]>();
        private string logged_username = "";
        private string logged_password = "";
        private DataBaseConnection db = new DataBaseConnection();
        private SQLiteCommand command = new SQLiteCommand();

        public string Username
        {
            get { return this.logged_username; }
        }
        public string Password
        {
            get { return this.logged_password; }
        }

        public LoginForm()
        {
            this.BackColor = Color.White;
            InitializeComponent();
            this.getData();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.username_picturebox.BackColor = Color.Gray;
            this.password_picturebox.BackColor = Color.Gray;
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            if(check())
            {
                this.Close();
            }
            else
            {
                String info = "Incorrect Password or Username!";
                MessageBox.Show(info);
            }
        }

        private bool check()
        {
            string[] tmp_user = new string[2];
            tmp_user[0] = logged_username;
            tmp_user[1] = logged_password;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i][0] == tmp_user[0] && users[i][1] == tmp_user[1])
                {
                    this.username_picturebox.BackColor = Color.Green;
                    this.password_picturebox.BackColor = Color.Green;
                    return true;
                }
                else
                {
                    this.username_picturebox.BackColor = Color.Red;
                    this.password_picturebox.BackColor = Color.Red;
                }
            }
            return false;
        }

        public void getData()
        {
            command = new SQLiteCommand("SELECT username, password FROM User", db.getConnection());

            try
            {
                db.openConnection();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("USER: " + reader.GetString(0));
                    Console.WriteLine("PASS: " + reader.GetString(1));
                    
                    string[] tmp_user = new string[2];
                    tmp_user[0] = reader.GetString(0);
                    tmp_user[1] = reader.GetString(1);
                    users.Add(tmp_user);

                }
                db.closeConnection();
            }
            catch(SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Username_txtbox_TextChanged(object sender, EventArgs e)
        {
            this.logged_username = Username_txtbox.Text;
            Console.WriteLine(logged_username);

            if (Username_txtbox.Text == "")
            {
                this.username_picturebox.BackColor = Color.Gray;
            }
        }

        private void Password_txtbox_TextChanged(object sender, EventArgs e)
        {
            this.logged_password = Password_txtbox.Text;
            Console.WriteLine(logged_password);

            if (Password_txtbox.Text == "")
            {
                this.password_picturebox.BackColor = Color.Gray;
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
