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
using RaysHotDogs.Core.Models;
using UniversalImageLoader.Core;

namespace RaysHotDogs.Droid.Adapters
{
  public class HotDogListAdapter : BaseAdapter<HotDog>
  {
    List<HotDog> items;
    Activity context;

    public HotDogListAdapter(List<HotDog> hotDogList, Activity context) : base()
    {
      items = hotDogList;
      this.context = context;
    }

    public override HotDog this[int position] { get { return items[position]; } }

    public override int Count { get { return items.Count; } }

    public override long GetItemId(int position) => (long)items[position]?.Id;

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      var item = items[position];
      ImageLoader imageLoader = ImageLoader.Instance;

      if (convertView == null)
        convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);

      convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
      convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
      convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;

      imageLoader.DisplayImage("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg",
        convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView));

      return convertView;
    }
  }
}