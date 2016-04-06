using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace MHG.Listview
{
    [Activity(Label = "MHG.Listview", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<string> list;
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            listView = FindViewById<ListView>(Resource.Id.listView);
            list = new List<string>
            {
                "Murat", "Sakine", "Hüseyin", "Mustafa"
            };

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list);
            listView.Adapter = adapter;
        }
    }
}