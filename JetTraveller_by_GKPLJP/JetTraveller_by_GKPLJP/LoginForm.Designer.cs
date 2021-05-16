
namespace JetTraveller_by_GKPLJP
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Username_txtbox = new System.Windows.Forms.TextBox();
            this.Password_txtbox = new System.Windows.Forms.TextBox();
            this.Login_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_btn = new System.Windows.Forms.Button();
            this.password_picturebox = new System.Windows.Forms.PictureBox();
            this.username_picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.password_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.username_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // Username_txtbox
            // 
            this.Username_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Username_txtbox.Location = new System.Drawing.Point(25, 115);
            this.Username_txtbox.Name = "Username_txtbox";
            this.Username_txtbox.Size = new System.Drawing.Size(349, 35);
            this.Username_txtbox.TabIndex = 2;
            this.Username_txtbox.TextChanged += new System.EventHandler(this.Username_txtbox_TextChanged);
            // 
            // Password_txtbox
            // 
            this.Password_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Password_txtbox.Location = new System.Drawing.Point(25, 205);
            this.Password_txtbox.Name = "Password_txtbox";
            this.Password_txtbox.PasswordChar = '*';
            this.Password_txtbox.Size = new System.Drawing.Size(349, 35);
            this.Password_txtbox.TabIndex = 3;
            this.Password_txtbox.TextChanged += new System.EventHandler(this.Password_txtbox_TextChanged);
            // 
            // Login_btn
            // 
            this.Login_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Login_btn.Location = new System.Drawing.Point(25, 323);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(349, 82);
            this.Login_btn.TabIndex = 4;
            this.Login_btn.Text = "Log In";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(20, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(20, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(115, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 55);
            this.label3.TabIndex = 7;
            this.label3.Text = "Log In";
            // 
            // exit_btn
            // 
            this.exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_btn.Location = new System.Drawing.Point(25, 447);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(56, 23);
            this.exit_btn.TabIndex = 8;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // password_picturebox
            // 
            this.password_picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_picturebox.Location = new System.Drawing.Point(25, 239);
            this.password_picturebox.Name = "password_picturebox";
            this.password_picturebox.Size = new System.Drawing.Size(349, 5);
            this.password_picturebox.TabIndex = 9;
            this.password_picturebox.TabStop = false;
            // 
            // username_picturebox
            // 
            this.username_picturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_picturebox.Location = new System.Drawing.Point(25, 149);
            this.username_picturebox.Name = "username_picturebox";
            this.username_picturebox.Size = new System.Drawing.Size(349, 5);
            this.username_picturebox.TabIndex = 10;
            this.username_picturebox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 493);
            this.Controls.Add(this.username_picturebox);
            this.Controls.Add(this.password_picturebox);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.Password_txtbox);
            this.Controls.Add(this.Username_txtbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(416, 532);
            this.MinimumSize = new System.Drawing.Size(416, 531);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.password_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.username_picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username_txtbox;
        private System.Windows.Forms.TextBox Password_txtbox;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.PictureBox password_picturebox;
        private System.Windows.Forms.PictureBox username_picturebox;
    }
}