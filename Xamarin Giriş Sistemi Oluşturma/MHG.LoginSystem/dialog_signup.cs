using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MHG.LoginSystem
{
    class dialog_signup : DialogFragment
    {
        EditText txtAd;
        EditText txtSoyad;
        EditText txtTelefon;
        EditText txtEposta;
        Button btnKaydet;
        public event EventHandler<OnUyeOlEventArgs> UyeOlTamamlandi;

        public class OnUyeOlEventArgs : EventArgs
        {
            public string Ad { get; set; }

            public string Soyad { get; set; }

            public string Eposta{ get; set; }

            public string Telefon { get; set; }

            public OnUyeOlEventArgs(string ad, string soyad, string eposta, string telefon)
            {
                Ad = ad;
                Soyad = soyad;
                Telefon = telefon;
                Eposta = eposta;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            //Dialog olarak gösterilmesini istediðimiz dialog_uye_ol adlý layout dosyasýný parametre olarak veriyoruz.
            var view = inflater.Inflate(Resource.Layout.dialog_uye_ol, container, false);

            btnKaydet = view.FindViewById<Button>(Resource.Id.btnKaydet);
            txtAd = view.FindViewById<EditText>(Resource.Id.txtAd);
            txtSoyad = view.FindViewById<EditText>(Resource.Id.txtSoyad);
            txtEposta = view.FindViewById<EditText>(Resource.Id.txtEposta);
            txtTelefon = view.FindViewById<EditText>(Resource.Id.txtTelefon);

            btnKaydet.Click += BtnKaydet_Click;

            return view;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            UyeOlTamamlandi.Invoke(this, new OnUyeOlEventArgs(txtAd.Text, txtSoyad.Text, txtEposta.Text, txtTelefon.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //Baþlýk çubuðunu gizliyoruz.
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            //Oluþturmuþ olduðumuz animasyonlarýn tanýmlarýnýn yer aldýðý xml style dosyasýný atýyoruz.
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}