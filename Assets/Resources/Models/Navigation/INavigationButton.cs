namespace Assets.Resources.Models.Navigation
{
    public interface INavigationButton
    {
        string Name { get; set; }
        string ButtonText { get; set; }
        int Order { get; set; }

        void OnClick();
    }
}