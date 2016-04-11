using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Droid.Adapters;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Hot Dog List")]
  public class HotDogMenuActivity : Activity
  {
    private ListView hotDogListView;
    private List<HotDog> allHotDogs;
    private HotDogDataService dataService;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your application here
      SetContentView(Resource.Layout.HotDogMenuView);

      dataService = new HotDogDataService();
      hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);
      allHotDogs = dataService.GetAllHotDogs();

      hotDogListView.Adapter = new HotDogListAdapter(allHotDogs, this);
      hotDogListView.FastScrollAlwaysVisible = true;
      hotDogListView.FastScrollEnabled = true;
    }
  }
}