using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace VeryCustomUI
{
	public partial class App : Xamarin.Forms.Application
	{
        public IContainer Container
        {
            get;
            set;
        }

        public App()
		{
			InitializeComponent();

            NavigationPage navigationPage = new NavigationPage(new MainPage());

            var builder = new ContainerBuilder();
            builder.RegisterInstance(navigationPage.Navigation).As<INavigation>();
            ((App)App.Current).Container = builder.Build();

            this.MainPage = navigationPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
