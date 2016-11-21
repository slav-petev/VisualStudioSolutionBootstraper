using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SolutionBootstrapper.CustomControls
{
    public class ItemMarginStackPanel : StackPanel
    {
        public static readonly DependencyProperty ItemMarginProperty =
            DependencyProperty
            .Register("ItemMargin", typeof(Thickness), 
                typeof(ItemMarginStackPanel), 
                new FrameworkPropertyMetadata(
                    new Thickness(),
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Thickness ItemMargin
        {
            get { return (Thickness)GetValue(ItemMarginProperty); }
            set { SetValue(ItemMarginProperty, value); }
        }

        protected override Size MeasureOverride(Size finalSize)
        {
            RefreshItemMargin();

            return base.MeasureOverride(finalSize);
        }

        private void RefreshItemMargin()
        {
            var children = InternalChildren;
            foreach (var child in InternalChildren)
            {
                if (!(child is FrameworkElement)) continue;

                var element = (FrameworkElement)child;
                element.Margin = ItemMargin;
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            RefreshItemMargin();

            return base.ArrangeOverride(finalSize);
        }
    }
}
