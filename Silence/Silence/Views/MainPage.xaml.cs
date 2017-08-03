using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Silence.MenuItems;

namespace Silence
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            MenuList = new List<MasterPageItem>();
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            
            var page1 = new MasterPageItem() { Title = "Emissões", Icon = "home.png", TargetType = typeof(Silence.Views.HomePage) };
            var page2 = new MasterPageItem() { Title = "Gravações", Icon = "folder.png", TargetType = typeof(Silence.Views.Gravacoes) };
            var page3 = new MasterPageItem() { Title = "Player", Icon = "play.png", TargetType = typeof(Silence.Views.PlayerView) };


            // Adding menu items to menuList
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;


            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Silence.Views.HomePage)));
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
