using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Silence.ViewModel
{
    public class HomeListViewModel : INotifyPropertyChanged
    {
        public HomeListViewModel()
        {
           
            refreshCommand = new Command(RefreshListView);
        }

        async void RefreshListView()
        {
            //aqui fica o codigo para preencher a lista!!!
            IsBusy = false;
        }
       
        private Task PopulateList()
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }


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
