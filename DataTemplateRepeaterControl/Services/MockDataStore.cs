using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataTemplateRepeaterControl.Models;

namespace DataTemplateRepeaterControl.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> _items;

        public MockDataStore()
        {
            _items = new List<Item>();
            var mockItems = new List<Item>
            {
                new ItemA { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item A.", },
                new ItemB { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item B." },
                new ItemC { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item C." },
                new ItemB { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is also an item B." },
                new ItemC { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is also an item C." },
                new ItemA { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is also an item A." },
                new ItemA { Id = Guid.NewGuid().ToString(), Text = "Seventh item", Description="This too, is also an item A." },
                new ItemB { Id = Guid.NewGuid().ToString(), Text = "Eighth item", Description="This too, is also an item B." },
                new ItemC { Id = Guid.NewGuid().ToString(), Text = "Ninth item", Description="This too, is also an item C." },
            };

            foreach (var item in mockItems)
            {
                _items.Add(item);
            }
        }
        
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}