using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DataTemplateRepeaterControl.Models;
using Xamarin.Forms;

namespace DataTemplateRepeaterControl.ViewModels
{
    public class ListItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public ListItemsViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy) { return; }

            IsBusy = true;

            try
            {
                var items = await DataStore.GetItemsAsync(true);

                Items = new ObservableCollection<Item>(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}