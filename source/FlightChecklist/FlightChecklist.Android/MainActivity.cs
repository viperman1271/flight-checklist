using Android.App;
using Android.Content.PM;
using Android.OS;
using FlightChecklist.ObjectModel;
using System.IO;

namespace FlightChecklist.Droid
{
    [Activity(Label = "FlightChecklist", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly MainModel _Model = new MainModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            ReadResources();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(_Model));
        }

        private void ReadResources()
        {
            try
            {
                //TODO: Replace with an iteration of assets
                string json;
                using (Stream input = Assets.Open("Checklists/Cessna172.json"))
                {
                    using (StreamReader reader = new StreamReader(input))
                    {
                        json = reader.ReadToEnd();
                    }
                }

                _Model.Checklists.Add(Checklist.LoadJson(json));
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}