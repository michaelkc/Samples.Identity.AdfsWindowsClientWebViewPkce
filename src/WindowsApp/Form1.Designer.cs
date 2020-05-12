namespace App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxAuthenticate = new System.Windows.Forms.Button();
            this.uxLog = new System.Windows.Forms.ListBox();
            this.uxTabs = new System.Windows.Forms.TabControl();
            this.uxTokenTab = new System.Windows.Forms.TabPage();
            this.uxBrowserTab = new System.Windows.Forms.TabPage();
            this.uxWebBrowser = new System.Windows.Forms.WebBrowser();
            this.uxToken = new System.Windows.Forms.TextBox();
            this.uxTabs.SuspendLayout();
            this.uxTokenTab.SuspendLayout();
            this.uxBrowserTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxAuthenticate
            // 
            this.uxAuthenticate.Location = new System.Drawing.Point(10, 12);
            this.uxAuthenticate.Name = "uxAuthenticate";
            this.uxAuthenticate.Size = new System.Drawing.Size(75, 23);
            this.uxAuthenticate.TabIndex = 1;
            this.uxAuthenticate.Text = "Authenticate";
            this.uxAuthenticate.UseVisualStyleBackColor = true;
            this.uxAuthenticate.Click += new System.EventHandler(this.uxAuthenticate_Click);
            // 
            // uxLog
            // 
            this.uxLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLog.FormattingEnabled = true;
            this.uxLog.ItemHeight = 14;
            this.uxLog.Location = new System.Drawing.Point(10, 455);
            this.uxLog.Name = "uxLog";
            this.uxLog.Size = new System.Drawing.Size(1357, 172);
            this.uxLog.TabIndex = 3;
            // 
            // uxTabs
            // 
            this.uxTabs.Controls.Add(this.uxTokenTab);
            this.uxTabs.Controls.Add(this.uxBrowserTab);
            this.uxTabs.Location = new System.Drawing.Point(10, 48);
            this.uxTabs.Name = "uxTabs";
            this.uxTabs.SelectedIndex = 0;
            this.uxTabs.Size = new System.Drawing.Size(1361, 401);
            this.uxTabs.TabIndex = 4;
            // 
            // uxTokenTab
            // 
            this.uxTokenTab.AutoScroll = true;
            this.uxTokenTab.Controls.Add(this.uxToken);
            this.uxTokenTab.Location = new System.Drawing.Point(4, 22);
            this.uxTokenTab.Name = "uxTokenTab";
            this.uxTokenTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxTokenTab.Size = new System.Drawing.Size(1353, 375);
            this.uxTokenTab.TabIndex = 1;
            this.uxTokenTab.Text = "Token";
            this.uxTokenTab.UseVisualStyleBackColor = true;
            // 
            // uxBrowserTab
            // 
            this.uxBrowserTab.Controls.Add(this.uxWebBrowser);
            this.uxBrowserTab.Location = new System.Drawing.Point(4, 22);
            this.uxBrowserTab.Name = "uxBrowserTab";
            this.uxBrowserTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxBrowserTab.Size = new System.Drawing.Size(1353, 375);
            this.uxBrowserTab.TabIndex = 0;
            this.uxBrowserTab.Text = "Browser";
            this.uxBrowserTab.UseVisualStyleBackColor = true;
            // 
            // uxWebBrowser
            // 
            this.uxWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.uxWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uxWebBrowser.Name = "uxWebBrowser";
            this.uxWebBrowser.Size = new System.Drawing.Size(1347, 369);
            this.uxWebBrowser.TabIndex = 1;
            this.uxWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.uxWebBrowser_Navigated);
            // 
            // uxToken
            // 
            this.uxToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxToken.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxToken.Location = new System.Drawing.Point(3, 3);
            this.uxToken.Multiline = true;
            this.uxToken.Name = "uxToken";
            this.uxToken.ReadOnly = true;
            this.uxToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxToken.Size = new System.Drawing.Size(1347, 369);
            this.uxToken.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 640);
            this.Controls.Add(this.uxTabs);
            this.Controls.Add(this.uxLog);
            this.Controls.Add(this.uxAuthenticate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uxTabs.ResumeLayout(false);
            this.uxTokenTab.ResumeLayout(false);
            this.uxTokenTab.PerformLayout();
            this.uxBrowserTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uxAuthenticate;
        private System.Windows.Forms.ListBox uxLog;
        private System.Windows.Forms.TabControl uxTabs;
        private System.Windows.Forms.TabPage uxBrowserTab;
        private System.Windows.Forms.WebBrowser uxWebBrowser;
        private System.Windows.Forms.TabPage uxTokenTab;
        private System.Windows.Forms.TextBox uxToken;
    }
}

