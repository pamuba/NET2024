﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.ViewModel;

namespace WeatherApp.Commands
{
    internal class SearchCommand : ICommand
    {
        private WeatherVM VM { get; set; }


        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;
            if (string.IsNullOrWhiteSpace(query))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MakeQuery();
        }
    }
}
