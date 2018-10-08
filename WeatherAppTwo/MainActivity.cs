﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherAppTwo.Core;
using System;

namespace WeatherAppTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button button;
        TextView textview;
        TextView textViewDate;
        //DateTime Date;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            textViewDate = FindViewById<TextView>(Resource.Id.textView_date);
            button = FindViewById<Button>(Resource.Id.button1);
            textview = FindViewById<TextView>(Resource.Id.textView1);

            button.Click += Button_Click;

            DateTime.UtcNow.ToString();
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            var weather = await Core.Core.GetWeather("asd");
            textview.Text = weather.Temperature;
            textViewDate.Text = DateTime.Now.ToString();
        }
    }
}