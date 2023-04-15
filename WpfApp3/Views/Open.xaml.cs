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
    /// Логика взаимодействия для Open.xaml
    /// </summary>
    public partial class Open : Page
    {
        public Open()
        {
            InitializeComponent();

            clients.ItemsSource = Appdata.db.Client.ToList();
        }
    }
}
