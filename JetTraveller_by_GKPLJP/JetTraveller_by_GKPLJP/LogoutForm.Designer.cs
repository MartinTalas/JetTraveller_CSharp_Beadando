
namespace JetTraveller_by_GKPLJP
{
    partial class LogoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoutForm));
            this.exit_from_logout = new System.Windows.Forms.Button();
            this.new_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit_from_logout
            // 
            this.exit_from_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_from_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit_from_logout.Location = new System.Drawing.Point(27, 34);
            this.exit_from_logout.Name = "exit_from_logout";
            this.exit_from_logout.Size = new System.Drawing.Size(100, 57);
            this.exit_from_logout.TabIndex = 0;
            this.exit_from_logout.Text = "Exit";
            this.exit_from_logout.UseVisualStyleBackColor = true;
            this.exit_from_logout.Click += new System.EventHandler(this.exit_from_logout_Click);
            // 
            // new_login
            // 
            this.new_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.new_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.new_login.Location = new System.Drawing.Point(145, 34);
            this.new_login.Name = "new_login";
            this.new_login.Size = new System.Drawing.Size(100, 57);
            this.new_login.TabIndex = 1;
            this.new_login.Text = "Log In";
            this.new_login.UseVisualStyleBackColor = true;
            this.new_login.Click += new System.EventHandler(this.new_login_Click);
            // 
            // LogoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(274, 123);
            this.Controls.Add(this.new_login);
            this.Controls.Add(this.exit_from_logout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(290, 162);
            this.MinimumSize = new System.Drawing.Size(290, 162);
            this.Name = "LogoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Out";
            this.Load += new System.EventHandler(this.LogoutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exit_from_logout;
        private System.Windows.Forms.Button new_login;
    }
}