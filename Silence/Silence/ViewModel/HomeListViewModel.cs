using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Silence.Views;


namespace Silence.ViewModel
{
    public class HomeListViewModel : INotifyPropertyChanged
    {
        private Type page;
        
   
        public HomeListViewModel()
        {
             page = typeof(PlayerView);
             refreshCommand = new Command(RefreshListView);
          
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }


        private HomeListViewModel selectedItem { get; set; }
        public HomeListViewModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;

                // When your item is selected, you can open a new "PageDetail" and pass the value
                if (selectedItem == null)
                {
                    return;

                }
                else
                {
                    ((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page, selectedItem));
                }
            }
        }

        void RefreshListView()
        {
            //aqui fica o codigo para preencher a lista!!!
            IsBusy = false;
        }
       
        private Task PopulateList()
        {
            throw new NotImplementedException();
        }

        Command refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return refreshCommand;
            }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        //To let the UI know that something changed on the View Model
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
