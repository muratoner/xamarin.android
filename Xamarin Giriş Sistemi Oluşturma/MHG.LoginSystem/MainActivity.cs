using Android.App;
using Android.OS;
using Android.Widget;
using Java.Lang;

namespace MHG.LoginSystem
{
    [Activity(Label = "MHG.LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnUyeOl;
        ProgressBar progressBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            btnUyeOl = FindViewById<Button>(Resource.Id.btnUyeOl);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            btnUyeOl.Click += (object sender, System.EventArgs e) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                var dialog = new dialog_signup();
                dialog.Show(transaction, "dialog fragment");

                dialog.UyeOlTamamlandi += Dialog_UyeOlTamamlandi;
            };
        }

        private void Dialog_UyeOlTamamlandi(object sender, dialog_signup.OnUyeOlEventArgs e)
        {
            progressBar.Visibility = Android.Views.ViewStates.Visible;
            Thread thread = new Thread(Run);
            thread.Start();
        }

        public void Run()
        {
            Thread.Sleep(5000);
            RunOnUiThread(() => { progressBar.Visibility = Android.Views.ViewStates.Invisible; });
        }
    }
}

