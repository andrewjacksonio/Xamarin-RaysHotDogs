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
using Java.IO;
using Android.Provider;
using RaysHotDogs.Utility;
using Android.Graphics;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Take a Picture with Ray")]
  public class TakePictureActivity : Activity
  {
    private ImageView image;
    private Button pictureButton;
    private File imageDirectory;
    private File imageFile;
    private Bitmap imageResult;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your application here
      SetContentView(Resource.Layout.TakePictureView);

      FindViews();
      HandleEvents();

      imageDirectory = new File(Android.OS.Environment.
        GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),
        "RaysHotDogs");

      if (!imageDirectory.Exists()) imageDirectory.Mkdirs();
    }

    private void HandleEvents()
    {
      pictureButton.Click += PictureButton_Click;
    }

    private void PictureButton_Click(object sender, EventArgs e)
    {
      Intent intent = new Intent(MediaStore.ActionImageCapture);
      imageFile = new File(imageDirectory, $"PhotoWithRay_{Guid.NewGuid()}");
      intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

      StartActivityForResult(intent, 0);
    }

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
    {
      var width = image.Width;
      var height = image.Height;
      imageResult = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

      if (imageResult != null)
      {
        image.SetImageBitmap(imageResult);
        imageResult = null;
      }

      GC.Collect();
    }

    private void FindViews()
    {
      image = FindViewById<ImageView>(Resource.Id.pictureWithRay);
      pictureButton = FindViewById<Button>(Resource.Id.takePicture);
    }
  }
}