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

namespace TelegramBotAdminPanel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramMessageClient client;

        public MainWindow()
        {
            InitializeComponent();

            client = new TelegramMessageClient(this);

            logList.ItemsSource = client.BotMessageLog;
        }

        private void btnMsgSendClick(object sender, RoutedEventArgs e)
        {
            client.SendMessage(txtMsgSend.Text, TargetSend.Text);
        }
    }
    //Комментарий
}
