using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Silence.ViewModel
{
    public class GravacoesListViewModel : INotifyPropertyChanged
    {
        public GravacoesListViewModel()
        {

            refreshCommand = new Command(RefreshListView);
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }

        private Task PopulateList()
        {
            throw new NotImplementedException();
        }
        void RefreshListView()
        {
            //aqui fica o codigo para preencher a lista!!!
            IsBusy = false;
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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
