namespace Server
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConnect = new System.Windows.Forms.TextBox();
            this.btPlay = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(113, 12);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(178, 23);
            this.tbIPAddress.TabIndex = 1;
            this.tbIPAddress.Text = "127.0.0.6";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(113, 41);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(178, 23);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "8086";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port Number:";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(297, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 50);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Connection Control:";
            // 
            // tbConnect
            // 
            this.tbConnect.Location = new System.Drawing.Point(16, 104);
            this.tbConnect.Multiline = true;
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.Size = new System.Drawing.Size(356, 245);
            this.tbConnect.TabIndex = 6;
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(12, 355);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(360, 44);
            this.btPlay.TabIndex = 7;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(12, 426);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(279, 23);
            this.tbSend.TabIndex = 8;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(297, 426);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 9;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.tbConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConnect;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btSend;
    }
}