using PR_14_KILE.ApplicationData;
using PR_14_KILE.MainPage;
using System;
using System.Collections.Generic;
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

namespace PR_14_KILE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelOdb = new SuVidiEntities(); // соединение с БД
            AppFrame.FrameMain = myFrame;  //загрузка фрейма со стартом
            myFrame.Navigate(new SuVidi());// страница PageFrutyr
        }
    }
}
