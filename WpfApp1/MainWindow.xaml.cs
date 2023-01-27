using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using FilmsChanger.Enums;
using FilmsChanger.Models;
using FilmsChanger.Service;

namespace FilmsChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ListFilmService _listFilmService;
        private readonly GroupFilterService _groupFilter;
        private readonly ListCollectionView? _view;
        private readonly AddFilmService _addFilmService;
        private readonly StatsFilmService _statsFilmService;
        private readonly ChangeFilmService _changeFilmService;
        private readonly SaveLoadService _saveLoadService;
        private Change _change;

        public MainWindow(ListFilmService listFilmService, AddFilmService addFilmService, 
            StatsFilmService statsFilmService, ChangeFilmService changeFilmService,
            SaveLoadService saveLoadService)
        {
            InitializeComponent();

            _saveLoadService = saveLoadService;
            _listFilmService = listFilmService;
            _addFilmService = addFilmService;
            _statsFilmService = statsFilmService;
            _changeFilmService = changeFilmService;
            _groupFilter = new GroupFilterService();
            _change = _changeFilmService.Change;

            dgAllList.ItemsSource = _listFilmService.FilmsList;

            var itemsSource = this.dgAllList.ItemsSource;
            if (itemsSource != null && CollectionViewSource.GetDefaultView(itemsSource) is ListCollectionView view)
            {
                _view = view;
            }

            UpdateInfoChange();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить данный фильм/аниме ?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            var button = (Button)sender;
            if (button.DataContext is Films film) _listFilmService.DeleteFilms(film);
            _view?.Refresh();
        }

        private void ViewRadio_Click(object sender, RoutedEventArgs e)
        {
            var pressed = (RadioButton)sender;

            switch (pressed.Name)
            {
                case "IsView":
                    _groupFilter.RemoveFilter(FilterEnum.NotView);
                    _groupFilter.AddFilter(FilterEnum.IsView,x => ((Films)x).IsView);
                    break;
                case "NotView":
                    _groupFilter.RemoveFilter(FilterEnum.IsView);
                    _groupFilter.AddFilter(FilterEnum.NotView,x => !((Films)x).IsView);
                    break;
                case "AnimeRadio":
                    _groupFilter.RemoveFilter(FilterEnum.IsFilm);
                    _groupFilter.AddFilter(FilterEnum.IsAnime,x => ((Films)x).TypeEnum == TypeEnum.IsAnime);
                    break;
                case "FilmRadio":
                    _groupFilter.RemoveFilter(FilterEnum.IsAnime);
                    _groupFilter.AddFilter(FilterEnum.IsFilm,x => ((Films)x).TypeEnum == TypeEnum.IsFilm);
                    break;
                case "AllRadio":
                    _groupFilter.RemoveFilter(FilterEnum.IsFilm);
                    _groupFilter.RemoveFilter(FilterEnum.IsAnime);
                    break;
                case "AllView":
                    _groupFilter.RemoveFilter(FilterEnum.NotView);
                    _groupFilter.RemoveFilter(FilterEnum.IsView);
                    break;

            }

            if (_view != null)
            {
                _view.Filter = _groupFilter.Filter;
                _view.Refresh();
            }
        }

        private void IsFilm_Checked(object sender, RoutedEventArgs e)
        {
            AddFilmBtn.IsEnabled = true;
        }

        private void AddFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = (Button)sender;
            var isFilm = IsFilm.IsChecked;
            var filmList = FilmList.Text;

            _addFilmService.AddFilms(filmList, (bool)isFilm);

            radioButton.IsEnabled = false;
            IsFilm.IsChecked = false;
            NotFilm.IsChecked = false;
            FilmList.Text = string.Empty;
        }

        private void TabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dgAllList.ItemsSource = _listFilmService.FilmsList;
            _view?.Refresh();
        }

        private void Stats_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var stats = _statsFilmService.GetStats();
            DataContext = stats;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var change = _changeFilmService.ChangeFilms();
            _change = change;
            DataContext = change;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (button.DataContext is Change film)
            {
                var id = film.Id;
                _changeFilmService.SetFilm(id);

                UpdateInfoChange();
            }
            else
            {
                MessageBox.Show("Нет фильма/аниме",
                    "Внимание",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Change_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UpdateInfoChange();
        }

        private void UpdateInfoChange()
        {
            _changeFilmService.GetActualInformation();
            var change = _changeFilmService.Change;
            DataContext = change;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _saveLoadService.Save();
        }
    }
}
