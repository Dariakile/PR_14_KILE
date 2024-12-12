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
    /// Логика взаимодействия для SuVidiAdd.xaml
    /// </summary>
    public partial class SuVidiAdd : Page
    {
        private Sklad _currenttovar = new Sklad();
        public SuVidiAdd(Sklad selectedtovar)
        {
            InitializeComponent();
            if (selectedtovar != null)
                _currenttovar = selectedtovar;

            DataContext = _currenttovar;
            ComboType.ItemsSource = SuVidiEntities.GetContext().Type.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currenttovar.naimenov))
                errors.AppendLine("Укажите название товара");
            if (_currenttovar.kolichestvo <= 0)
                errors.AppendLine("Количество товара не может быть меньше или равно 0");
            if (_currenttovar.cena <= 0)
                errors.AppendLine("Цена не може быть меньше или равно 0");
            if (_currenttovar.Type == null)
                errors.AppendLine("Выберете тип");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //добавление
            if (_currenttovar.id == 0)
                SuVidiEntities.GetContext().Sklad.Add(_currenttovar);

            //обработаем вариант выпада/Записи данных
            try
            {
                SuVidiEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
