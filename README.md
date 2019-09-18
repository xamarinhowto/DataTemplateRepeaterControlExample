# Introduction 

This solution contains a working example for a Repeater control that utilises a DataTemplateSelector for both iOS and Android.

# Usage of Repeater control

## XAML
```XML
<?xml version="1.0" encoding="utf-8"?>
<ContentPage
    Title="Repeater"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:templateselectors="clr-namespace:DataTemplateRepeaterControl.TemplateSelectors"
    xmlns:controls="clr-namespace:DarkIce.Toolkit.Core.Controls"
    x:Class="DataTemplateRepeaterControl.Views.RepeaterItemsPage"
    x:Name="RepeaterItemsPageRef">
    <ScrollView>
        <StackLayout
            Orientation="Vertical">
            <controls:Repeater
                x:Name="RepeaterItems"
                ItemsSource="{Binding Items}"
                VerticalOptions="FillAndExpand">
                <controls:Repeater.ItemTemplate>
                    <templateselectors:SimpleTemplateSelector />
                </controls:Repeater.ItemTemplate>
            </controls:Repeater>
        </StackLayout>
    </ScrollView>
</ContentPage>
```
## C#
```csharp
public class RepeaterItemsPage : ContentPage
{
    RepeaterItemsViewModel viewModel;

    public RepeaterItemsPage()
    {
        InitializeComponent();

        BindingContext = viewModel = new RepeaterItemsViewModel();

        if (viewModel?.Items == null || !viewModel.Items.Any())
        {
            viewModel.LoadItemsCommand.Execute(null);
        }

        var repeater = new Repeater
        {
            ItemTemplate = new SimpleTemplateSelector(),
            ItemsSource = viewModel.Items,
            VerticalOptions = LayoutOptions.FillAndExpand,
        };

        Content = new ScrollView
        {
            Content = repeater,
        };
    }
}
```