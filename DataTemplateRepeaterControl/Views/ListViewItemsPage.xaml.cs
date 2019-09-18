using System.ComponentModel;
using System.Linq;
using DataTemplateRepeaterControl.ViewModels;
using Xamarin.Forms;

namespace DataTemplateRepeaterControl.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ListViewItemsPage : ContentPage
    {
        ListItemsViewModel viewModel;

        public ListViewItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel?.Items == null || !viewModel.Items.Any())
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}