using App2.Models;
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
        private string noteText;

        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                var args = new PropertyChangedEventArgs(nameof(NoteText));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public MainPageViewModel()
        {
            NotesCollection = new ObservableCollection<NoteModel>();

            SaveNotesCommand = new Command(() =>
            {
                var note = new NoteModel
                {
                    Text = NoteText
                };

                NotesCollection.Add(note);
                NoteText = string.Empty;
            });

            EraseNotesCommand = new Command(() =>
            {
                NotesCollection.Clear();
            });
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NoteModel> NotesCollection { get; }

        public Command SaveNotesCommand { get; }

        public Command EraseNotesCommand { get; }

    }
}
