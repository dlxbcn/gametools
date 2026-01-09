using System.Diagnostics;
using System.Reflection;

namespace WinFormsApp1;

public partial class About : Form
{
    public About()
    {
        InitializeComponent();
        Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
        labelVer.Text = $"v{assemblyVersion.ToString()}";
    }
}