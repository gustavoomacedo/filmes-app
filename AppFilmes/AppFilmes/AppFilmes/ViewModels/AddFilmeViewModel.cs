using AppFilmes.Models;
using AppFilmes.Views;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFilmes.ViewModels
{
    public class AddFilmeViewModel : BaseViewModel
    {
        public INavigation navegation { get; set; }

        public AddFilmeViewModel(INavigation _navigation)
        {
            this.navegation = _navigation;
            SalvarCommand = new Command(async () => await SalvarFilme());
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _diretor;
        public string Diretor
        {
            get { return _diretor; }
            set
            {
                _diretor = value;
                OnPropertyChanged();
            }
        }

        private string _estrelas;
        public string Estrelas
        {
            get { return _estrelas; }
            set
            {
                _estrelas = value;
                OnPropertyChanged();
            }
        }

        public Command SalvarCommand { get; set; }
        
        private async Task SalvarFilme()
        {
            var filme = new Filme();
            filme.Nome = this.Nome;
            filme.Diretor = this.Diretor;
            filme.Estrelas = Convert.ToInt32(this.Estrelas);
            var repository = new Repository();
            await repository.SalvarFilme(filme);

            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Sucesso", "Produto Adicionado com sucesso!", "OK");
            await navegation.PopAsync();
        }
    }
}
