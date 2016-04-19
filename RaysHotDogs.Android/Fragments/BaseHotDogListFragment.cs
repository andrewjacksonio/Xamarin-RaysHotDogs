using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Core.Models;

namespace RaysHotDogs.Droid.Fragments
{
  public class BaseHotDogListFragment : Fragment
  {
    protected ListView listView;
    protected HotDogDataService dataService;
    protected List<HotDog> hotDogs;

    public BaseHotDogListFragment()
    {
      dataService = new HotDogDataService();
    }

    protected void HandleEvents()
    {
      listView.ItemClick += ListView_ItemClick;
    }

    private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      var selectedHotDog = hotDogs[e.Position];

      var intent = new Intent();
      intent.SetClass(Activity, typeof(HotDogDetailActivity));
      intent.PutExtra("selectedHotDogId", selectedHotDog.Id);

      StartActivityForResult(intent, 100);
    }

    protected void FindViews()
    {
      listView = View.FindViewById<ListView>(Resource.Id.hotDogListView);
      listView.FastScrollEnabled = true;
    }
  }
}