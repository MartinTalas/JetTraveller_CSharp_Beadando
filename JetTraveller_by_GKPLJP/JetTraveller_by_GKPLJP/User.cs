using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetTraveller_by_GKPLJP
{
    enum PERMISSION
    {
        ADMIN,
        GUEST,
        DENIED
    }

    class User: UserInterface
    {
        private string username;
        private string password;
        private int price;
        private List<Ticket> tickets = new List<Ticket>();
        private List<Seat> seats = new List<Seat>();
        private DataBaseConnection db = new DataBaseConnection();
        private SQLiteCommand command = new SQLiteCommand();
        private PERMISSION permission;
       
        public string Username 
        {
            get { return this.username; } 
            set { this.username = value; }
        }
        public string Password 
        {
            get { return this.password; } 
            set { this.password = value; }
        }
        public List<Ticket> Tickets 
        {
            get { return this.tickets; }  
            set { this.tickets = value; }
        }
        public int Price 
        {
            get { return this.price; } 
            set { this.price = value; }
        }
        public List<Seat> Seats 
        {
            get { return this.seats; } 
            set { this.seats = value; }
        }

        public PERMISSION Permission
        {
            get { return this.permission; }
            set { this.permission = value; }
        }

        public User() { }
        public User(string usern, string passw)
        {
            this.Username = usern;
            this.Password = passw;
            setPermission(this.Username, this.Password);
        }
        public int getData()
        {
            command = new SQLiteCommand("SELECT permission FROM User WHERE username = \'" + username + "\'", db.getConnection());
            int result = -1;
            try
            {
                db.openConnection();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    result = reader.GetInt32(0);
                }
                db.closeConnection();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
            return result;
        }
        private void setPermission(string usern, string passw)
        {
            int perm = this.getData();
            if (perm == 1)
            {
                this.Permission = PERMISSION.ADMIN;
            }
            else if(perm == 0)
            {
                this.Permission = PERMISSION.GUEST;
            }
            else
            {
                Console.WriteLine("[SET PERMISSION: FAILED]: INVALID PERMISSION!");
            }
        }

        public void reset()
        {
            this.Username = "";
            this.Password = "";
            this.price = 0;
            this.tickets.Clear();
            this.seats.Clear();
            this.Permission = PERMISSION.DENIED;
        }
    }
}
