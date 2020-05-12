using System;
using System.Drawing;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        private readonly Authenticator _authenticator = new Authenticator(new ApplicationConfiguration());
        private readonly TokenVisualizer _tokenVisualizer = new TokenVisualizer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uxTabs.SelectTab(uxTokenTab);
            uxLog.DrawMode = DrawMode.OwnerDrawVariable;
            uxLog.MeasureItem += uxUrlLog_MeasureItem;
            uxLog.DrawItem += uxUrlLog_DrawItem;
        }

        private void uxAuthenticate_Click(object sender, EventArgs e)
        {
            uxTabs.SelectTab(uxBrowserTab);
            var authorizeUrl = _authenticator.CreateAuthorizeUrl();
            uxWebBrowser.Focus();
            uxWebBrowser.Navigate(authorizeUrl);
        }

        private async void uxWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (_authenticator.IsRedirectUrl(e.Url))
            {
                uxTabs.SelectTab(uxTokenTab);
                var tokenResponse = await _authenticator.PostAuthorizationCode(e.Url);
                var tokenVisualization = _tokenVisualizer.Visualize(tokenResponse);
                uxToken.Text = tokenVisualization;
            }
            Log($"Navigated: {e.Url}");
        }

        private void Log(string message)
        {
            uxLog.Items.Add($"{DateTime.Now:s} {message}");
            uxLog.TopIndex = uxLog.Items.Count - 1;
        }
     
        private void uxUrlLog_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(uxLog.Items[e.Index].ToString(), uxLog.Font, uxLog.Width).Height;
        }

        private void uxUrlLog_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(uxLog.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
    }
}
