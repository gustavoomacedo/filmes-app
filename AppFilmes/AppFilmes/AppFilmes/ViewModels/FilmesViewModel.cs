using AppFilmes.Models;
using AppFilmes.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFilmes.ViewModels
{
    public class FilmesViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public FilmesViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Filmes = new ObservableCollection<Filme>();
            GetFilmesCommand = new Command(async () => await GetFilmes(),() => !IsBusy);
            ContinueBtnClicked = new Command(async () => await GoToPageAdd());
        }

        private bool Busy;
        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetFilmesCommand.ChangeCanExecute();
            }
        }
        
        public Command GetFilmesCommand { get; set; }
        public Command ContinueBtnClicked { get; set; }

        public ObservableCollection<Filme> Filmes { get; set; }
        
        public async Task GoToPageAdd()
        {
            await Navigation.PushAsync(new AddFilmePage());
        }

        async Task GetFilmes()
        {
            if (!IsBusy)
            {
                Exception Error = null;
                try
                {
                    IsBusy = true;
                    var repository = new Repository();
                    var items = await repository.GetFilmes();
                    Filmes.Clear();
                    foreach (var Filme in items)
                    {
                        Filmes.Add(Filme);
                    }
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                    if (Error != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                        "Error!", Error.Message, "OK");
                    }

                }
            }
            return;
        }
    }
}
