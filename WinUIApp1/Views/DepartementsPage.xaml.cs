using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using WinUIApp1.Models;
using WinUIApp1.Views.DetailsPages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DepartementsPage : Page
    {
        private ObservableCollection<Departement> departements;
        private Departement selectedDepartement;

        public DepartementsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            InitializeDepartement();
        }

        void InitializeDepartement()
        {
            var rnd = new Random();
            departements = new ObservableCollection<Departement>
            {
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
                new Departement($"dep-{rnd.NextInt64(100,999)}","Lorem ipsum for the current description...",rnd.Next(1,20),DateTime.Now),
            };
        }

        private async void depsList_Loaded(object sender, RoutedEventArgs e)
        {
            if (departements is not null)
            {
                this.depsList.ItemsSource = departements;
                depsList.ScrollIntoView(departements, ScrollIntoViewAlignment.Leading);

                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
                if (animation != null)
                {
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                    {
                        animation.Configuration = new DirectConnectedAnimationConfiguration();
                    }

                    await depsList.TryStartConnectedAnimationAsync(animation, departements, "connectedElement");
                }
            }
        }

        private void depsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = e.ClickedItem as Departement;
            if (selected != null)
            {
                var pages = typeof(DepartementDetailsPage).FullName;
                depsDetails.Navigate(Type.GetType(pages),selected,
                    new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
                depsList.SelectedItem = selected;
            }
        }
    }
}
