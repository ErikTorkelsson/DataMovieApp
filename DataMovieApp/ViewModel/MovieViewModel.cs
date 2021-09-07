using DataMovieApp.Model;
using DataMovieApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace DataMovieApp.ViewModel
{

    public class MovieViewModel : INotifyPropertyChanged
    {

        private readonly IGenreApiService _genreApiService;
        private readonly IMoviesApiService _moviesApiService;

        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }

        public Movie ApiMovie { get; set; }

        public MovieViewModel(IGenreApiService genreApiService, IMoviesApiService moviesApiService)
        {
            _genreApiService = genreApiService;
            _moviesApiService = moviesApiService;
            Movies = new ObservableCollection<Movie>();
            Genres = new ObservableCollection<Genre>();
        }

        public async Task LoadMovies()
        {
            int id;
            if(_selectedGenre == null)
            {
                id = 18;
            }
            else
            {
                id = _selectedGenre.Id;
            }

            var movies = await _moviesApiService.GetMovies(id);
            Movies.Clear();

            foreach (var movie in movies.movies)
            {
                Movies.Add(movie);
            }
        }

        public async Task LoadGenres()
        {
            var genres = await _genreApiService.GetGenres();

            foreach (var genre in genres.genres)
            {
                Genres.Add(genre);
            }
        }

        private Movie _selectedMovie;       

        public event PropertyChangedEventHandler PropertyChanged;

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set 
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        private Genre _selectedGenre;

        public Genre SelectedGenre
        {
            get { return _selectedGenre; }
            set 
            { 
                _selectedGenre = value;
                OnPropertyChanged(nameof(SelectedGenre));
                LoadMovies();
            }
        }


        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));

            }

        }

    }
}
