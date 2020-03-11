using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin_titleview.CustomView), typeof(Xamarin_titleview.UWP.CustomRenderer))]
namespace Xamarin_titleview.UWP
{
    public class CustomRenderer : ViewRenderer<Xamarin_titleview.CustomView,TextBox>
    {
        IRandomAccessStream stream = null;
        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                var textblock = new TextBox();
                textblock.Text = "Title View";
                SetNativeControl(textblock);
                CallStream();
            }
        }
        private async void CallStream()
        {
            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.txt",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
            stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                stream.Dispose();
            }
            base.Dispose(disposing);
            
        }
    }
}
