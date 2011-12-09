namespace GitHubNotifier
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIconGit = new System.Windows.Forms.NotifyIcon(this.components);
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnHeaderMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconGit
            // 
            this.notifyIconGit.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconGit.Icon")));
            this.notifyIconGit.Text = "GitHub Notifier";
            this.notifyIconGit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconGit_MouseDoubleClick);
            // 
            // listViewMessages
            // 
            this.listViewMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMessages.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listViewMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMessage});
            this.listViewMessages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewMessages.Location = new System.Drawing.Point(0, 24);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(441, 151);
            this.listViewMessages.SmallImageList = this.imageListSmall;
            this.listViewMessages.TabIndex = 0;
            this.listViewMessages.TileSize = new System.Drawing.Size(220, 30);
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderMessage
            // 
            this.columnHeaderMessage.Text = "Message";
            this.columnHeaderMessage.Width = 439;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "warn.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(439, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(439, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 170);
            this.Controls.Add(this.listViewMessages);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GitHub Notifier";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconGit;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnHeaderMessage;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

