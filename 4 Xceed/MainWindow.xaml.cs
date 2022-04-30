using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4_Xceed
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e) //при нажатии кнопки пишем в песочницу ClrPcker.SelectedColor
        {                                                         //и пишем сообщение
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStorage);
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine(ClrPcker.SelectedColor); //пишем в файл значение ClrPcker.SelectedColor ColorLabel.Background
            userWriter.Close();
            userStream.Close();
            ColorLabel.Content = string.Format("Цвет '{0}' сохранен\nв изолированное хранилище", ClrPcker.SelectedColorText);
        }                                                                                     // ClrPcker.SelectedColorText - текстовое название цвета

        private void ClrPcker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)// ClrPcker_SelectedColorChanged - свойство 
        {
            ColorLabel.Content = ClrPcker.SelectedColorText;

            var bc = new BrushConverter();
            ColorLabel.Background = (Brush)bc.ConvertFromString(ClrPcker.SelectedColor.ToString());
        }

        private void Window_Loaded1(object sender, RoutedEventArgs e)//когда окно загружено- читаем из песочницы инфо о цвете
        {                                                            // и пишем ее в ColorLabel.Background
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.OpenOrCreate, userStorage);
            StreamReader userReader = new StreamReader(userStream);

            string color = userReader.ReadToEnd();
            userReader.Close();
            userStream.Close();

            var bc = new BrushConverter(); //
            if (!string.IsNullOrEmpty(color))
            {
                ColorLabel.Background = (Brush)bc.ConvertFromString(color);// превращаем значение типа стринг(взятое из песочницы)
            }
        }
        // ColorLabel- это имя Label                                // в object и приводим к типу Brush, чтоб назначить цвет фона
    }//C:\Users\Yurii\AppData\Local\IsolatedStorage\bhbfpvkj.huv\aiaereik.gpv\Url.qlxv3fdk4uqguszqd43upxxopnkg15z1\AssemFiles
}
