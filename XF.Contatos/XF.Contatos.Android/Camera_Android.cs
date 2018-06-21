using Android.App;
using XF.Contatos.Droid;
using XF.Contatos.Camera;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Media;
using System;

[assembly: Dependency(typeof(Camera_Android))]
namespace XF.Contatos.Droid
{
    class Camera_Android : ICamera


    {
        public async void TakePicture()
        {
            var context = MainApplication.CurrentContext as Activity;
            var picker = new MediaPicker(context);
            if (!picker.IsCameraAvailable)
                Debug.WriteLine("No camera!");
            else
            {
                try
                {
                    MediaFile file = await picker.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Name = "test.jpg",
                        Directory = "MediaPickerSample"
                    });

                    Debug.WriteLine(file.Path);
                    MessagingCenter.Send<ICamera, string>(this, "camera", file.Path);
                }
                catch (OperationCanceledException)
                {
                    Debug.WriteLine("Canceled");
                }
            }
        }
    }

    
}