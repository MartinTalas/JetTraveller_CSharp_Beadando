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
    partial class TransactionForm : Form
    {
        private bool finished = false; //befejezte-e a kitöltést
        private bool submit = false; //feltétel, hogy submitolható-e
        private string name = ""; //név, amit a jegyhez társítunk
        public List<Ticket> tickets = new List<Ticket>(); //a jegyeink listája

        public TransactionForm(List<Ticket> t)
        {
            InitializeComponent();
            this.tickets = t;
            setDataGrid();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.customer_picturebox.BackColor = Color.Gray;
        }

        private void submitTransactionButton_Click(object sender, EventArgs e)
        {
            if (this.finished)
            {
                for (int i = 0; i < this.tickets.Count; i++)
                {
                    this.tickets[i].Name = this.name;
                    this.tickets[i].saveTicket();
                }

                this.submit = true;
                this.Hide();
            }
        }

        private void cancelTransactionButton_Click(object sender, EventArgs e)
        {
            this.submit = false;
            this.Hide();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(this.nameTextBox.Text.Length > 0)
            {
                this.finished = true;
                this.customer_picturebox.BackColor = Color.Green;
            }
            else
            {
                this.finished = false;
                this.customer_picturebox.BackColor = Color.Red;
            }

            this.name = this.nameTextBox.Text;
            Console.WriteLine(this.name);
        }

        public bool isSubmitted()//visszaadja a submit változót
        {
            return this.submit;
        }

        public string getName() //visszaadja a nevet
        {
            return this.name;
        }

        private void setDataGrid()//beállítja a datagridet, amin láthatjuk, hogy mit készülünk megvenni, szöveges formában
        {
            myDataGridView.Font = new Font("Arial", 16.0F, GraphicsUnit.Pixel);
            myDataGridView.ColumnCount = 3;
            myDataGridView.Columns[0].Name = "Count";
            myDataGridView.Columns[1].Name = "Ticket Type";
            myDataGridView.Columns[2].Name = "Price";

            myDataGridView.Columns[0].Width = 60;
            myDataGridView.Columns[1].Width = 170;
            myDataGridView.Columns[2].Width = 243;

            myDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            myDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            myDataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            for (int i = 0; i < this.tickets.Count; i++)
            {
                string[] row = new string[] {(i+1).ToString(), tickets[i].Type.ToString(), tickets[i].Price.ToString()};
                myDataGridView.Rows.Add(row);
            }

            if(this.tickets.Count > 0) //a felsorolás végén megjelenítjük az össz értéket is
            {
                int result = 0;

                for (int i = 0; i < this.tickets.Count; i++)
                {
                    result += this.tickets[i].Price;
                }

                string[] row = new string[] { "", "", "" };
                myDataGridView.Rows.Add(row);
                row = new string[] { "", "Total: ", result.ToString() };
                myDataGridView.Rows.Add(row);

                //illetve megjelenítjük a kupont is
                string discount = "0%";

                if(tickets[0].Discount == "KEDVEZMENY5")
                {
                    discount = "5%";
                }
                else if (tickets[0].Discount == "KEDVEZMENY10")
                {
                    discount = "10%";
                }

                row = new string[] { "", "Discount: ", discount };
                myDataGridView.Rows.Add(row);
            }
        }
    }
}
