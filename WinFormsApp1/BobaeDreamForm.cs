using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<BestPost> dataSource;
        WebForm webForm = null;
        public BobaeDreamForm()
        {
            InitializeComponent();
            bobae = new BobaeDream();

            dataGridView1.VirtualMode = true;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataSource = bobae.RetrieveBestPosts();
            setDataGridPosts(dataSource);
            dataGridView1.CellValueNeeded += dataGridView1_CellValueNeeded;

            //dataGridView1.DataSource = dataSource;
        }

        private void btnBest_ClickAsync(object sender, EventArgs e)
        {
            getBestPosts();
        }

        private async void getBestPosts()
        {
            // 베스트 게시글 가져오기
            await bobae.GetBestPosts();

            dataSource = bobae.RetrieveBestPosts();
            setDataGridPosts(dataSource);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 특정 셀 위치 확인 (예: 2번째 컬럼)
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "Name")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var name = dataGridView1.Columns[e.ColumnIndex].Name;
                Debug.WriteLine(row.ToString());
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                Debug.WriteLine($"{name}: {value}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine($"CellContent: {dataGridView1.Columns[e.ColumnIndex].Name}");

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Action")
            {
                var post = dataSource[e.RowIndex];
                var url = "https://www.bobaedream.co.kr" + post.SubUrl;

                //Process.Start(new ProcessStartInfo
                //{
                //    FileName = url,
                //    UseShellExecute = true
                //});

                openWebForm(url);

                
            }
        }

        private void openWebForm(string url)
        {
            if (webForm == null || webForm.IsDisposed)
            {
                webForm = new WebForm();                
            }

            webForm.Show();
            webForm.OpenUrl(url);

            webForm.BringToFront();
            webForm.Activate();
        }

        private void setDataGridPosts(List<BestPost> posts)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("No", "번호");
            dataGridView1.Columns.Add("Title", "제목");
            dataGridView1.Columns.Add("SubUrl", "URL");
            dataGridView1.Columns.Add("Author", "작성자");
            dataGridView1.Columns.Add("commentCount", "댓글수");
            dataGridView1.Columns.Add("recommendCount", "추천수");
            dataGridView1.Columns.Add("viewCount", "조회수");


            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.HeaderText = "선택";
            chkCol.Name = "Checkbox";
            dataGridView1.Columns.Insert(0, chkCol);  // 맨 앞에 추가

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "작업";
            btnCol.Text = "실행";
            btnCol.Name = "Action";
            btnCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(0, btnCol);

            lblTotalCount.Text = $"총 {posts.Count}개";

            dataGridView1.RowCount = posts.Count;
        }

        private void dataGridView1_CellValueNeeded(object? sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex < 8)
            {
                e.Value = dataSource[e.RowIndex].GetType().GetProperty(dataGridView1.Columns[e.ColumnIndex].Name)?.GetValue(dataSource[e.RowIndex], null);
            }

        }

    }
}
