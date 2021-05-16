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
    public partial class Form1 : Form
    {
        private string username = "";
        private string password = "";

        private string discount = "NONE";
        private string from_discount_textbox = "";

        private int[,] actual_plane_data = new int[12, 4];
        private FROMTO actual_from_to = FROMTO.BB;
        private string from;
        private string to;
        private int public_index = 0;

        PictureBox upper = new PictureBox(); //DESIGN ELEMENT
        PictureBox lower = new PictureBox(); //DESIGN ELEMENT
        PictureBox[,] visualized_seats = new PictureBox[12, 4];
        private bool cold_start = true;

        private User user;
        private Plane[] planes = new Plane[3];
        private DataBaseConnection db = new DataBaseConnection();
        private SQLiteCommand command = new SQLiteCommand();

        public Form1()
        {
            FROMTO[] f_arr = { FROMTO.BB, FROMTO.BM, FROMTO.BL };
            this.BackgroundImage = Properties.Resources.bg;
            InitializeComponent();
            this.setComboBox();
            this.login();

            this.reverseFromto(actual_from_to);
            actual_plane_data = this.getData(from, to);

            for (int i = 0; i < 3; i++)
            {
                planes[i] = new Plane(f_arr[i]);
            }

            submit_btn.Enabled = false;
        }

        void refresh(object sender, EventArgs e) //saját event az időhöz
        {
            time_label.Text = DateTime.Now.ToString("HH:mm:ss");
            day_label.Text = DateTime.Now.ToString("yyyy, MMM dd.\ndddd");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(refresh);
            timer.Start();

            time_label.Text = DateTime.Now.ToString("HH:mm:ss");
            day_label.Text = DateTime.Now.ToString("yyyy MMM dd.\ndddd");

            discount_status_picturebox.BackColor = Color.Gray;
            label1.BackColor = Color.Transparent;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e) //CREDITS
        {
            String info = "Készítette: Tálas Martin [GKPLJP]\nKészítés éve: 2021";
            MessageBox.Show(info);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //EXIT
        {
            Application.Exit();
        }

        private void login() //LOGIN SYSTEM
        {
            this.Enabled = false;

            using (LoginForm load_login = new LoginForm())
            {
                if (load_login.ShowDialog() == DialogResult.OK) { }

                this.username = load_login.Username;
                this.password = load_login.Password;
            }

            this.Enabled = true;

            user = new User(this.username, this.password);
            Console.WriteLine("Permission: {0}", user.Permission);
            this.Text = "JetTraveller by GKPLJP (" + username + ")";

            if(user.Permission == PERMISSION.ADMIN)
            {
                controlpanel_btn.Visible = true;
                submit_btn.Visible = false;
                cancel_btn.Visible = false;
                discount_activate.Visible = false;
                discount_textbox.Visible = false;
                discount_label.Visible = false;
                discount_status_picturebox.Visible = false;
            }
            else
            {
                controlpanel_btn.Visible = false;
                submit_btn.Visible = true;
                cancel_btn.Visible = true;
                discount_activate.Visible = true;
                discount_textbox.Visible = true;
                discount_label.Visible = true;
                discount_status_picturebox.Visible = true;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e) //LOGIN SYSTEM
        {
            this.Text = "JetTraveller by GKPLJP";
            bool result = false;
            this.Enabled = false;

            using (LogoutForm load_logout = new LogoutForm())
            {
                if (load_logout.ShowDialog() == DialogResult.OK) { }

                result = load_logout.getChoice();
            }

            this.Enabled = true;
            user.reset();

            if(result)
            {
                this.login();
            }
            else
            {
                Application.Exit();
            }
        }

        private void from_to_combobox_SelectedIndexChanged(object sender, EventArgs e) //GET SELECTED FLIGHT FROM COMBOBOX
        {
            string selected = from_to_combobox.SelectedItem.ToString();
            switch(selected)
            {
                case "Budapest - Barcelona": actual_from_to = FROMTO.BB; break;
                case "Bécs - Mallorca": actual_from_to = FROMTO.BM; break;
                case "Budapest - London": actual_from_to = FROMTO.BL; break;
            }
            //Console.WriteLine(selected);
            //Console.WriteLine(actual_from_to);
            
            submit_btn.Enabled = true;

            bool once = true;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(!cold_start)
                    {
                        this.Controls.Remove(visualized_seats[i, j]);
                    }
                    cold_start = false;
                }

                if (once)
                {
                    this.Controls.Remove(upper);
                    this.Controls.Remove(lower);
                    once = false;
                }
            }

            this.updater();
            this.visualizate();
        }

        private void setComboBox() //SET COMBOBOX
        {
            from_to_combobox.Items.Add("Budapest - Barcelona");
            from_to_combobox.Items.Add("Bécs - Mallorca");
            from_to_combobox.Items.Add("Budapest - London");
        }

        private void reverseFromto(FROMTO from_to) // FROMTO TO STRING
        {
            switch(from_to)
            {
                case FROMTO.BB: this.from = "Budapest";  this.to = "Barcelona"; break;
                case FROMTO.BM: this.from = "Bécs"; this.to = "Mallorca"; break;
                case FROMTO.BL: this.from = "Budapest"; this.to = "London"; break;
            }
        }

        private int[,] getData(string f, string t) //GET DATA FROM DATABASE
        {
            int[,] temp = new int[12, 4];
            command = new SQLiteCommand("SELECT seatList FROM Flights WHERE From_field=\'" + f + "\'" + " AND To_field=\'" + t + "\'", db.getConnection());

            string res = "";

            try
            {
                db.openConnection();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = reader.GetString(0);

                    string[] tmpstr = new string[12];
                    tmpstr = res.Split('+');
                    for (int i = 0; i < tmpstr.Length; i++)
                    {
                        string[] convert_this = new string[4];
                        convert_this = tmpstr[i].Split('_');

                        for (int j = 0; j < convert_this.Length; j++)
                        {
                            temp[i, j] = Convert.ToInt32(convert_this[j]);
                        }
                    }
                }
                db.closeConnection();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
                temp[0, 0] = 9;
            }

            return temp;
        }
    
        private void updater() //REFRESH THE SEATS OF THE PLANE
        {
            bool once = true;
            this.reverseFromto(actual_from_to);
            actual_plane_data = this.getData(from, to);

            for (int i = 0; i < planes.Length; i++)
            {
                if(planes[i].FT == actual_from_to)
                {
                    if(once)
                    {
                        public_index = i;
                        once = false;
                    }
                    
                    for (int j = 0; j < 12; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            switch(actual_plane_data[j, k])
                            {
                                case 0: planes[i].seats[j, k].Status = STATUS.FREE; break;
                                case 1: planes[i].seats[j, k].Status = STATUS.BOOKING; break;
                                case 2: planes[i].seats[j, k].Status = STATUS.BOOKED; break;
                                case 3: planes[i].seats[j, k].Status = STATUS.COVID; break;
                                default: Console.WriteLine("SOMETHING WENT WRONG: [FORM1: UPDATER]"); break;
                            }
                            Console.Write(planes[i].seats[j, k].Status + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine(public_index);
        }

        private void visualizate() //GENERATE PICTUREBOXES
        {
            upper = new PictureBox();
            lower = new PictureBox();
            
            int H = 198, W = 278;
            
            upper.Location = new Point(W, H - 20);

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    visualized_seats[i, j] = new PictureBox();
                    
                    visualized_seats[i, j].Height = 32;
                    visualized_seats[i, j].Width = 32;

                    visualized_seats[i, j].Visible = true;
                    visualized_seats[i, j].Cursor = Cursors.Hand;
                    visualized_seats[i, j].Click += this.SeatClick;

                    this.Controls.Add(visualized_seats[i, j]);
                }

                visualized_seats[i, 0].Location = new Point(W, H);
                visualized_seats[i, 1].Location = new Point(W, H + 40);
                visualized_seats[i, 2].Location = new Point(W, H + 100);
                visualized_seats[i, 3].Location = new Point(W, H + 140);

                W += 40;
            }
            lower.Location = new Point(278, H + 192);

            upper.Height = 2;
            lower.Height = 2;
            upper.Width = 472;
            lower.Width = 472;
            upper.Visible = true;
            lower.Visible = true;
            upper.BackColor = Color.Black;
            lower.BackColor = Color.Black;
            this.Controls.Add(upper);
            this.Controls.Add(lower);

            this.colorize();
        }

        private void colorize()//COLORIZE FOR THE PICTUREBOXES
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (planes[public_index].seats[i, j].Status)
                    {
                        case STATUS.FREE:
                            if(planes[public_index].seats[i, j].Type == SEAT_TYPE.NORMAL)
                            {
                                visualized_seats[i, j].BackColor = Color.LightGray;
                                visualized_seats[i, j].Cursor = Cursors.Hand;
                            }
                            else if (planes[public_index].seats[i, j].Type == SEAT_TYPE.WINDOW)
                            {
                                visualized_seats[i, j].BackColor = Color.LightCyan;
                                visualized_seats[i, j].Cursor = Cursors.Hand;
                            }
                            else if (planes[public_index].seats[i, j].Type == SEAT_TYPE.LARGE)
                            {
                                visualized_seats[i, j].BackColor = Color.LightGreen;
                                visualized_seats[i, j].Cursor = Cursors.Hand;
                            }
                            break;
                        case STATUS.BOOKING: visualized_seats[i, j].BackColor = Color.Yellow; visualized_seats[i, j].Cursor = Cursors.Hand; break;
                        case STATUS.BOOKED: visualized_seats[i, j].BackColor = Color.DeepSkyBlue; visualized_seats[i, j].Cursor = Cursors.No; break;
                        case STATUS.COVID: visualized_seats[i, j].BackColor = Color.Red; visualized_seats[i, j].Cursor = Cursors.No; break;
                    }
                }
            }
        }

        private void SeatClick(object sender, EventArgs e) //EVENTHANDLER TO THE DYNAMIC PICTUREBOXES
        {
            if(user.Permission == PERMISSION.GUEST)
            {
                PictureBox clicked = (PictureBox)sender;

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if(clicked == visualized_seats[i, j])
                        {
                            if (clicked.BackColor == Color.LightGray || clicked.BackColor == Color.LightCyan || clicked.BackColor == Color.LightGreen)
                            {
                                clicked.BackColor = Color.Yellow;
                                this.booking();
                            }
                            else if (clicked.BackColor == Color.Yellow)
                            {
                                switch(planes[public_index].seats[i, j].Type)
                                {
                                    case SEAT_TYPE.NORMAL: clicked.BackColor = Color.LightGray; break;
                                    case SEAT_TYPE.WINDOW: clicked.BackColor = Color.LightCyan;  break;
                                    case SEAT_TYPE.LARGE: clicked.BackColor = Color.LightGreen; break;
                                }
                                this.booking();
                            }
                        }
                    }
                }
            }
        }

        private void booking()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (visualized_seats[i, j].BackColor == Color.Yellow)
                    {
                        planes[public_index].seats[i, j].Status = STATUS.BOOKING;
                    }
                    else if (visualized_seats[i, j].BackColor == Color.LightGray)
                    {
                        planes[public_index].seats[i, j].Status = STATUS.FREE;
                    }
                    else if (visualized_seats[i, j].BackColor == Color.LightCyan)
                    {
                        planes[public_index].seats[i, j].Status = STATUS.FREE;
                    }
                    else if (visualized_seats[i, j].BackColor == Color.LightGreen)
                    {
                        planes[public_index].seats[i, j].Status = STATUS.FREE;
                    }
                }
            }
        }

        private List<Ticket> ticketMaker(FROMTO ft_fata)
        {
            List<Ticket> tmp = new List<Ticket>();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (planes[public_index].seats[i, j].Status == STATUS.BOOKING)
                    {
                        TICKET_TYPE ticket_type;
                        switch (planes[public_index].seats[i, j].Type)
                        {
                            case SEAT_TYPE.NORMAL: ticket_type = TICKET_TYPE.NORMAL; break;
                            case SEAT_TYPE.WINDOW: ticket_type = TICKET_TYPE.WINDOW; break;
                            case SEAT_TYPE.LARGE: ticket_type = TICKET_TYPE.LARGE; break;
                            default: ticket_type = TICKET_TYPE.NORMAL; break;
                        }
                        tmp.Add(new Ticket(ft_fata, ticket_type, discount));
                    }
                }
            }

            discount = "NONE";
            return tmp;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            bool can_I_submit = false;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(planes[public_index].seats[i, j].Status == STATUS.BOOKING)
                    {
                        can_I_submit = true;
                        break;
                    }
                }
            }

            if(can_I_submit)
            {
                this.Enabled = false;

                using (TransactionForm transactionForm = new TransactionForm(this.ticketMaker(planes[public_index].FT)))
                {
                    if (transactionForm.ShowDialog() == DialogResult.OK) { }
                    
                    if(transactionForm.isSubmitted())
                    {
                        this.submit();
                        this.saveSeats();

                        String info = "Your booking has been completed successfully!";
                        MessageBox.Show(info);
                    }
                    else
                    {
                        this.cancel();
                    }
                }

                this.Enabled = true;

                discount_textbox.Clear();
                discount = "NONE";
                discount_status_picturebox.BackColor = Color.Gray;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.cancel();

            discount_textbox.Clear();
            discount = "NONE";
            discount_status_picturebox.BackColor = Color.Gray;
        }

        private void discount_activate_Click(object sender, EventArgs e)
        {
            if(from_discount_textbox == "KEDVEZMENY5")
            {
                discount = "KEDVEZMENY5";
                discount_status_picturebox.BackColor = Color.Green;
            }
            else if(from_discount_textbox == "KEDVEZMENY10")
            {
                discount = "KEDVEZMENY10";
                discount_status_picturebox.BackColor = Color.Green;
            }
            else if (from_discount_textbox == "")
            {
                discount = "NONE";
                discount_status_picturebox.BackColor = Color.Gray;
            }
            else
            {
                discount = "NONE";
                discount_status_picturebox.BackColor = Color.Red;
            }
        }
        
        private void discount_textbox_TextChanged(object sender, EventArgs e)
        {
            from_discount_textbox = discount_textbox.Text;

            if(from_discount_textbox.Length == 0)
            {
                discount_status_picturebox.BackColor = Color.Gray;
            }
        }

        private void controlpanel_btn_Click(object sender, EventArgs e)
        {
            using (AdminForm adminForm = new AdminForm())
            {
                adminForm.setPlane(planes[public_index]);

                if (adminForm.ShowDialog() == DialogResult.OK) { }

                planes[public_index] = adminForm.getPlane();

                if (!cold_start)
                {
                    this.colorize();
                }
            }
        }

        private void cancel()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (planes[public_index].seats[i, j].Status == STATUS.BOOKING)
                    {
                        planes[public_index].seats[i, j].Status = STATUS.FREE;
                        this.colorize();
                    }
                }
            }
        }

        public void saveSeats() //SAVE DATA TO DATABASE
        {
            command = new SQLiteCommand("UPDATE Flights SET SeatList = \'" + this.planes[public_index].makeString() + "\' WHERE From_field = \'" + this.from + "\' AND To_field = \'" + this.to + "\'; ", db.getConnection());
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

        private void submit()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (planes[public_index].seats[i, j].Status == STATUS.BOOKING)
                    {
                        planes[public_index].seats[i, j].Status = STATUS.BOOKED;

                        this.socialDistance(i, j);

                        this.colorize();
                    }
                }
            }
        }

        private void socialDistance(int i, int j)
        {
            int distance1_i_min = i - 1;
            int distance1_i_max = i + 1;
            int distance1_j_min = j - 1;
            int distance1_j_max = j + 1;

            int distance2_i_min = i - 2;
            int distance2_i_max = i + 2;
            int distance2_j_min = j - 2;
            int distance2_j_max = j + 2;

            //--------------------------[ LINEAR SIDE ONLY ]--------------------------
            if (distance1_i_max < 12) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i + 1, j].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i + 1, j].Status = STATUS.COVID;
                }

                if (distance2_i_max < 12) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 2, j].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 2, j].Status = STATUS.COVID;
                    }
                }
            }

            if (distance1_i_min > -1) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i - 1, j].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i - 1, j].Status = STATUS.COVID;
                }

                if (distance2_i_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 2, j].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 2, j].Status = STATUS.COVID;
                    }
                }
            }

            if (distance1_j_max < 4) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i, j + 1].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i, j + 1].Status = STATUS.COVID;
                }

                if (distance2_j_max < 4) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i, j + 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i, j + 2].Status = STATUS.COVID;
                    }
                }
            }

            if (distance1_j_min > -1) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i, j - 1].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i, j - 1].Status = STATUS.COVID;
                }

                if (distance2_j_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i, j - 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i, j - 2].Status = STATUS.COVID;
                    }
                }
            }
            //------------------------------------------------------------------------

            //----------------------------[ DIAGONAL ONLY ]---------------------------
            if (distance1_i_max < 12 && distance1_j_max < 4) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i + 1, j + 1].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i + 1, j + 1].Status = STATUS.COVID;
                }

                if (distance2_i_max < 12 && distance2_j_max < 4) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 2, j + 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 2, j + 2].Status = STATUS.COVID;
                    }
                }

                if (distance2_i_max < 12) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 2, j + 1].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 2, j + 1].Status = STATUS.COVID;
                    }
                }

                if (distance2_j_max < 4) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 1, j + 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 1, j + 2].Status = STATUS.COVID;
                    }
                }
            }

            if (distance1_i_max < 12 && distance1_j_min > -1) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i + 1, j - 1].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i + 1, j - 1].Status = STATUS.COVID;
                }

                if (distance2_i_max < 12 && distance2_j_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 2, j - 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 2, j - 2].Status = STATUS.COVID;
                    }
                }

                if (distance2_i_max < 12) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 2, j - 1].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 2, j - 1].Status = STATUS.COVID;
                    }
                }

                if (distance2_j_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i + 1, j - 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i + 1, j - 2].Status = STATUS.COVID;
                    }
                }
            }

            if (distance1_i_min > -1 && distance1_j_max < 4) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i - 1, j + 1].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i - 1, j + 1].Status = STATUS.COVID;
                }

                if (distance2_i_min > -1 && distance2_j_max < 4) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 2, j + 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 2, j + 2].Status = STATUS.COVID;
                    }
                }

                if (distance2_i_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 2, j + 1].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 2, j + 1].Status = STATUS.COVID;
                    }
                }

                if (distance2_j_max < 4) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 1, j + 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 1, j + 2].Status = STATUS.COVID;
                    }
                }
            }

            if (distance1_i_min > -1 && distance1_j_min > -1) // [ DISTANCE 1 ]
            {
                if (planes[public_index].seats[i - 1, j - 1].Status == STATUS.FREE)
                {
                    planes[public_index].seats[i - 1, j - 1].Status = STATUS.COVID;
                }

                if (distance2_i_min > -1 && distance2_j_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 2, j - 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 2, j - 2].Status = STATUS.COVID;
                    }
                }

                if (distance2_i_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 2, j - 1].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 2, j - 1].Status = STATUS.COVID;
                    }
                }

                if (distance2_j_min > -1) // [ DISTANCE 2 ]
                {
                    if (planes[public_index].seats[i - 1, j - 2].Status == STATUS.FREE)
                    {
                        planes[public_index].seats[i - 1, j - 2].Status = STATUS.COVID;
                    }
                }
            }
            //------------------------------------------------------------------------
        }
    }
}
