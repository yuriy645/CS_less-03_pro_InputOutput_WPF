## My homework for the C# Professional course, less-03_pro_IO
1. Create 100 directories on disk named Folder_0 to Folder_99, then delete them.
2. Create a file, write arbitrary data to it, and close the file. Then reopen
    this file, read data from it and print it to the console.
3. Write an application to search for a given file on disk. Add code using
    class FileStream and allows you to view the file in a text window. In conclusion
    add the ability to compress the found file.
4. Create a WPF Application that allows users to save data to isolated storage.
    This task requires the presence of the Xceed.Wpf.Toolkit.dll library. Her
    can be obtained through References -> Manage NuGet Packages... -> in the search write Extended
    WPF Toolkit (in addition to the library we are interested in, others will be installed), or
    download directly on the site http://wpftoolkit.codeplex.com/ and connect to the project only
    the library we are interested in (References -> Add Reference ...).
        a. Place a Label and a Button in the window.
        b. Place in the ColorPicker window (this tool is provided by the above
           library). To do this, in the XAML code in the Window tag, connect the space
           names xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" . Also, we need an event Loaded windows.
        c. Implement so that when a color is selected from the ColorPicker, the name is displayed in the Label
           the selected color and the background of the Label was painted in this color. At the push of a button, information about
           colors are stored in isolated storage. When you start the application again, the background color
           The Label remains the same as it was saved on previous runs of the application.
