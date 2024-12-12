using PR_14_KILE.ApplicationData;
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

namespace PR_14_KILE.MainPage
{
    /// <summary>
    /// Логика взаимодействия для SuVidi.xaml
    /// </summary>
    public partial class SuVidi : Page
    {
        public SuVidi()
        {
            InitializeComponent();
            DtGridTovar.ItemsSource = SuVidiEntities.GetContext().Sklad.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new SuVidiAdd(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemiving = DtGridTovar.SelectedItems.Cast<Sklad>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить текущее {tovarForRemiving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SuVidiEntities.GetContext().Sklad.RemoveRange(tovarForRemiving);
                    SuVidiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DtGridTovar.ItemsSource = SuVidiEntities.GetContext().Sklad.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new SuVidiAdd((sender as Button).DataContext as Sklad));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SuVidiEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DtGridTovar.ItemsSource = SuVidiEntities.GetContext().Sklad.ToList();
        }
    }
}
