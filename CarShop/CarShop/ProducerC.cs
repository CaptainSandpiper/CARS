﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarShop
{
    class ProducerC : INotifyPropertyChanged
    {

        private string producerName;

        public string ProducerName
        {
            get { return producerName; }
            set
            {
                producerName = value;
                OnPropertyChanged("ProducerName");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
