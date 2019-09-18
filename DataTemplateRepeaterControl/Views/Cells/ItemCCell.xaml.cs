using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataTemplateRepeaterControl.Views.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCCell : ViewCell
    {
        public ItemCCell()
        {
            InitializeComponent();
        }

        public void Handle_Tapped(object sender, EventArgs e)
        {
            uint animationMs = 125;
            var isShowing = !RowImage.IsVisible;

            // Do a quick little animation to transition things
            if (isShowing)
            {
                // If it was originally hidden then now we're showing it
                RowImage.IsVisible = RowDescription.IsVisible = true;
                ArrowImage.RotateTo(90, animationMs);
            }
            else
            {
                // If it was originally showing then now we're hiding it
                ArrowImage.RotateTo(-90, animationMs);
                RowImage.IsVisible = RowDescription.IsVisible = false;
            }
        }
    }
}
