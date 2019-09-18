using System;
using System.Collections;
using Xamarin.Forms;

namespace DarkIce.Toolkit.Core.Controls
{
    public class Repeater : StackLayout
    {
        public Repeater()
        {
            Orientation = StackOrientation.Vertical;
            Padding = 0;
            Spacing = 0;
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(Repeater),
            default(DataTemplate), BindingMode.OneWay);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set
            {
                SetValue(ItemTemplateProperty, value);
                OnPropertyChanged(nameof(ItemTemplate));
            }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(ICollection), typeof(Repeater),
            null, BindingMode.OneWay, propertyChanged: ItemsSourcePropertyChanged);

        public ICollection ItemsSource
        {
            get { return (ICollection)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                OnPropertyChanged(nameof(ItemsSource));
            }
        }

        private static void ItemsSourcePropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is Repeater repeater && newValue is ICollection itemsSource)
            {
                repeater.ItemsLoaded = false;
                repeater.Children.Clear();

                // Somehow under strange conditions, items changed during enumeration which caused an InvalidOperationException to be thrown.
                // Whilst that's extremely odd and shouldn't happen, it's just safer to loop through the old fashioned way where it
                // doesn't matter if something changes and won't crash the app.
                var itemsArray = new object[itemsSource.Count];
                itemsSource.CopyTo(itemsArray, 0);
                for (var i = 0; i < itemsSource.Count; i++)
                {
                    var item = itemsArray[i];
                    repeater.Children.Add(repeater.GetRowView(item));
                }

                // Let any listeners know loading has finished so any UI updates like spinners etc can be changed
                repeater.ItemsLoaded = true;
                repeater.ItemsFinishedLoading?.Invoke(repeater, new EventArgs());
            }
        }

        public static readonly BindableProperty ItemsLoadedProperty = BindableProperty.Create(nameof(ItemsLoaded), typeof(bool), typeof(Repeater),
                                                                                          default(bool), BindingMode.OneWayToSource);
        public bool ItemsLoaded
        {
            get { return (bool)GetValue(ItemsLoadedProperty); }
            protected set
            {
                SetValue(ItemsLoadedProperty, value);
                OnPropertyChanged(nameof(ItemsLoaded));
            }
        }

        public event EventHandler ItemsFinishedLoading;

        protected virtual View GetRowView(object item)
        {
            // If we haven't got a template we're not getting a view so just bail out now
            if (ItemTemplate == null) { return null; }

            object viewContent;

            // Determine if this is a straight up template or using a DataTemplateSelector
            if (ItemTemplate is DataTemplateSelector dts)
            {
                var template = dts.SelectTemplate(item, this);
                viewContent = template.CreateContent();
            }
            else
            {
                viewContent = ItemTemplate.CreateContent();
            }

            // Get view and bind the data
            var rowView = viewContent is View ? viewContent as View : ((ViewCell)viewContent).View;
            rowView.BindingContext = item;

            return rowView;
        }
    }
}