namespace WinFormsApp1
{


    public partial class MainForm : Form
    {
        private AppSettings appSettings;

        public MainForm()
        {
            InitializeComponent();
            appSettings = AppSettings.Instance;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 콤보 박스 항목 추가
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(appSettings.Config.Fruits.ToArray());

            if (appSettings.Config.SelectedFruitsIndex >= 0 && appSettings.Config.SelectedFruitsIndex < comboBox1.Items.Count)
                comboBox1.SelectedIndex = appSettings.Config.SelectedFruitsIndex;
            else
                comboBox1.SelectedIndex = 0; // 기본값

            comboBox1.Validating += ComboBox1_Validating;

            BobaeMenuItem_Click(null, null);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            appSettings.Config.SelectedFruitsIndex = comboBox1.SelectedIndex;
            appSettings.SaveSettings();
            base.OnFormClosing(e);
        }

        private void ComboBox1_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            configValidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.ActiveControl == comboBox1 && keyData == Keys.Enter)
            {
                configValidate();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void configValidate()
        {
            string input = comboBox1.Text.Trim();
            var fruits = appSettings.Config.Fruits;

            if (!string.IsNullOrEmpty(input) && !fruits.Contains(input))
            {
                fruits.Add(input);
                comboBox1.Items.Add(input);
                appSettings.SaveSettings();
            }
        }

        private void BobaeMenuItem_Click(object sender, EventArgs e)
        {
            BobaeDreamForm form = new BobaeDreamForm();
            form.ShowDialog(this);
        }
    }
}
