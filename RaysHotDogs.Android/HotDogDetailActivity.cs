
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Service;
using UniversalImageLoader.Core;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Hot Dog Details")]
  public class HotDogDetailActivity : Activity
  {
    private ImageView hotDogImageView;
    private TextView hotDogNameTextView;
    private TextView shortDescriptionTextView;
    private TextView descriptionTextView;
    private TextView priceTextView;
    private EditText amountEditText;
    private Button cancelButton;
    private Button orderButton;

    private HotDogDataService dataService;
    private HotDog selectedHotDog;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your application here
      SetContentView(Resource.Layout.HotDogDetailView);

      dataService = new HotDogDataService();
      selectedHotDog = dataService.GetHotDogById(Intent.GetIntExtra("selectedHotDogId", 1));
      FindViews();
      BindData();
      HandleEvents();
    }

    private void FindViews()
    {
      hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogDetailImage);
      hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
      shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
      descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
      priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
      amountEditText = FindViewById<EditText>(Resource.Id.amoutEditText);
      cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
      orderButton = FindViewById<Button>(Resource.Id.orderButton);
    }

    private void BindData()
    {
      var imageHelper = ImageLoader.Instance;

      hotDogNameTextView.Text = selectedHotDog.Name;
      shortDescriptionTextView.Text = selectedHotDog.ShortDescription;
      descriptionTextView.Text = selectedHotDog.Description;
      priceTextView.Text = "Price: $" + selectedHotDog.Price;

      imageHelper.DisplayImage("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.ImagePath + ".jpg",
              hotDogImageView);
    }

    private void HandleEvents()
    {
      orderButton.Click += OrderButton_Click;
    }

    private void OrderButton_Click(object sender, EventArgs e)
    {
      var amount = int.Parse(amountEditText.Text);

      using (var dialog = new AlertDialog.Builder(this))
      {
        dialog.SetTitle("Confirmation");
        dialog.SetMessage("Your hot dog has been added to the cart!");
        dialog.Show();
      }
    }
  }
}