using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace FilePickerDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button buttonP;
        private TextView textViewP;
        private ImageView imageViewP;
        private PickOptions options;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            buttonP = FindViewById<Button>(Resource.Id.btnP);
            textViewP = FindViewById<TextView>(Resource.Id.txV);
            imageViewP = FindViewById<ImageView>(Resource.Id.imgV);

            buttonP.Click += ButtonP_Click;
        }

        private async void ButtonP_Click(object sender, EventArgs e)
        {
            var res = await FilePicker.PickAsync(options);
            if (res != null)
            {
                textViewP.Text = $"File Name: {res.FileName}";
                if (res.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || (res.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)))
                {

                    var stream = await res.OpenReadAsync();
                    imageViewP.SetImageBitmap(BitmapFactory.DecodeStream(stream));
                }

            }
        }
    }
}