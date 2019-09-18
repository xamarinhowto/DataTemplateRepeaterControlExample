using System;
using DataTemplateRepeaterControl.Models;
using DataTemplateRepeaterControl.Views.Cells;
using Xamarin.Forms;

namespace DataTemplateRepeaterControl.TemplateSelectors
{
    public class SimpleTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _itemATemplate;
        private DataTemplate _itemBTemplate;
        private DataTemplate _itemCTemplate;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case ItemA cellModel:
                    return _itemATemplate ?? (_itemATemplate = new DataTemplate(typeof(ItemACell)));

                case ItemB cellModel:
                    return _itemBTemplate ?? (_itemBTemplate = new DataTemplate(typeof(ItemBCell)));

                case ItemC cellModel:
                    return _itemCTemplate ?? (_itemCTemplate = new DataTemplate(typeof(ItemCCell)));

                default:
                    return null;
            }
        }
    }
}
