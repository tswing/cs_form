using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using AngleSharp;
using AngleSharp.Dom;
using System.Net.Http;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace WinFormsApp1.Common
{
    public class BobaeDream
    {
        public class BestPost
        {
            public string No { get; set; }
            public string Title { get; set; }
            public string SubUrl { get; set; }
            public string Author { get; set; }
            public string commentCount { get; set; }
            public string recommendCount{ get; set; }
            public string viewCount { get; set; }
            
            public override string ToString()
            {
                return $"{Title} by {commentCount} on {recommendCount} - {viewCount}";
            }
        }


        public async void GetBestPosts()        
        {
            var url = "https://www.bobaedream.co.kr/list?code=best";
            using (WebClient client = new WebClient())
            {
                try
                {                    
                    client.Encoding = Encoding.UTF8; // 한글 인코딩 설정
                    string html = client.DownloadString(url);

                    var config = Configuration.Default;
                    var context = BrowsingContext.New(config);

                    // HTML 문자열을 직접 파싱
                    var document = await context.OpenAsync(req => req.Content(html));

                    
                    var bests = document.QuerySelectorAll("tbody tr");
                    foreach (var best in bests)
                    {
                        var a = best.QuerySelector(".bsubject");
                        var href = a.GetAttribute("href");
                        var title = a.TextContent;
                        var commentCount = best.QuerySelector("strong.totreply")?.TextContent;
                        var recommendCount = best.QuerySelector("td.recomm")?.TextContent;
                        var viewCount = best.QuerySelector("td.count")?.TextContent;
                        var onclick= best.QuerySelector("span.author")?.GetAttribute("onclick");
                        var pattern = @"submenu_show\('[^']+',\s*'([^']+)'\)";
                        string author = "";
                        string no = "";
                        Match match = Regex.Match(onclick, pattern);
                        if (match.Success)
                        {
                            author = match.Groups[1].Value;
                        }

                        Match matchNo = Regex.Match(href, @"No=(\d+)");
                        if (matchNo.Success)
                        {
                            no = matchNo.Groups[1].Value;                            
                        }

                        var post = new BestPost
                        {
                            No = no,
                            Title = title,
                            SubUrl = href,
                            Author = author,
                            commentCount = commentCount,
                            recommendCount = recommendCount,
                            viewCount = viewCount,
                        };

                        SaveDb(post);

                        Debug.WriteLine(post.ToString());
                        
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"오류 발생: {ex.Message}");
                }
            }
            // 여기에 베스트 게시글을 가져오는 로직을 구현합니다.
            // 예시로, 단순히 콘솔에 메시지를 출력합니다.
            Console.WriteLine("베스트 게시글을 가져오는 중...");
            // 실제 구현에서는 웹 요청 등을 통해 데이터를 가져올 수 있습니다.
        }

        public void SaveDb(BestPost post)
        {
            try
            {
                string connStr = @"Data Source=C:\wing\C#\WinFormsApp1\WinFormsApp1\bobaeBest.db";
                using (var conn = new SQLiteConnection(connStr))
                {
                    conn.Open();

                    string sql = $"INSERT INTO TB_BEST_ARTICLE (No, Title, URL, Author, RECOMM_CNT, VIEW_CNT) VALUES (@No, @Title, @SubUrl, @Author, @RecommCount, @ViewCount)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@No", post.No);
                    cmd.Parameters.AddWithValue("@Title", post.Title);
                    cmd.Parameters.AddWithValue("@SubUrl", post.SubUrl);
                    cmd.Parameters.AddWithValue("@RecommCount", post.recommendCount);
                    cmd.Parameters.AddWithValue("@ViewCount", post.viewCount);
                    cmd.Parameters.AddWithValue("@Author", post.Author);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"DB 저장 오류: {ex.Message}");
            }
        }

        public void GetBestPosts2()
        {
            var url = "https://www.bobaedream.co.kr/list?code=best";
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8; // 한글 인코딩 설정
                    string html = client.DownloadString(url);

                    Debug.WriteLine(html);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"오류 발생: {ex.Message}");
                }
            }
            
        }
    }
}
