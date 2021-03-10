using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows;
using Cave;
using Cave.Logging;

namespace LogView
{
    internal class LogItemList : LogReceiver
    {
        private readonly ObservableCollection<LogMessage> items = new ObservableCollection<LogMessage>();

        public ObservableCollection<LogMessage> Items => items;

        public override void Write(LogMessage msg)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                    Items.Add(msg);
            });
        }

        protected override void Write(DateTime dateTime, LogLevel level, string source, XT content) => Write(new LogMessage(source, dateTime, level, null, content, null));

        public void GenerateFakeLogMessages(int n)
        {
            var names = typeof(System.Linq.Expressions.ExpressionType).GetEnumNames();
            var rnd = new Random();
            for (int i=0; i<n; i++)
            {
                var msg = new LogMessage(names[rnd.Next(names.Length)], DateTime.Now, (LogLevel)rnd.Next(8), null, $"{names[rnd.Next(names.Length)]} - {names[rnd.Next(names.Length)]}", null);
                Write(msg);
            }
        }
    }
}
