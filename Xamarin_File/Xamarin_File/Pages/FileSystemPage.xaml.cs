using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_File;
using Xamarin.Forms;
using PCLStorage;
using System.Reflection;
using Plugin.EmbeddedResource;

namespace Xamarin_File.Pages
{
    public partial class FileSystemPage : ContentPage
    {
        public FileSystemPage()
        {
            InitializeComponent();

            writeBigButton.Clicked += async (sender, args) =>
            {
                try{
                    IFolder rootFolder = FileSystem.Current.LocalStorage;

                    //Debug.WriteLine("Rootfolder: " + rootFolder.Path);

                    IFolder folder = await rootFolder.CreateFolderAsync("Pages", CreationCollisionOption.OpenIfExists);

                    //Debug.WriteLine("WriteFolder: " + folder.Path);

                    IFile file = await folder.CreateFileAsync("Test1MB.txt", CreationCollisionOption.ReplaceExisting);

                    //Debug.WriteLine("WriteFile: " + file.Path);
                    var assembly = typeof(FileSystemPage).GetTypeInfo().Assembly;
                    Stream stream = assembly.GetManifestResourceStream("Xamarin_File.test1mb.txt");
                    string text = "";
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        text = reader.ReadToEnd();
                    }
                    //Debug.WriteLine("Wrote: "+text);
                    await file.WriteAllTextAsync(text);
                    await DisplayAlert("Wrote to file", "1MB file written", "OK");
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Error", "Some Error: " + ex, "OK");
                }

            };
            readBigButton.Clicked += async (sender, args) =>
            {
                try{
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    //Debug.WriteLine("Rootfolder: "+rootFolder.Path);
                    IFolder folder = await rootFolder.GetFolderAsync("Pages");
                    //Debug.WriteLine("ReadFolder: " + folder.Path);
                    IFile file = await folder.GetFileAsync("Test1MB.txt");
                    //Debug.WriteLine("ReadFile: "+file.Path);
                    string contents = await file.ReadAllTextAsync();
                    //Debug.WriteLine(contents);
                    await DisplayAlert("1MB contents: ", contents,"OK");

                }
                catch(Exception ex){
                    await DisplayAlert("Error", "Some Error: " + ex, "OK");
                }
            };
            writeSmallButton.Clicked += async (sender, args) =>
            {
                try
                {
                    IFolder rootFolder = FileSystem.Current.LocalStorage;

                    //Debug.WriteLine("Rootfolder: " + rootFolder.Path);

                    IFolder folder = await rootFolder.CreateFolderAsync("Pages", CreationCollisionOption.OpenIfExists);

                    //Debug.WriteLine("WriteFolder: " + folder.Path);

                    IFile file = await folder.CreateFileAsync("Test512kb.txt", CreationCollisionOption.ReplaceExisting);

                    //Debug.WriteLine("WriteFile: " + file.Path);
                    var assembly = typeof(FileSystemPage).GetTypeInfo().Assembly;
                    Stream stream = assembly.GetManifestResourceStream("Xamarin_File.test512kb.txt");
                    string text = "";
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        text = reader.ReadToEnd();
                    }
                    //Debug.WriteLine("Wrote: "+text);
                    await file.WriteAllTextAsync(text);
                    await DisplayAlert("Wrote to file", "512kb file written", "OK");
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Error", "Some Error: " + ex, "OK");
                }
            };
            readSmallButton.Clicked += async (sender, args) =>
            {
                try
                {
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    //Debug.WriteLine("Rootfolder: " + rootFolder.Path);
                    IFolder folder = await rootFolder.GetFolderAsync("Pages");
                    //Debug.WriteLine("ReadFolder: " + folder.Path);
                    IFile file = await folder.GetFileAsync("Test512kb.txt");
                    //Debug.WriteLine("ReadFile: " + file.Path);
                    string contents = await file.ReadAllTextAsync();
                    //Debug.WriteLine(contents);
                    await DisplayAlert("512kb contents: ", contents, "OK");

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Some Error: " + ex, "OK");
                }
            };
        }
    }
}
