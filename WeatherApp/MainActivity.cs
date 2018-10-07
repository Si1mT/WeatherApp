﻿using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
//using WeatherApp.Core;
using Android;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageButton button;
        TextView textview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.activity_main);


            //button = FindViewById<ImageButton>(Resource.Id.imageButton1);
            //button.SetImageDrawable("@Resource/drawable/searchicon");
            //button.SetBackgroundDrawable = ImageLayout.Stretch;
            //textview = FindViewById<TextView>(Resource.Id.textView1);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            //var weather = await Core.Core.GetWeather("asd");
            //textview.Text = weather.Temperature;
        }
    }
}