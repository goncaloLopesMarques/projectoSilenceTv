using SilenceTv1._0.Views;
using SilenceTv1._0.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.MediaManager;

namespace SilenceTv1._0.Views
{

    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {

            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Player", Icon = "play.png", TargetType = typeof(SilenceTv1._0.Views.PlayerView) };
            var page2 = new MasterPageItem() { Title = "Gravaçoes", Icon = "play.png", TargetType = typeof(SilenceTv1._0.Views.GravacoesPage) };
            var page3 = new MasterPageItem() { Title = "Televisões", Icon = "play.png", TargetType = typeof(SilenceTv1._0.Views.MainPage) };
          

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
           

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(SilenceTv1._0.Views.GravacoesPage)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
       
    }
}

