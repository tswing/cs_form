using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Common;

namespace WinFormsApp1
{
    public partial class BobaeDreamForm : Form
    {
        BobaeDream bobae;
        public BobaeDreamForm()
        {
            InitializeComponent();
            bobae = new BobaeDream();
            bobae.GetBestPosts();
        }

        private void btnBest_Click(object sender, EventArgs e)
        {
            // 베스트 게시글 가져오기
            bobae.GetBestPosts();

            //var bestPosts = bobae.GetBestPosts();
            //if (bestPosts != null && bestPosts.Count > 0)
            //{
            //    MessageBox.Show($"베스트 게시글 {bestPosts.Count}개를 가져왔습니다.");
            //}
            //else
            //{
            //    MessageBox.Show("베스트 게시글을 가져오는 데 실패했습니다.");
            //}
        }
    }
}
