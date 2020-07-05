using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBotAdminPanel
{

    class TelegramMessageClient
    {
        private MainWindow w;

        private TelegramBotClient bot;
        public ObservableCollection<MessageLog> BotMessageLog { get; set; }

        private void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine("---");
            Debug.WriteLine("+++---");

            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            Debug.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            if (e.Message.Text == null) return;

            var messageText = e.Message.Text;

            w.Dispatcher.Invoke(() =>
            {
                BotMessageLog.Add(
                new MessageLog(
                    DateTime.Now.ToLongTimeString(), messageText, e.Message.Chat.FirstName, e.Message.Chat.Id));
            });
        }

        public TelegramMessageClient(MainWindow W, string PathToken = @"C:\Users\axe21\Desktop\дз скилбокс\Модуль 9. Работа с сетью\telegram_bot_token.txt")
        {
            this.BotMessageLog = new ObservableCollection<MessageLog>();
            this.w = W;

            bot = new TelegramBotClient(File.ReadAllText(PathToken));

            bot.OnMessage += MessageListener;

            bot.StartReceiving();
        }

        public void SendMessage(string Text, string Id)
        {
            long id = Convert.ToInt64(Id);
            bot.SendTextMessageAsync(id, Text);
        }

    }
}
