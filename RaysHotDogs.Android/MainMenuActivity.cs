using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Ray's Hot Dogs", MainLauncher = true)]
  public class MainMenuActivity : Activity
  {
    Button orderButton;
    Button cartButton;
    Button pictureButton;
    Button mapButton;
    Button aboutButton;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your application here
      SetContentView(Resource.Layout.MainMenuView);

      FindViews();
      HandleEvents();
    }

    private void FindViews()
    {
      orderButton = FindViewById<Button>(Resource.Id.orderButton);
      cartButton = FindViewById<Button>(Resource.Id.cartButton);
      pictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
      mapButton = FindViewById<Button>(Resource.Id.mapButton);
      aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
    }

    private void HandleEvents()
    {
      orderButton.Click += OrderButton_Click;
      aboutButton.Click += AboutButton_Click;
    }

    private void AboutButton_Click(object sender, EventArgs e)
    {
      var aboutIntent = new Intent(this, typeof(AboutActivity));
      StartActivity(aboutIntent);
    }

    private void OrderButton_Click(object sender, EventArgs e)
    {
      var orderIntent = new Intent(this, typeof(HotDogMenuActivity));
      StartActivity(orderIntent);
    }
  }
}