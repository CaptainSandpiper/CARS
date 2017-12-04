using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarShop
{
   public  class CarC : INotifyPropertyChanged
    {
        private int indexC;
        private string markC;
        private string producerC;
        private string colorC;
        private int costC;
        private int yearC;
        private string fileName;

        public int IndexC
        {
            get { return indexC; }
            set
            {
                indexC = value;
                OnPropertyChanged("IndexC");
            }
        }

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

        public string ColorC
        {
            get { return colorC; }
            set
            {
                colorC = value;
                OnPropertyChanged("colorC");
            }
        }

        public int CostC
        {
            get { return costC; }
            set
            {
                costC = value;
                OnPropertyChanged("CostC");
            }
        }

        public int YearC
        {
            get { return yearC; }
            set
            {
                yearC = value;
                OnPropertyChanged("YearC");
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
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

