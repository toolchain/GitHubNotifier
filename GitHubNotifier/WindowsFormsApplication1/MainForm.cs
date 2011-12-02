﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GitHubNotifier
{
    public partial class MainForm : Form
    {
        const string MessageStaticText = "New commit by {0}:";
        const int TextIndentCount = 5;

        private class HeaderListViewItem : ListViewItem
        {
            public HeaderListViewItem(string authorName)
            {
                Text = string.Format(MessageStaticText, authorName);
                Font = new Font(Font, FontStyle.Bold);
                ForeColor = Color.Maroon;
            }
        }

        private class TextListViewItem : ListViewItem
        {
            public TextListViewItem(string text, bool indent, Color color)
            {
                if (indent)
                    Text = string.Empty.PadLeft(TextIndentCount) + text;
                else
                    Text = text;

                ForeColor = color;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.SetFormPosition();
            this.WindowState = FormWindowState.Normal;
            CheckForUpdates();
        }

        /// <summary>
        /// Restore form from system tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconGit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;
            this.notifyIconGit.Visible = false;
        }

        /// <summary>
        /// Hide form to system tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.notifyIconGit.Visible = true;
            this.ShowInTaskbar = false;
          
        }

        /// <summary>
        /// Set form position to the right bottom corner of the screen
        /// </summary>
        private void SetFormPosition()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }

        /// <summary>
        /// Prevent user from moving form
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;
            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }

            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Handles situation when new commit added and should be shown in notifier
        /// </summary>
        private void NewMessageAppeared(string time, string authorName, string message)
        {
            TextListViewItem timeListViewItem = new TextListViewItem(time, false, Color.Purple);
            HeaderListViewItem headerListViewItem = new HeaderListViewItem(authorName);
            TextListViewItem textListViewItem = new TextListViewItem(message, true, Color.Black);
            TextListViewItem emptyListViewItem = new TextListViewItem(string.Empty, false, Color.Black);

            AddNewMessage(0, emptyListViewItem);
            AddNewMessage(0, textListViewItem);

            AddNewMessage(0, headerListViewItem);
            AddNewMessage(0, timeListViewItem);

            this.Show();

            this.WindowState = FormWindowState.Normal;
            this.notifyIconGit.Visible = false;
        }

        /// <summary>
        /// Add new message to list
        /// </summary>
        /// <param name="message"></param>
        private void AddNewMessage(int index, ListViewItem message)
        {
            listViewMessages.Items.Insert(index, message);
        }

        private void CheckForUpdates()
        {
            string xmlURL = "https://github.com/toolchain/GitHubNotifier/commits/master.atom";

            RSSManager rssManager = new RSSManager(xmlURL);
            Collection<RSS.Items> rssItems = rssManager.GetFeed();

            listViewMessages.Columns[0].Text = rssManager.FeedTitle;

            for (int i = rssItems.Count - 1; i >= 0; i--)
            {
                RSS.Items rssItem = rssItems[i];
                NewMessageAppeared(rssItem.Date.ToString(), rssItem.AuthorName, rssItem.Message);
            }
        }

    }
}
