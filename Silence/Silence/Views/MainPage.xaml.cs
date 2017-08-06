using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Silence.MenuItems;
using Silence.ViewModel;
using Silence.Views;

namespace Silence
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }
        private HomeListViewModel aux;
        private HomePage aux2;

        public MainPage()
        {
            InitializeComponent();
            MenuList = new List<MasterPageItem>();
            aux = new HomeListViewModel();
            aux2 = new HomePage();
           
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Player", Icon = "play.png", TargetType = typeof(Silence.Views.PlayerView) };
            var page2 = new MasterPageItem() { Title = "Gravaçoes", Icon = "folder.png", TargetType = typeof(Silence.Views.Gravacoes) };
            var page3 = new MasterPageItem() { Title = "Emissões", Icon = "home.png", TargetType = typeof(Silence.Views.HomePage) };


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

            if (page == typeof(PlayerView)) {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page, aux2.firstElement));
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }
           
            IsPresented = false;
        }
    }
}
