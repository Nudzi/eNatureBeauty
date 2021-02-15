namespace eNatureBeauty.Mobile.Models
{
    public enum MenuItemType
    {
        Welcome,
        AboutUs,
        Products, 
        Profile,
        Cart,
        Orders
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}