using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private List<string> images;
        private int currentIndex = 0;
        public Window1()
        {
            InitializeComponent();
            LoadImages(@"C:\Users\Ваня\Downloads\images123321");
            DisplayImage();
        }
        private void LoadImages(string path)
        {
            if(Directory.Exists(path))
            {
                images = new List<string>(Directory.GetFiles((path), "*.jpeg"));
                images.AddRange(Directory.GetFiles((path), "*.gif"));
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void DisplayImage()
        {
            if (images == null || images.Count==0)
            {
                MessageBox.Show("Not exist");
                return;
            }
            var imagePath = images[currentIndex];
            DisplayImageForm.Source = new BitmapImage(new Uri(imagePath));
        }
        private void MenuItemClick_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItem_nextimg(object sender, RoutedEventArgs e)
        {
            if(images == null || images.Count == 0)
            {
                MessageBox.Show("No images");
                return;
            }
            if (currentIndex < images.Count-1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            DisplayImage();
        }
        private void MenuItem_previmg(object sender, RoutedEventArgs e)
        {
            if (images == null || images.Count == 0)
            {
                MessageBox.Show("No images");
                return;
            }
            if (currentIndex > 0 )
            {
                currentIndex--;
            }
            else
            {
                currentIndex = images.Count-1;
            }
            DisplayImage();
        }
    }
}
