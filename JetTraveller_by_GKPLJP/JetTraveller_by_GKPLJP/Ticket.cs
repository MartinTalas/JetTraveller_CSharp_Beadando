using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetTraveller_by_GKPLJP
{
    enum TICKET_TYPE
    {
        NORMAL,
        WINDOW,
        LARGE
    }

    enum FROMTO
    {
        //Budapest - Barcelona, Bécs - Mallorca, Budapest - London
        BB, //Budapest - Barcelona
        BM, //Bécs - Mallorca
        BL  //Budapest - London
    }
    class Ticket
    {
        private TICKET_TYPE type;
        private FROMTO from_to;
        private string from;
        private string to;
        private string name;
        private int price;
        private string discount = "NONE";
        private DataBaseConnection db = new DataBaseConnection();
        private SQLiteCommand command = new SQLiteCommand();

        public TICKET_TYPE Type
        {
            get { return type; }
            set { this.type = value; }
        }

        public FROMTO FromTo
        {
            get { return from_to; }
            set { this.from_to = value; }
        }

        public string From
        {
            get { return this.from; }
            set { this.from = value; }
        }
        public string To
        {
            get { return this.to; }
            set { this.to = value; }
        }
        public string Discount
        {
            get { return this.discount; }
            set { this.discount = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public Ticket() { }
        public Ticket(FROMTO param1, TICKET_TYPE param2, string discount)
        {
            this.FromTo = param1;
            this.setFromToStrings(this.FromTo);
            this.Type = param2;
            this.Price = this.getPrice();
            this.Discount = discount;

            if(this.Discount == "KEDVEZMENY5")
            {
                double tmp = Convert.ToDouble(this.Price) * 0.05;
                int result = Convert.ToInt32(tmp);
                this.Price -= result;
            }
            else if(this.Discount == "KEDVEZMENY10")
            {
                double tmp = Convert.ToDouble(this.Price) * 0.1;
                int result = Convert.ToInt32(tmp);
                this.Price -= result;
            }
        }

        public int getPrice() //GET DATA FROM DATABASE
        {
            command = new SQLiteCommand("SELECT * FROM Prices WHERE seat = \'"+ this.Type.ToString() +"\'", db.getConnection());
            int result = -1;
            try
            {
                db.openConnection();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine(reader.GetInt32(0));
                    result = reader.GetInt32(0);
                }
                db.closeConnection();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
            return result;
        }

        public void saveTicket() //SAVE DATA TO DATABASE
        {
            command = new SQLiteCommand("INSERT INTO Tickets (Customer, From_To, Ticket_Type, Price, Discount) VALUES(\'" + this.Name + "\', \'" + this.FromTo.ToString() + "\', \'"+ this.Type.ToString() + "\'," + this.Price + ", \'"+ this.Discount +"\')", db.getConnection());
            try
            {
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void setFromToStrings(FROMTO param)
        {
            switch(param)
            {
                case FROMTO.BB: this.From = "Budapest"; this.To = "Barcelona"; break; 
                case FROMTO.BL: this.From = "Bécs"; this.To = "Mallorca"; break;
                case FROMTO.BM: this.From = "Budapest"; this.To = "London"; break;
            }
        }
    }
}
