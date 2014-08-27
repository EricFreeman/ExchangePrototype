using Assets.Resources.Services.EventAggregator;

namespace Assets.Resources.Models.Navigation
{
    public class HomeButton : INavigationButton
    {
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public int Order { get; set; }

        public HomeButton()
        {
            Name = "HomeButton";
            ButtonText = "H";
            Order = 1;
        }

        public void OnClick()
        {
            EventAggregator.SendMessage(new OpenScreenMessage { Screen = "HomePanel" });
        }
    }
}
