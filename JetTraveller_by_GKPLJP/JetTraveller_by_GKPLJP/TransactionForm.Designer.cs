
namespace JetTraveller_by_GKPLJP
{
    partial class TransactionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.onlyTextLabel1 = new System.Windows.Forms.Label();
            this.cancelTransactionButton = new System.Windows.Forms.Button();
            this.submitTransactionButton = new System.Windows.Forms.Button();
            this.myDataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.customer_picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameTextBox.Location = new System.Drawing.Point(173, 97);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(359, 29);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // onlyTextLabel1
            // 
            this.onlyTextLabel1.AutoSize = true;
            this.onlyTextLabel1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.onlyTextLabel1.Location = new System.Drawing.Point(12, 100);
            this.onlyTextLabel1.Name = "onlyTextLabel1";
            this.onlyTextLabel1.Size = new System.Drawing.Size(155, 23);
            this.onlyTextLabel1.TabIndex = 1;
            this.onlyTextLabel1.Text = "Customer name:";
            // 
            // cancelTransactionButton
            // 
            this.cancelTransactionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelTransactionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelTransactionButton.Location = new System.Drawing.Point(15, 592);
            this.cancelTransactionButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelTransactionButton.Name = "cancelTransactionButton";
            this.cancelTransactionButton.Size = new System.Drawing.Size(255, 57);
            this.cancelTransactionButton.TabIndex = 2;
            this.cancelTransactionButton.Text = "Cancel";
            this.cancelTransactionButton.UseVisualStyleBackColor = true;
            this.cancelTransactionButton.Click += new System.EventHandler(this.cancelTransactionButton_Click);
            // 
            // submitTransactionButton
            // 
            this.submitTransactionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitTransactionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.submitTransactionButton.Location = new System.Drawing.Point(278, 592);
            this.submitTransactionButton.Margin = new System.Windows.Forms.Padding(0);
            this.submitTransactionButton.Name = "submitTransactionButton";
            this.submitTransactionButton.Size = new System.Drawing.Size(255, 57);
            this.submitTransactionButton.TabIndex = 3;
            this.submitTransactionButton.Text = "Submit";
            this.submitTransactionButton.UseVisualStyleBackColor = true;
            this.submitTransactionButton.Click += new System.EventHandler(this.submitTransactionButton_Click);
            // 
            // myDataGridView
            // 
            this.myDataGridView.AllowUserToAddRows = false;
            this.myDataGridView.AllowUserToDeleteRows = false;
            this.myDataGridView.AllowUserToResizeColumns = false;
            this.myDataGridView.AllowUserToResizeRows = false;
            this.myDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.myDataGridView.Location = new System.Drawing.Point(16, 150);
            this.myDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.myDataGridView.Name = "myDataGridView";
            this.myDataGridView.Size = new System.Drawing.Size(516, 433);
            this.myDataGridView.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(163, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 55);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tickets";
            // 
            // customer_picturebox
            // 
            this.customer_picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_picturebox.Location = new System.Drawing.Point(173, 125);
            this.customer_picturebox.Name = "customer_picturebox";
            this.customer_picturebox.Size = new System.Drawing.Size(359, 5);
            this.customer_picturebox.TabIndex = 9;
            this.customer_picturebox.TabStop = false;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 661);
            this.Controls.Add(this.customer_picturebox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.myDataGridView);
            this.Controls.Add(this.submitTransactionButton);
            this.Controls.Add(this.cancelTransactionButton);
            this.Controls.Add(this.onlyTextLabel1);
            this.Controls.Add(this.nameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(560, 700);
            this.MinimumSize = new System.Drawing.Size(560, 700);
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer_picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label onlyTextLabel1;
        private System.Windows.Forms.Button cancelTransactionButton;
        private System.Windows.Forms.Button submitTransactionButton;
        private System.Windows.Forms.DataGridView myDataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox customer_picturebox;
    }
}