using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Silence.ViewModel;
using System.Collections.ObjectModel;

namespace Silence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gravacoes : ContentPage
    {
        GravacoesListViewModel aux = new GravacoesListViewModel();
        

        public ObservableCollection<GravacoesListViewModel> elements { get; set; }
        public Gravacoes()
        {
            InitializeComponent();
            var viewModel = new GravacoesListViewModel();
            BindingContext = viewModel;

            gravacoesList.IsPullToRefreshEnabled = true;
            gravacoesList.RefreshCommand = viewModel.RefreshCommand;
            gravacoesList.SetBinding(ListView.IsRefreshingProperty, nameof(viewModel.IsBusy));

            elements = new ObservableCollection<GravacoesListViewModel>();
            elements.Add(new GravacoesListViewModel { Name = "Teste", Type = "Teste1", Image = "tape.png" });
            gravacoesList.ItemsSource = elements;

        }
    }
}