using Assets.Resources.Services.EventAggregator;

namespace Assets.Resources.Models.Navigation
{
    public class ShopAndCompareButton : INavigationButton
    {
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public int Order { get; set; }

        public ShopAndCompareButton()
        {
            Name = "ShopAndCompareButton";
            ButtonText = "S&C";
            Order = 2;
        }

        public void OnClick()
        {
            EventAggregator.SendMessage(new OpenScreenMessage { Screen = "ShopAndComparePanel" });
        }
    }
}
