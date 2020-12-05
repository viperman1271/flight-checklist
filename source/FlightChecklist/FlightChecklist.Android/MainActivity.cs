using Android.App;
using Android.Content.PM;
using Android.OS;
using FlightChecklist.ObjectModel;
using System.IO;
using System.Collections.Generic;

namespace FlightChecklist.Droid
{
    [Activity(Label = "FlightChecklist", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly List<Checklist> _CheckLists;

        public IEnumerable<Checklist> Checklists { get { return _CheckLists; } }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            ReadResources();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        private void ReadResources()
        {
            try
            {
                foreach(string file in Directory.EnumerateFiles("Checklists"))
                {

                }
                using (Stream input = Assets.Open("Checklists/Cessna172.json"))
                {

                }
            }
            catch
            {

            }
        }
    }
}