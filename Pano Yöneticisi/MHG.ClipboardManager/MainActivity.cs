using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using R = MHG.ClipboardManager.Resource;

namespace MHG.ClipboardManager
{
    [Activity(Label = "MHG.ClipboardManager", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnKopyala;
        Button btnYapistir;
        EditText etKopyala;
        EditText etYapistir;
        Android.Content.ClipboardManager panoYoneticisi;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(R.Layout.Main);
            btnKopyala = FindViewById<Button>(R.Id.btnKopyala);
            btnYapistir = FindViewById<Button>(R.Id.btnYapistir);
            etKopyala = FindViewById<EditText>(R.Id.etKopyala);
            etYapistir = FindViewById<EditText>(R.Id.etYapistir);

            panoYoneticisi = (Android.Content.ClipboardManager)GetSystemService(ClipboardService);

            btnKopyala.Click += delegate
            {
                if (string.IsNullOrEmpty(etKopyala.Text))
                    Toast.MakeText(this, "Kopyalanacak metin giriniz!", ToastLength.Short).Show();
                else
                {
                    var clip = ClipData.NewPlainText("kopyala", etKopyala.Text);
                    panoYoneticisi.PrimaryClip = clip;
                    Toast.MakeText(this, "Metin kopyalandı!", ToastLength.Short).Show();
                }
            };

            btnYapistir.Click += delegate
            {
                if (!panoYoneticisi.HasPrimaryClip)
                    Toast.MakeText(this, "Yapıştırılacak metin bulunamadı!", ToastLength.Short).Show();
                else
                {
                    var clip = panoYoneticisi.PrimaryClip;
                    etYapistir.Text = clip.GetItemAt(0).Text;
                }
            };
        }
    }
}

