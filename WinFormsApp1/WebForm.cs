using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Web.WebView2.WinForms;

namespace WinFormsApp1
{
    public partial class WebForm : Form
    {
        private WebView2 webView;
        public WebForm()
        {
            InitializeComponent();

            webView = new WebView2();
            webView.Dock = DockStyle.Fill;            
            this.Controls.Add(webView);

            int screenHeight = Screen.PrimaryScreen!.WorkingArea.Height;
            int targetHeight = (int)(screenHeight * 0.8);            
            this.Height = targetHeight;

            //ready();
        }

        private async void ready()
        {
            await webView.EnsureCoreWebView2Async();
        }

        public async void OpenUrl(string url)
        {
            //webView.Source = new Uri(url);
            
            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.Navigate(url);
        }
    }
}
