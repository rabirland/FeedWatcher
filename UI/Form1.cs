using BlazorSciFi;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using UI.Services;

namespace UI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Set up Blazor view
        var services = new ServiceCollection();

        services.AddTransient<HttpClient>();
        services.AddSingleton<IFeedService, AppSettingsFeedService>();
        services.AddSingleton<ISettingsService<AppSettings>, JsonSettingsService<AppSettings>>(provider =>
            new JsonSettingsService<AppSettings>("config.json", () => new()));
        services.ConfigureBlazorScifi();

        services.AddWindowsFormsBlazorWebView();
#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif

        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = services.BuildServiceProvider();
        blazorWebView1.RootComponents.Add<Pages.Index>("#app");
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
}
