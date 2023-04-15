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
using WpfApp3.Model;

namespace WpfApp3.Views
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Name = name.Text;
            if (string.IsNullOrEmpty(Name.Trim()))
            {
                MessageBox.Show("Введите имя");
                return;
            }
            var Surname = surname.Text;
            if (string.IsNullOrEmpty(Surname.Trim()))
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            
            var Date = datetime.SelectedDate;
            if (Date == null)
            {
                MessageBox.Show("Выберите дату приема");
                return;
            }
            var clients = Appdata.db.Client.ToList();
            foreach (var item in clients)
            {
                if (item.data == (DateTime)Date)
                {
                     MessageBox.Show("Извините, на этот день уже назначен прием");
                    return;
                }
                
            }
            var lastClient = Appdata.db.Client.Select(n => n.id).ToList().Last();
            Client client = new Client();
            client.id = lastClient + 1;
            client.sername = Surname;
            client.name = Name;
            client.data = (DateTime)Date;
            Appdata.db.Client.Add(client);
            Appdata.db.SaveChangesAsync();
            NavigationService.GoBack();
            MessageBox.Show("Вы успешно записались");
        }

        private void Button_Click_1(object sender, object e)
        {
            NavigationService.GoBack();
        }
    }
}
