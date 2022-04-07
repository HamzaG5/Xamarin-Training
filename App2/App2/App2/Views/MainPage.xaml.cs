using App2.Models;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        Image babyYodaImage;
        Editor noteEditor;
        Label textLabel;
        Button saveButton, deleteButton;

        public MainPage()
        {
            Title = "Notes";

            BackgroundColor = Color.PowderBlue;

            BindingContext = new MainPageViewModel();

            babyYodaImage = new Image
            {
                Source = "baby2yoda.jpeg"
            };

            noteEditor = new Editor
            {
                Placeholder = "Enter Note",
                BackgroundColor = Color.White,
                Margin = new Thickness(10)
            };
            noteEditor.SetBinding(Editor.TextProperty, nameof(MainPageViewModel.NoteText));

            saveButton = new Button
            {
                Text = "Save",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                Margin = new Thickness(10)
            };
            //saveButton.Clicked += SaveButton_Clicked;
            saveButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.SaveNoteCommand));

            deleteButton = new Button
            {
                Text = "Delete",
                TextColor = Color.White,
                BackgroundColor = Color.Red,
                Margin = new Thickness(10)
            };
            //deleteButton.Clicked += DeleteButton_Clicked;
            deleteButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.EraseNotesCommand));

            textLabel = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10)
            };

            var collectionView = new CollectionView
            {
                ItemTemplate = new NotesTemplate(),
                SelectionMode = SelectionMode.Single
            };
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(MainPageViewModel.Notes));
            collectionView.SetBinding(CollectionView.SelectedItemProperty, nameof(MainPageViewModel.SelectedNote));
            collectionView.SetBinding(CollectionView.SelectionChangedCommandProperty, nameof(MainPageViewModel.NoteSelectedCommand));

            var grid = new Grid
            {
                Margin = new Thickness(20, 40),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star)},
                    new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star)},
                    new RowDefinition { Height = new GridLength(1.0, GridUnitType.Star)},
                    new RowDefinition { Height = new GridLength(2.0, GridUnitType.Star)}
                }
            };

            grid.Children.Add(babyYodaImage, 0, 0);
            Grid.SetColumnSpan(babyYodaImage, 2);

            grid.Children.Add(noteEditor, 0, 1);
            Grid.SetColumnSpan(noteEditor, 2);

            grid.Children.Add(saveButton, 0, 2);
            grid.Children.Add(deleteButton, 1, 2);

            grid.Children.Add(textLabel, 0, 3);
            Grid.SetColumnSpan(textLabel, 2);

            grid.Children.Add(collectionView, 0, 3);
            Grid.SetColumnSpan(collectionView, 2);

            Content = grid;
        }

        /*private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            textLabel.Text = "";
            noteEditor.Text = "";
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            textLabel.Text = noteEditor.Text;
        }*/
    }
}
