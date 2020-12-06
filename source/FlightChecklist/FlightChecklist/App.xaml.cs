using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlightChecklist
{
    public partial class App : Application
    {
        public static Action<string, string, string> Log { get; private set; }

        public App(MainModel model, Action<string, string, string> log)
        {
            InitializeComponent();

            MainPage = new MainPage(model);
            Log = log;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log("", "MyApp", e.ExceptionObject.ToString());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
