using DataMovieApp.Model;
using DataMovieApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataMovieApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MovieViewModel _movieViewModel;

        public MainWindow(MovieViewModel movieViewModel)
        {
            InitializeComponent();
            _movieViewModel = movieViewModel;
            Loaded += MainWindow_Loaded;
            

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _movieViewModel.LoadGenres();
            await _movieViewModel.LoadMovies();           
            DataContext = _movieViewModel;
        }
    }
}
