using App2.Models;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NoteModel> Notes { get; }

        public Command SaveNoteCommand { get; }

        public Command EraseNotesCommand { get; }

        public Command NoteSelectedCommand { get; }



        private string noteText;

        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));

                SaveNoteCommand.ChangeCanExecute();
            }
        }

        NoteModel selectedNote;
        public NoteModel SelectedNote 
        { 
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }

        public MainPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();

            SaveNoteCommand = new Command(() =>
            {
                Notes.Add(new NoteModel { Text = NoteText });
                NoteText = string.Empty;
            },
            () => !string.IsNullOrEmpty(NoteText));

            EraseNotesCommand = new Command(() => Notes.Clear());

            NoteSelectedCommand = new Command (async () =>
            {
                if (SelectedNote is null)
                    return;

                var detailViewModel = new DetailPageViewModel
                {
                    NoteText = SelectedNote.Text
                };

                await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(detailViewModel));

                SelectedNote = null;
            });

        }
    }
}
