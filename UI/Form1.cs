using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms.Design;

namespace UI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Set up Blazor view
        var services = new ServiceCollection();

        services.AddTransient<HttpClient>();

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
