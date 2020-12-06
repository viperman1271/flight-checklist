using FlightChecklist.ObjectModel;
using Xamarin.Forms;

namespace FlightChecklist
{
    public class FlightChecklistDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CategoryTemplate { get; set; }
        public DataTemplate ItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is Category)
            {
                return CategoryTemplate;
            }
            if(item is Item)
            {
                return ItemTemplate;
            }

            return null;
        }
    }
}
