namespace Digiteq
{
    partial class frmChat
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
            this.components = new System.ComponentModel.Container();
            this.xpnlUsers = new System.Windows.Forms.Panel();
            this.xpanel3 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.xpnlChatRooms = new System.Windows.Forms.Panel();
            this.xpnlMessages = new System.Windows.Forms.Panel();
            this.xpnlMessageHeader = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.xpanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpnlUsers
            // 
            this.xpnlUsers.AutoScroll = true;
            this.xpnlUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xpnlUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpnlUsers.Location = new System.Drawing.Point(8, 35);
            this.xpnlUsers.Name = "xpnlUsers";
            this.xpnlUsers.Size = new System.Drawing.Size(127, 416);
            this.xpnlUsers.TabIndex = 0;
            // 
            // xpanel3
            // 
            this.xpanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xpanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpanel3.Controls.Add(this.btnSend);
            this.xpanel3.Controls.Add(this.txtMessage);
            this.xpanel3.Location = new System.Drawing.Point(141, 413);
            this.xpanel3.Name = "xpanel3";
            this.xpanel3.Size = new System.Drawing.Size(307, 38);
            this.xpanel3.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(259, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(41, 25);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(8, 8);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(246, 22);
            this.txtMessage.TabIndex = 14;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // xpnlChatRooms
            // 
            this.xpnlChatRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xpnlChatRooms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpnlChatRooms.Location = new System.Drawing.Point(141, 35);
            this.xpnlChatRooms.Name = "xpnlChatRooms";
            this.xpnlChatRooms.Size = new System.Drawing.Size(307, 83);
            this.xpnlChatRooms.TabIndex = 16;
            // 
            // xpnlMessages
            // 
            this.xpnlMessages.AutoScroll = true;
            this.xpnlMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xpnlMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpnlMessages.Location = new System.Drawing.Point(141, 146);
            this.xpnlMessages.Name = "xpnlMessages";
            this.xpnlMessages.Size = new System.Drawing.Size(307, 262);
            this.xpnlMessages.TabIndex = 1;
            // 
            // xpnlMessageHeader
            // 
            this.xpnlMessageHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.xpnlMessageHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xpnlMessageHeader.Location = new System.Drawing.Point(141, 124);
            this.xpnlMessageHeader.Name = "xpnlMessageHeader";
            this.xpnlMessageHeader.Size = new System.Drawing.Size(307, 22);
            this.xpnlMessageHeader.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(456, 460);
            this.ControlBox = false;
            this.Controls.Add(this.xpnlMessageHeader);
            this.Controls.Add(this.xpnlChatRooms);
            this.Controls.Add(this.xpanel3);
            this.Controls.Add(this.xpnlUsers);
            this.Controls.Add(this.xpnlMessages);
            this.Name = "frmChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.frmChat_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChat_FormClosing);
            this.Load += new System.EventHandler(this.frm_Chat_Load);
            this.VisibleChanged += new System.EventHandler(this.frmChat_VisibleChanged);
            this.Controls.SetChildIndex(this.xpnlMessages, 0);
            this.Controls.SetChildIndex(this.xpnlUsers, 0);
            this.Controls.SetChildIndex(this.xpanel3, 0);
            this.Controls.SetChildIndex(this.xpnlChatRooms, 0);
            this.Controls.SetChildIndex(this.xpnlMessageHeader, 0);
            this.xpanel3.ResumeLayout(false);
            this.xpanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel xpnlUsers;
        private System.Windows.Forms.Panel xpanel3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel xpnlChatRooms;
        private System.Windows.Forms.Panel xpnlMessages;
        private System.Windows.Forms.Panel xpnlMessageHeader;
        private System.Windows.Forms.Timer timer1;
    }
}