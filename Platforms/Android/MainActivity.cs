using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using GuieMe.Domain.Helpers;
using System.Text.RegularExpressions;

namespace GuieMe;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Intent.ActionView }, Categories = new[]
{
    Intent.ActionView,
    Intent.CategoryDefault,
    Intent.CategoryBrowsable
},
    DataScheme = "https", DataHost = "guiemeunip.com", DataPathPrefix = "/local"
)]
public partial class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var uri = Intent?.Data;

        if (uri != null)
        {
            string localIdPath = uri.ToString()[(uri.ToString().LastIndexOf('=') + 1)..];
            string localId = NumberRegex().Replace(localIdPath, "");
             
            if(uri.ToString().Contains("guiemeunip") && uri.ToString().Contains("local"))
                Constants.LocalAtualId = int.Parse(localId);
        }
    }

    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);
        var action = intent.Action;
        var strLink = intent.DataString;
        if(Intent.ActionView == action && !string.IsNullOrWhiteSpace(strLink))
        {
            Toast.MakeText(this, strLink, ToastLength.Short).Show();
            string localIdPath = strLink[(strLink.LastIndexOf('=') + 1)..];
            string localId = NumberRegex().Replace(localIdPath, "");

            if (strLink.Contains("guiemeunip") && strLink.Contains("local"))
                Constants.LocalAtualId = int.Parse(localId);
        }
    }

    [GeneratedRegex("[^0-9]")]
    private static partial Regex NumberRegex();
}
