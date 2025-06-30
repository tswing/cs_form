using System.Text.Json;


namespace WinFormsApp1;

class AppSettings
{
    private static readonly string SettingsFile = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
    private static AppSettings _instance;

    public Config Config;
    protected AppSettings()
    {      
        
    }

    public static AppSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AppSettings();
                _instance.LoadSettings();
            }
            return _instance;
        }
    }

    public void LoadSettings()
    {
        if (File.Exists(SettingsFile))
        {
            string json = File.ReadAllText(SettingsFile);
            Config = JsonSerializer.Deserialize<Config>(json) ?? new Config();
        }
    }

    public void SaveSettings()
    {
        string json = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(SettingsFile, json);
    }

}


