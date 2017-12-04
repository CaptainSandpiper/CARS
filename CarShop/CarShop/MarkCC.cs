using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarShop 
{
    class MarkCC : INotifyPropertyChanged
    {
        private string markC;
        private string producerC;

        public string MarkC
        {
            get { return markC; }
            set
            {
                markC = value;
                OnPropertyChanged("MarkC");
            }
        }

        public string ProducerC
        {
            get { return producerC; }
            set
            {
                producerC = value;
                OnPropertyChanged("ProducerC");
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
