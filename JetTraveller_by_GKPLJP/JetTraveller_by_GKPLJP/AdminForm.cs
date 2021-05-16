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
    partial class AdminForm : Form
    {
        private string from = "";
        private string to = "";
        private string selected = "";
        private List<String[]> customers = new List<string[]>(); //teljes lista a customer-eknek
        private List<String[]> ordered_customers = new List<string[]>();//sort-olt lista, minden customer annyiszor szerepel benne, ahányszor submitolt

        private FROMTO flight_from_to;
        Plane plane;
        DataBaseConnection db = new DataBaseConnection();
        private SQLiteCommand command = new SQLiteCommand();

        public AdminForm()
        {
            InitializeComponent();
            this.setComboBox();
            this.setDataGrid();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
        }

        private void flight_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = flight_combo_box.SelectedItem.ToString();
            switch (selected)
            {
                case "Budapest - Barcelona": flight_from_to = FROMTO.BB; break;
                case "Bécs - Mallorca": flight_from_to = FROMTO.BM; break;
                case "Budapest - London": flight_from_to = FROMTO.BL; break;
            }
            Console.WriteLine(selected);
            Console.WriteLine(flight_from_to);
            this.reverseFromto(flight_from_to);

            this.getData();

            this.destination_label.Text = this.to;
        }

        private void setComboBox() //SET COMBOBOX
        {
            flight_combo_box.Items.Add("Budapest - Barcelona");
            flight_combo_box.Items.Add("Bécs - Mallorca");
            flight_combo_box.Items.Add("Budapest - London");
        }

        public void setPlane(Plane p)
        {
            this.plane = p;
        }

        public Plane getPlane()
        {
            return this.plane;
        }

        public void resetPlane() //RESET PLANE
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.plane.seats[i, j].Status = STATUS.FREE;
                }
            }
            this.updateDataBase();
        }

        private void updateDataBase() //UPDATE DATABASE
        {
            command = new SQLiteCommand("UPDATE Flights SET SeatList = \'" + this.plane.makeString() + "\' WHERE From_field = \'" + this.from + "\' AND To_field = \'" + this.to + "\'; ", db.getConnection());
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

        private void reverseFromto(FROMTO from_to) // FROMTO TO STRING
        {
            switch (from_to)
            {
                case FROMTO.BB: this.from = "Budapest"; this.to = "Barcelona"; break;
                case FROMTO.BM: this.from = "Bécs"; this.to = "Mallorca"; break;
                case FROMTO.BL: this.from = "Budapest"; this.to = "London"; break;
            }
        }

        private void reset_flight_Click(object sender, EventArgs e)
        {
            this.resetPlane();
            if(selected != "")
            {
                if (customerDataGridView.Rows.Count > 0)
                {
                    this.deleteData();
                    this.getData();

                    String info = "The changes will become available after exiting the Control Panel!";
                    MessageBox.Show(info);
                }
                else
                {
                    String info = "You can't reset an empty flight!";
                    MessageBox.Show(info);
                }
            }
            else
            {
                String info = "You can't reset an unselected flight!";
                MessageBox.Show(info);
            }
            
            
        }

        private void setDataGrid() //beállítjuk az alap datagridet
        {
            customerDataGridView.Font = new Font("Arial", 16.0F, GraphicsUnit.Pixel);
            customerDataGridView.ColumnCount = 4;
            customerDataGridView.Columns[0].Name = "Customer";
            customerDataGridView.Columns[1].Name = "Tickets";
            customerDataGridView.Columns[2].Name = "Price";
            customerDataGridView.Columns[3].Name = "Discount";

            customerDataGridView.Columns[0].Width = 300;
            customerDataGridView.Columns[1].Width = 90;
            customerDataGridView.Columns[2].Width = 170;
            customerDataGridView.Columns[3].Width = 176;

            customerDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            customerDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            customerDataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            customerDataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void loadDataGrid() //feltöltjük a datagridet
        {
            customerDataGridView.Rows.Clear();

            for (int i = 0; i < this.ordered_customers.Count; i++)
            {
                string[] row = new string[] { ordered_customers[i][0], ordered_customers[i][1], ordered_customers[i][2], ordered_customers[i][3] };
                customerDataGridView.Rows.Add(row);
            }
            cost_chart.Series.Clear();
            cost_chart.Series.Add("income");
            cost_chart.Series["income"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
   
            n_label.Text = costCalculator('N').ToString() + " HUF";
            cost_chart.Series["income"].Points.AddXY("Normal: " + costCalculator('N').ToString() + " HUF", costCalculator('N'));
            cost_chart.Series["income"].Points[0].Color = Color.LightGray;

            w_label.Text = costCalculator('W').ToString() + " HUF";
            cost_chart.Series["income"].Points.AddXY("Windowed: " + costCalculator('W').ToString() + " HUF", costCalculator('W'));
            cost_chart.Series["income"].Points[1].Color = Color.LightCyan;

            l_label.Text = costCalculator('L').ToString() + " HUF";
            cost_chart.Series["income"].Points.AddXY("Large: " + costCalculator('L').ToString() + " HUF", costCalculator('L'));
            cost_chart.Series["income"].Points[2].Color = Color.LightGreen;

            income_label.Text = costCalculator('-').ToString() + " HUF";
        }

        private int costCalculator(char param)
        {
            int result = 0;
            if(param == 'W')
            {
                for (int i = 0; i < customers.Count - 1; i++)
                {
                    if (customers[i][2] == "WINDOW")
                    {
                        result += Convert.ToInt32(customers[i][3]);
                    } 
                }
            }
            else if(param == 'N')
            {
                for (int i = 0; i < customers.Count - 1; i++)
                {
                    if (customers[i][2] == "NORMAL")
                    {
                        result += Convert.ToInt32(customers[i][3]);
                    }
                }
            }
            else if(param == 'L')
            {
                for (int i = 0; i < customers.Count - 1; i++)
                {
                    if (customers[i][2] == "LARGE")
                    {
                        result += Convert.ToInt32(customers[i][3]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < customers.Count - 1; i++)
                {
                    result += Convert.ToInt32(customers[i][3]);
                }
            }

            return result;
        }

        private void getData() //GET DATA FROM DATABASE
        {

            customers.Clear();
            ordered_customers.Clear();

            command = new SQLiteCommand("SELECT * FROM Tickets WHERE From_To = \'" + this.flight_from_to + "\'", db.getConnection());

            try
            {
                db.openConnection();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] tmp = new string[5];
                    tmp[0] = reader.GetString(0);
                    tmp[1] = reader.GetString(1);
                    tmp[2] = reader.GetString(2);
                    tmp[3] = reader.GetInt32(3).ToString();

                    string discount = "0%";

                    if (reader.GetString(4) == "KEDVEZMENY5")
                    {
                        discount = "5%";
                    }
                    else if (reader.GetString(4) == "KEDVEZMENY10")
                    {
                        discount = "10%";
                    }
                    tmp[4] = discount;

                    customers.Add(tmp);
                }
                db.closeConnection();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }

            //BUGFIX-----------------------------
            string[] last = new string[5];
            for (int i = 0; i < 5; i++) 
            {
                last[i] = "-1";
            }
            customers.Add(last);
            //-----------------------------------

            //sortolás az ordered_customers listába
            string customer = "";
            if (customers.Count != 0) customer = customers[0][0];
            
            int counter = 0;
            int price = 0;

            for (int i = 0; i < customers.Count; i++)
            {
                if (customer != customers[i][0])
                {
                    string[] tmp = new string[4];
                    tmp[0] = customer;
                    tmp[1] = counter.ToString();
                    tmp[2] = price.ToString();
                    tmp[3] = customers[i-1][4];
                    ordered_customers.Add(tmp);
                    counter = 1;
                    price = Convert.ToInt32(customers[i][3]);
                    customer = customers[i][0];
                }
                else
                {
                    counter++;
                    price += Convert.ToInt32(customers[i][3]);
                }
            }

            this.loadDataGrid();
        }

        private void deleteData() //járat törlésekor törli ezeket az adatokat is! (a törlés lehet 2 okból! vagy törlik, vagy felszállt!)
        {
            command = new SQLiteCommand("DELETE FROM Tickets WHERE From_To = \'" + this.flight_from_to + "\'", db.getConnection());
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
    }
}
