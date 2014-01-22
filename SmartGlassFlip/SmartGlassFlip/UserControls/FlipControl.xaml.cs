using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace SmartGlassFlip.UserControls
{
    public partial class FlipControl
    {
        private int _currentAngle;

        public static readonly DependencyProperty FrontContentProperty = DependencyProperty.Register(
            "FrontContent", typeof (UIElement), typeof (FlipControl), new PropertyMetadata(default(UIElement)));

        public UIElement FrontContent
        {
            get { return (UIElement) GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        public static readonly DependencyProperty BackContentProperty = DependencyProperty.Register(
            "BackContent", typeof (UIElement), typeof (FlipControl), new PropertyMetadata(default(UIElement)));

        public UIElement BackContent
        {
            get { return (UIElement) GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        public FlipControl()
        {
            DataContext = this;
            InitializeComponent();

            _currentAngle = 0;
            NameScope.SetNameScope(this, new NameScope());
            RegisterName("AxisRotationFwd", RotateTransform3DFwd.Rotation);
            RegisterName("AxisRotationBwd", RotateTransform3DBwd.Rotation);
        }

        public void FlipRight()
        {
            FlipImage(true);
        }

        public void FlipLeft()
        {
            FlipImage(false);
        }

        private void FlipImage(bool flipRight)
        {
            const double duration = 0.5;

            var targetAngle = flipRight ? _currentAngle + 180 : _currentAngle - 180;

            var storyBoardForward = new Storyboard();
            var storyBoardbackward = new Storyboard();

            var rotateAnimationFwd = new DoubleAnimation
            {
                From = _currentAngle,
                To = targetAngle,
                Duration = new Duration(TimeSpan.FromSeconds(duration))
            };

            storyBoardForward.Children.Add(rotateAnimationFwd);
            Storyboard.SetTargetName(rotateAnimationFwd, "AxisRotationFwd");
            Storyboard.SetTargetProperty(rotateAnimationFwd, new PropertyPath("Angle"));

            var rotateAnimationBwd = new DoubleAnimation
            {
                From = _currentAngle,
                To = targetAngle,
                Duration = new Duration(TimeSpan.FromSeconds(duration))
            };

            storyBoardbackward.Children.Add(rotateAnimationBwd);
            Storyboard.SetTargetName(rotateAnimationBwd, "AxisRotationBwd");
            Storyboard.SetTargetProperty(rotateAnimationBwd, new PropertyPath("Angle"));

            storyBoardbackward.Begin(this);
            storyBoardForward.Begin(this);

            _currentAngle = targetAngle;
        }
    }
}
