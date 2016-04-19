using Android.App;
using Android.Runtime;
using System;
using UniversalImageLoader.Core;

[Application]
public class UILApplication : Application
{
  protected UILApplication(IntPtr javaReference, JniHandleOwnership transfer)
      : base(javaReference, transfer)
  {
  }
  public override void OnCreate()
  {
    base.OnCreate();
    // Use default options
    var config = ImageLoaderConfiguration.CreateDefault(ApplicationContext);
    // Initialize ImageLoader with configuration.
    ImageLoader.Instance.Init(config);
  }
}
