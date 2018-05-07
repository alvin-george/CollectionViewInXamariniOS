using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace SampleUICollectionView
{
 public partial class MyCollectionViewCell: UICollectionViewCell
    {
        UIImageView imageView;

        [Export("initWithFrame:")]
        public MyCollectionViewCell(CGRect frame) : base(frame)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

            ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            ContentView.Layer.BorderWidth = 2.0f;
            ContentView.BackgroundColor = UIColor.White;
            ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            imageView = new UIImageView(UIImage.FromBundle("icon.png"));
            imageView.Center = ContentView.Center;
            imageView.Transform = CGAffineTransform.MakeScale(0.2f, 0.2f);

            ContentView.AddSubview(imageView);
        }

        public UIImage Image
        {
            set
            {
                imageView.Image = value;
            }
        }
    }





}
