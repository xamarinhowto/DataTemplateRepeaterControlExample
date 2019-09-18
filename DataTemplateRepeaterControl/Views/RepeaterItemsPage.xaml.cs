using System.ComponentModel;
using System.Linq;
using DarkIce.Toolkit.Core.Controls;
using DataTemplateRepeaterControl.TemplateSelectors;
using DataTemplateRepeaterControl.ViewModels;
using Xamarin.Forms;

namespace DataTemplateRepeaterControl.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RepeaterItemsPage : ContentPage
    {
        RepeaterItemsViewModel viewModel;

        public RepeaterItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RepeaterItemsViewModel();

            // C#
            //if (viewModel?.Items == null || !viewModel.Items.Any())
            //{
            //    viewModel.LoadItemsCommand.Execute(null);
            //}

            //var repeater = new Repeater
            //{
            //    ItemTemplate = new SimpleTemplateSelector(),
            //    ItemsSource = viewModel.Items,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //};

            //Content = new ScrollView
            //{
            //    Content = repeater,
            //};
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