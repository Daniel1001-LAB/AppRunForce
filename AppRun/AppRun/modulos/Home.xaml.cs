﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppRun.clases;
using AppRun.ViewModel;
using System.Text.Json.Serialization;
using AppRun.modulos;

namespace AppRun
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
      

        public Home()
        {
            InitializeComponent();
            BindingContext = new MainPageModel();

        }
        public async void OnEnterAddressTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPlacePage() { BindingContext = this.BindingContext }, false);

        }

        public void Handle_Stop_Clicked(object sender, EventArgs e)
        {
            searchLayout.IsVisible = true;
           // distanceAndTime.IsVisible = false;
            stopRouteButton.IsVisible = false;
            map.Polylines.Clear();

            map.Pins.Clear();

        }

        //Center map in actual location 
        protected override void OnAppearing()
        {
            base.OnAppearing();
            map.GetActualLocationCommand.Execute(null);


        }

        void OnCalculate(System.Object sender, System.EventArgs e)
        {

            searchLayout.IsVisible = false;
            //distanceAndTime.IsVisible = true;
            stopRouteButton.IsVisible = true;
            //distancia.Text = Preferences.Get("distancia", "Hola");
        }

        async void OnLocationError(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Error", "No se puede obtener la ubicación real", "Ok");
        }



    }
}
