using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public Command ExitCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string noteText;

        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public DetailPageViewModel()
        {
            ExitCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync());
        }

    }
}
