using Android.OS;
using Android.Views;
using RaysHotDogs.Droid.Adapters;

namespace RaysHotDogs.Droid.Fragments
{
  public class FavoriteHotDogListFragment : BaseHotDogListFragment
  {
    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your fragment here
    }

    public override void OnActivityCreated(Bundle savedInstanceState)
    {
      base.OnActivityCreated(savedInstanceState);
      FindViews();
      HandleEvents();

      hotDogs = dataService.GetFavoriteHotDogs();
      listView.Adapter = new HotDogListAdapter(hotDogs, Activity);
    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      // Use this to return your custom view for this Fragment
      // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
      return inflater.Inflate(Resource.Layout.HotDogListView, container, false);
    }
  }
}