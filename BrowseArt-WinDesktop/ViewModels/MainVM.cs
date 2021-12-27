﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using BrowseArt_API.Models;
using BrowseArt_API.Repositories;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;

namespace BrowseArt_WinDesktop.ViewModels
{
    public class MainVM : BaseViewModel
    {
        private IUsersRepository _usersRepository;
        private IPhotosRepository _photosRepository;
        public MainVM(string currentUsername)
        {
            _usersRepository = new UsersRepository();
            _photosRepository = new PhotosRepository();

            CurrentUsername = currentUsername;
            UpdateData();
        }

        private ObservableCollection<Photo> _photos;
        public ObservableCollection<Photo> Photos
        {
            get => _photos;
            set => RaisePropertyChanged(ref _photos, value);
        }

        private string _currentUsername;
        public string CurrentUsername
        {
            get => _currentUsername;
            set => RaisePropertyChanged(ref _currentUsername, value);
        }

        #region Commands

        private ICommand _createPhoto;
        public ICommand CreatePhoto
        {
            get
            {
                return _createPhoto = new RelayCommand(() =>
                {
                    var dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() != true) return;

                    var image = new BitmapImage(new Uri(dialog.FileName));
                    var photo = new Photo()
                    {
                        Title = "testTitle",
                        ImageData = BitmapSourceToByteArray(image),
                        Username = CurrentUsername
                    };

                    var photosRepository = new PhotosRepository();
                    photosRepository.Create(photo);

                    UpdateData();
                });
            }
        }

        private ICommand _deletePhoto;
        public ICommand DeletePhoto
        {
            get
            {
                return _deletePhoto = new RelayCommand<int>(obj =>
                {
                    var photosRepository = new PhotosRepository();
                    photosRepository.Delete(obj);

                    UpdateData();
                });
            }
        }

        #endregion
        private void UpdateData()
        {
            var photosRepository = new PhotosRepository();

            if (Photos != null)
            {
                foreach (var t in Photos)
                {
                    photosRepository.Update(t);
                }
            }

            Photos = new ObservableCollection<Photo>(photosRepository.GetUserPhotos(CurrentUsername));
        }

        private static byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using var stream = new MemoryStream();

            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);

            return stream.ToArray();
        }
    }
}
