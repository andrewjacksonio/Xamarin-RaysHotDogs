
using Android.App;
using Android.OS;
using RaysHotDogs.Droid.Fragments;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Ray's Hot Dogs - Hot Dog List")]
  public class HotDogMenuActivity : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your application here
      SetContentView(Resource.Layout.HotDogMenuView);
      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
      
      AddTab(" Favorites", Resource.Drawable.FavoritesIcon, new FavoriteHotDogListFragment());
      AddTab(" Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversHotDogListFragment());
      AddTab(" Veggie Lovers", Resource.Drawable.VeggieLoversIcon, new VeggieLoversHotDogListFragment());
    }

    private void AddTab(string tabText, int iconResourceId, Fragment view)
    {
      var tab = ActionBar.NewTab();
      tab.SetText(tabText);
      tab.SetIcon(iconResourceId);

      tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
      {
        var fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
        if (fragment != null)
          e.FragmentTransaction.Remove(fragment);
        e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
      };

      tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
        {
          e.FragmentTransaction.Remove(view);
        };

      ActionBar.AddTab(tab);
    }
  }
}