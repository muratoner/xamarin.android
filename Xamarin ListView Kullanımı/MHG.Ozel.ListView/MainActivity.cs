using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;

namespace MHG.Ozel.ListView
{
    [Activity(Label = "MHG.Ozel.ListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Android.Widget.ListView _listView;
        List<Kisi> _liste;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            _listView = FindViewById<Android.Widget.ListView>(Resource.Id.customListView);
            _liste = new List<Kisi>
            {
                new Kisi { Ad = "Murat", Soyad = "ÖNER", Yas = 25, Cinsiyet = "E"  },
                new Kisi { Ad = "Sakine", Soyad = "SALMANLI", Yas = 22, Cinsiyet = "K"  },
                new Kisi { Ad = "Hüseyin", Soyad = "TURAK", Yas = 24, Cinsiyet = "E"  },
                new Kisi { Ad = "Mustafa", Soyad = "ÖNER", Yas = 25, Cinsiyet = "E"  }
            };

            MyListViewAdapter adapter = new MyListViewAdapter(this, _liste);
            _listView.Adapter = adapter;

            _listView.ItemClick += _listView_ItemClick;
            _listView.ItemLongClick += _listView_ItemLongClick;
        }

    private void _listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
    {
        var kisi = _liste[e.Position];
        Toast.MakeText(this, string.Format("LongClick: {0} {1}", kisi.Yas, kisi.Cinsiyet), ToastLength.Short).Show();
    }

    private void _listView_ItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
    {
        var kisi = _liste[e.Position];
        Toast.MakeText(this, string.Format("Click: {0} {1}", kisi.Ad, kisi.Soyad), ToastLength.Short).Show();
    }
    }
}

