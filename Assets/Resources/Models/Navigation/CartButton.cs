using Assets.Resources.Services.EventAggregator;

namespace Assets.Resources.Models.Navigation
{
    public class CartButton : INavigationButton
    {
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public int Order { get; set; }

        public CartButton()
        {
            Name = "CartButton";
            ButtonText = "C";
            Order = 3;
        }

        public void OnClick()
        {
            EventAggregator.SendMessage(new ShowModalMessage { Modal = "Panels/CartModal" });
        }
    }
}