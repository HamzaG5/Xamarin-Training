using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.Models
{
    public class NotesTemplate : DataTemplate
    { 
        public NotesTemplate() : base(LoadTemplate)
        {
        }

        private static Label LoadTemplate()
        {
            Label textLabel = new Label();
            textLabel.SetBinding(Label.TextProperty, "Text");
            return textLabel;
        }
    }
}
