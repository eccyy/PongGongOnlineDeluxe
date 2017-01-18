namespace PongGongOnlineDeluxe
{
    partial class Startmenu
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
            this.btnServerHost = new System.Windows.Forms.Button();
            this.tbxServerName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.tbxIpAdress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxStartTetris = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lbxRecievedMessages = new System.Windows.Forms.ListBox();
            this.tbxSendMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnServerHost
            // 
            this.btnServerHost.Location = new System.Drawing.Point(12, 129);
            this.btnServerHost.Name = "btnServerHost";
            this.btnServerHost.Size = new System.Drawing.Size(75, 23);
            this.btnServerHost.TabIndex = 0;
            this.btnServerHost.Text = "Host";
            this.btnServerHost.UseVisualStyleBackColor = true;
            this.btnServerHost.Click += new System.EventHandler(this.btnServerHost_Click);
            // 
            // tbxServerName
            // 
            this.tbxServerName.Location = new System.Drawing.Point(12, 103);
            this.tbxServerName.Name = "tbxServerName";
            this.tbxServerName.Size = new System.Drawing.Size(100, 20);
            this.tbxServerName.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(91, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "user not logged in";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(12, 87);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(67, 13);
            this.lblServerName.TabIndex = 5;
            this.lblServerName.Text = "Server name";
            // 
            // tbxIpAdress
            // 
            this.tbxIpAdress.Location = new System.Drawing.Point(118, 103);
            this.tbxIpAdress.Name = "tbxIpAdress";
            this.tbxIpAdress.Size = new System.Drawing.Size(100, 20);
            this.tbxIpAdress.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP adress";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Join";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxStartTetris
            // 
            this.tbxStartTetris.Location = new System.Drawing.Point(31, 167);
            this.tbxStartTetris.Name = "tbxStartTetris";
            this.tbxStartTetris.Size = new System.Drawing.Size(163, 34);
            this.tbxStartTetris.TabIndex = 10;
            this.tbxStartTetris.Text = "Start tetriss";
            this.tbxStartTetris.UseVisualStyleBackColor = true;
            this.tbxStartTetris.Click += new System.EventHandler(this.tbxStartTetris_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(389, 147);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 11;
            this.btnSendMessage.Text = "skicka";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lbxRecievedMessages
            // 
            this.lbxRecievedMessages.FormattingEnabled = true;
            this.lbxRecievedMessages.Location = new System.Drawing.Point(398, 251);
            this.lbxRecievedMessages.Name = "lbxRecievedMessages";
            this.lbxRecievedMessages.Size = new System.Drawing.Size(120, 95);
            this.lbxRecievedMessages.TabIndex = 12;
            // 
            // tbxSendMessage
            // 
            this.tbxSendMessage.Location = new System.Drawing.Point(470, 149);
            this.tbxSendMessage.Name = "tbxSendMessage";
            this.tbxSendMessage.Size = new System.Drawing.Size(100, 20);
            this.tbxSendMessage.TabIndex = 13;
            // 
            // Startmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 412);
            this.Controls.Add(this.tbxSendMessage);
            this.Controls.Add(this.lbxRecievedMessages);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbxStartTetris);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxIpAdress);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.tbxServerName);
            this.Controls.Add(this.btnServerHost);
            this.Name = "Startmenu";
            this.Text = "Startmenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServerHost;
        private System.Windows.Forms.TextBox tbxServerName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox tbxIpAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button tbxStartTetris;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.ListBox lbxRecievedMessages;
        private System.Windows.Forms.TextBox tbxSendMessage;
    }
}