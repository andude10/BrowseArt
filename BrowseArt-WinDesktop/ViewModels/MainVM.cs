using System;
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
        public MainVM(User currentUser)
        {
            CurrentUser = currentUser;
            UpdateData();
        }

        private ObservableCollection<Photo> _photos;
        public ObservableCollection<Photo> Photos
        {
            get => _photos;
            set => RaisePropertyChanged(ref _photos, value);
        }

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set => RaisePropertyChanged(ref _currentUser, value);
        }

        #region Commands

        private ICommand _createPhoto;
        public ICommand CreatePhoto
        {
            get
            {
                return _createPhoto = new RelayCommand(() =>
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        BitmapSource image = new BitmapImage(new Uri(dialog.FileName));
                        byte[] imageData = BitmapSourceToByteArray(image);
                        var photo = new Photo()
                        {
                            Title = "testTitle",
                            ImageData = imageData,
                            Username = CurrentUser.Username
                        };

                        PhotosRepository photosRepository = new PhotosRepository();
                        photosRepository.Create(photo);

                        UpdateData();
                    }
                });
            }
        }

        #endregion

        private void UpdateData()
        {
            Photos = new ObservableCollection<Photo>(new PhotosRepository().GetObjectsList());
        }

        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using var stream = new MemoryStream();

            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);

            return stream.ToArray();
        }
    }
}
