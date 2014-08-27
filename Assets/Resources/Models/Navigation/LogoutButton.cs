using Assets.Resources.Services.EventAggregator;

namespace Assets.Resources.Models.Navigation
{
    public class LogoutButton : INavigationButton
    {
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public int Order { get; set; }

        public LogoutButton()
        {
            Name = "LogoutButton";
            ButtonText = "L";
            Order = 4;
        }

        public void OnClick()
        {
            EventAggregator.SendMessage(new LogoutMessage());
            EventAggregator.SendMessage(new OpenModalMessage { Modal = "LoginPanel" });
        }
    }
}