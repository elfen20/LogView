﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
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
            App.Current.Dispatcher.InvokeAsync((Action)delegate
            {
                    Items.Add(msg);
            });
        }

        protected override void Write(DateTime dateTime, LogLevel level, string source, XT content) => Write(new LogMessage(source, dateTime, level, null, content, null));
    }
}
