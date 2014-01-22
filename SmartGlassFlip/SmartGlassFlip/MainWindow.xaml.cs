using System;
using System.Diagnostics;
using System.Windows;
using Awesomium.Core;

namespace SmartGlassFlip
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindowLoaded;
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            //uxWebControl.Source = new Uri("http://www.google.com");
        }

        private void FlipRightClick(object sender, RoutedEventArgs e)
        {
            uxFlipControlImage.FlipRight();
        }

        private void FlipLeftClick(object sender, RoutedEventArgs e)
        {
            uxFlipControlImage.FlipLeft();
        }

        private void UxWebControl_OnLoadingFrameComplete(object sender, FrameEventArgs e)
        {
            Debug.WriteLine("x");
        }
    }
}
