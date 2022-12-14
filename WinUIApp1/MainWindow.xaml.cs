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
using WinUIApp1.Models;
using WinUIApp1.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void nvMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selected = args.SelectedItemContainer as NavigationViewItem;
            if (selected is not null && selected.Tag is not null)
            {
                Debug.WriteLine(selected.Tag as string);
                contentFrame
                    .Navigate(Type.GetType(selected.Tag.ToString()), selected.Content,
                    new DrillInNavigationTransitionInfo());
                //nvMenu.Header = selected.Content;
                nvMenu.SelectedItem = selected;
            }
        }

        private void nvMenu_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            try
            {
                sender.SelectionChanged += Sender_SelectionChanged;
                var stack = contentFrame.BackStack;
                if (stack.Any())
                    contentFrame.GoBack();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "window-back-button");
            }
        }

        private void Sender_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var current = args.SelectedItemContainer;
            current.IsSelected = true;
        }
    }
}
