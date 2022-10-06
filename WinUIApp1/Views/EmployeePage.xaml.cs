using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic;
using System;
using System.Collections;
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
using WinUIApp1.Views.DetailsPages;
using WinUIApp1.Views.OperationPage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeePage : Page
    {
        Compositor _compositor = App.CurrentWindow.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;

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
                new Employee("MULUMBA","KALALA","LAW",false,RandomDay(),rnd.NextInt64(1000, 9999))
                {
                    UniversityStudies = "Software Engennering",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills=" C#, C++,C, .Net, WPF,AValonia,MAUI,Xamarin,Kotlin(Jetpack Compos),Javascript(*)",
                },
                new Employee("KISIMBA","MBO'O","MANAGEMENT",false,RandomDay(),rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "HR",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills = "*"
                },
                new Employee("LUBALA","MUSONDA","LAW",false,RandomDay(),rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "Software Engennering",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills="Archtict"
                },
                new Employee("LUBI","MBUI","IT",false,RandomDay(),rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "Software Engennering",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills="Javascrip,php"
                },
                new Employee("KALESA","MULANGA","LAW",false,RandomDay(),rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "Software Engennering",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills="*"
                },
                new Employee("MULUMBA","KALALA","HR",false,RandomDay(), rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "Software Engennering",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills="Java, Kotlin, Andoird*"
                },
                new Employee("KAPEND","KASONG","MANAGEMENT",false,RandomDay(), rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "Engennering",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills="Building"
                },
                new Employee("KLORES","FLOYER","GENERAL",true,RandomDay(),rnd.NextInt64(1000, 9999))
                 {
                    UniversityStudies = "Management",
                    UniversityStudiesStart = RandomDay(),
                    HighSchool = "Mathemathic and physics",
                    HighSchoolStartDate = RandomDay(),
                    Social  = RandomSocial(),
                    Skills="*"
                },
            };
        }

        private DateTime RandomDay()
        {
            var gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            DateTime end = new DateTime(2021, 1, 1);
            int range = (DateTime.Today - start).Days;
            int rangeEnd = (DateTime.Today - end).Days;
            return start.AddDays(gen.Next(rangeEnd, range));
        }

        private string RandomSocial()
        {
            string[] statusSocial = new[] { "Single", "Married", "Devorced", "Widow", "Widower" };
            var rnd = new Random();
            var index = rnd.Next(0, 4);
            return statusSocial[index];
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            depsDetails.Navigate(typeof(AddEmployeePage), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromBottom });
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
            try
            {

                ConnectedAnimation animation = empList.PrepareConnectedAnimation("forwardAnimation", employees, "connectedElement");

                SmokeGrid.Visibility = Visibility.Visible;

                animation.TryStart(destinationElement);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Opening-details");
            }
            finally
            {
                //SmokeGrid.Visibility = Visibility.Visible;
                depsDetails.Navigate(typeof(EmployeeDetailsPage), selected, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
                Debug.WriteLine(selected.ID);
            }
        }

        private async void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            //ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("backwardsAnimation", destinationElement);
            SmokeGrid.Children.Remove(destinationElement);

            // Collapse the smoke when the animation completes.
            //animation.Completed += Animation_Completed;

            // If the connected item appears outside the viewport, scroll it into view.
            empList.ScrollIntoView(employees, ScrollIntoViewAlignment.Default);
            empList.UpdateLayout();

            // Use the Direct configuration to go back (if the API is available). 
            //if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            //{
            //    animation.Configuration = new DirectConnectedAnimationConfiguration();
            //}

            //// Play the second connected animation. 
            //await empList.TryStartConnectedAnimationAsync(animation, employees, "connectedElement");
            SmokeGrid.Visibility = Visibility.Collapsed;
            SmokeGrid.Children.Add(destinationElement);
        }

        private void Animation_Completed(ConnectedAnimation sender, object args)
        {
            SmokeGrid.Visibility = Visibility.Collapsed;
            SmokeGrid.Children.Add(destinationElement);
        }

        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new System.Numerics.Vector3(finalValue);
        }

        private void delIcon_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(1.5f);
            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void delIcon_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            CreateOrUpdateSpringAnimation(1.0f);
            (sender as UIElement).StartAnimation(_springAnimation);
        }
    }
}
