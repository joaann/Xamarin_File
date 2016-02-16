using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.IO;
using System.Reflection;

using Xamarin.Forms;

namespace Xamarin_File
{
    public class LoadResourceTextSmall : ContentPage
    {
        public LoadResourceTextSmall()
        {
            var editor = new Label { Text = "loading...", HeightRequest = 300 };

            var assembly = typeof(LoadResourceTextBig).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Xamarin_File.test512kb.txt");

            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            editor.Text = text;

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "Text file content",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    }, editor
                }
            };

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }
    }
}
