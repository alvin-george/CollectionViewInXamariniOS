using System;
using UIKit;
using System.Runtime.CompilerServices;
using ObjCRuntime;
using System.Collections.Generic;
using Foundation;
using System.Drawing;
using System.Diagnostics.Contracts;
using CoreGraphics;

namespace SampleUICollectionView
{
    public partial class ViewController : UIViewController, IUICollectionViewDataSource, IUICollectionViewDelegate
    {

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            sampleCollectionView.Delegate = this;
            sampleCollectionView.DataSource = this;

            var cellIdentifier = new NSString("sampleCellIdentifier");
            this.sampleCollectionView.RegisterClassForCell(typeof(MyCollectionViewCell), cellIdentifier);

        }

        [Export("numberOfSectionsInCollectionView:")]
        public nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        UICollectionViewCell IUICollectionViewDataSource.GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Contract.Ensures(Contract.Result<UICollectionViewCell>() != null);
            var cell = collectionView.DequeueReusableCell("sampleCellIdentifier", indexPath) as MyCollectionViewCell;

            UILabel label = new UILabel(frame: new CGRect(0, 100, 100, 100))
            {
                Font = UIFont.FromName("Arial", 25f),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Red,
                Text = "Text Sample"
            };

            cell.ContentView.AddSubview(label);


            return cell;
        }

        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 22;
        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}
