using Android.Content;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace MHG.Ozel.ListView
{
    public class MyListViewAdapter : BaseAdapter<Kisi>
    {
        List<Kisi> _liste;
        Context _context;

        public MyListViewAdapter(Context context, List<Kisi> liste)
        {
            _liste = liste;
            _context = context;
        }

        public override Kisi this[int position]
        {
            get { return _liste[position]; }
        }

        public override int Count
        {
            get { return _liste.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View satir = convertView;
            if (satir == null)
                satir = LayoutInflater.From(_context).Inflate(Resource.Layout.listview_satir, null, false);

            TextView txtAd = satir.FindViewById<TextView>(Resource.Id.txtAd);
            txtAd.Text = _liste[position].Ad;

            TextView txtSoyad = satir.FindViewById<TextView>(Resource.Id.txtSoyad);
            txtSoyad.Text = _liste[position].Soyad;

            TextView txtYas = satir.FindViewById<TextView>(Resource.Id.txtYas);
            txtYas.Text = _liste[position].Yas.ToString();

            TextView txtCinsiyet = satir.FindViewById<TextView>(Resource.Id.txtCinsiyet);
            txtCinsiyet.Text = _liste[position].Cinsiyet;

            return satir;
        }
    }
}