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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using WinUIApp1.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeePage : Page
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public EmployeePage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            InitializeDataa();
        }

        void InitializeDataa()
        {
            var rnd = new Random();
            employees = new ObservableCollection<Employee>
            {
                new Employee("MULUMBA","KALALA","LAW",false,DateTime.Now,rnd.NextInt64(1000, 9999)),
                new Employee("KISIMBA","MBO'O","MANAGEMENT",false,DateTime.Now,rnd.NextInt64(1000, 9999)),
                new Employee("LUBALA","MUSONDA","LAW",false,DateTime.Now,rnd.NextInt64(1000, 9999)),
                new Employee("LUBI","MBUI","IT",false,DateTime.Now,rnd.NextInt64(1000, 9999)),
                new Employee("KALESA","MULANGA","LAW",false,DateTime.Now,rnd.NextInt64(1000, 9999)),
                new Employee("MULUMBA","KALALA","HR",false,DateTime.Now, rnd.NextInt64(1000, 9999)),
                new Employee("KAPEND","KASONG","MANAGEMENT",false,DateTime.Now, rnd.NextInt64(1000, 9999)),
                new Employee("KLORES","FLOYER","GENERAL",true,DateTime.Now,rnd.NextInt64(1000, 9999)),
            };
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void empList_Loaded(object sender, RoutedEventArgs e)
        {
            if (employees != null)
            {
                InitializeDataa();
                empList.ItemsSource = employees;
                empList.ScrollIntoView(employees, ScrollIntoViewAlignment.Leading);

                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
                if (animation != null)
                {
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                    {
                        animation.Configuration = new DirectConnectedAnimationConfiguration();
                    }

                    await empList.TryStartConnectedAnimationAsync(animation, employees, "connectedElement");
                }
            }
        }

        private void empList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = e.ClickedItem as Employee;

            var msgDialog = new MessageDialog($"{selected.ID} has been selected");
            Debug.WriteLine(selected.ID);
        }

    }
}
