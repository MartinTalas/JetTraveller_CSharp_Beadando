
namespace JetTraveller_by_GKPLJP
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.reset_flight = new System.Windows.Forms.Button();
            this.flight_combo_box = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.income_label = new System.Windows.Forms.Label();
            this.n_label = new System.Windows.Forms.Label();
            this.w_label = new System.Windows.Forms.Label();
            this.l_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cost_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.destination_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cost_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.AllowUserToAddRows = false;
            this.customerDataGridView.AllowUserToDeleteRows = false;
            this.customerDataGridView.AllowUserToResizeColumns = false;
            this.customerDataGridView.AllowUserToResizeRows = false;
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView.Location = new System.Drawing.Point(13, 72);
            this.customerDataGridView.Name = "customerDataGridView";
            this.customerDataGridView.Size = new System.Drawing.Size(779, 366);
            this.customerDataGridView.TabIndex = 0;
            // 
            // reset_flight
            // 
            this.reset_flight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset_flight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reset_flight.Location = new System.Drawing.Point(955, 401);
            this.reset_flight.Name = "reset_flight";
            this.reset_flight.Size = new System.Drawing.Size(104, 37);
            this.reset_flight.TabIndex = 1;
            this.reset_flight.Text = "Reset Flight";
            this.reset_flight.UseVisualStyleBackColor = true;
            this.reset_flight.Click += new System.EventHandler(this.reset_flight_Click);
            // 
            // flight_combo_box
            // 
            this.flight_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flight_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flight_combo_box.FormattingEnabled = true;
            this.flight_combo_box.Location = new System.Drawing.Point(129, 21);
            this.flight_combo_box.Name = "flight_combo_box";
            this.flight_combo_box.Size = new System.Drawing.Size(315, 28);
            this.flight_combo_box.TabIndex = 2;
            this.flight_combo_box.SelectedIndexChanged += new System.EventHandler(this.flight_combo_box_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Flights:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(470, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Income:";
            // 
            // income_label
            // 
            this.income_label.AutoSize = true;
            this.income_label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.income_label.Location = new System.Drawing.Point(567, 25);
            this.income_label.Name = "income_label";
            this.income_label.Size = new System.Drawing.Size(0, 24);
            this.income_label.TabIndex = 5;
            // 
            // n_label
            // 
            this.n_label.AutoSize = true;
            this.n_label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.n_label.Location = new System.Drawing.Point(923, 72);
            this.n_label.Name = "n_label";
            this.n_label.Size = new System.Drawing.Size(0, 24);
            this.n_label.TabIndex = 6;
            // 
            // w_label
            // 
            this.w_label.AutoSize = true;
            this.w_label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.w_label.Location = new System.Drawing.Point(923, 113);
            this.w_label.Name = "w_label";
            this.w_label.Size = new System.Drawing.Size(0, 24);
            this.w_label.TabIndex = 7;
            // 
            // l_label
            // 
            this.l_label.AutoSize = true;
            this.l_label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_label.Location = new System.Drawing.Point(923, 154);
            this.l_label.Name = "l_label";
            this.l_label.Size = new System.Drawing.Size(0, 24);
            this.l_label.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(798, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Normal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(798, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Window:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(798, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Large:";
            // 
            // cost_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.cost_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cost_chart.Legends.Add(legend1);
            this.cost_chart.Location = new System.Drawing.Point(802, 193);
            this.cost_chart.Name = "cost_chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series2";
            this.cost_chart.Series.Add(series1);
            this.cost_chart.Size = new System.Drawing.Size(257, 202);
            this.cost_chart.TabIndex = 12;
            this.cost_chart.Text = "chart1";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Black;
            this.pictureBox9.Location = new System.Drawing.Point(802, 185);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(257, 2);
            this.pictureBox9.TabIndex = 27;
            this.pictureBox9.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(798, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 24);
            this.label6.TabIndex = 28;
            this.label6.Text = "Destination:";
            // 
            // destination_label
            // 
            this.destination_label.AutoSize = true;
            this.destination_label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.destination_label.Location = new System.Drawing.Point(928, 25);
            this.destination_label.Name = "destination_label";
            this.destination_label.Size = new System.Drawing.Size(0, 24);
            this.destination_label.TabIndex = 29;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.destination_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.cost_chart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.l_label);
            this.Controls.Add(this.w_label);
            this.Controls.Add(this.n_label);
            this.Controls.Add(this.income_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flight_combo_box);
            this.Controls.Add(this.reset_flight);
            this.Controls.Add(this.customerDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1087, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1087, 489);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control Panel";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cost_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button reset_flight;
        private System.Windows.Forms.ComboBox flight_combo_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label income_label;
        private System.Windows.Forms.Label n_label;
        private System.Windows.Forms.Label w_label;
        private System.Windows.Forms.Label l_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart cost_chart;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label destination_label;
    }
}