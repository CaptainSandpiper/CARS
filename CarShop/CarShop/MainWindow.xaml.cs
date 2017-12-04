using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CarShop
{
 
    public partial class MainWindow : Window
    {
        public static CarsEntities db = new CarsEntities();
        
        private int pageChecker=0;
        public static int checker;
        public string prodFilter = "";
        public string markFilter = "";
        public bool sort = false;
        public static  Window ownt;
       
        public MainWindow()
        {
            
            InitializeComponent();
            ownt = this;
            AddComponenets();
            Grid a = MyGrid;
            DataContext = new ViewModelCars(a,pageChecker,db, prodFilter,markFilter, sort);
            
        }

      

        private void NxtPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageChecker+4 < checker && pageChecker>=0 )
            {

                pageChecker += 4;
                Grid a = MyGrid;
                InUpdatePage();
                DataContext = new ViewModelCars(a, pageChecker,db, prodFilter, markFilter, sort);
                Prev_Page.IsEnabled = true;
            }

            else { NxtPage.IsEnabled = false;  }

        }

        private void Prev_Page_Click(object sender, RoutedEventArgs e)
        {
            if (pageChecker  < checker && pageChecker > 0)
            {
                pageChecker -= 4;

                Grid a = MyGrid;
                InUpdatePage();
                DataContext = new ViewModelCars(a, pageChecker, db, prodFilter, markFilter, sort);
                NxtPage.IsEnabled = true;
            }

            else { Prev_Page.IsEnabled = false; }

        }

      public void InUpdatePage()
        {
            Grid a = MyGrid;
            a.Children.Clear();
            a.Children.Add(MAINPAGE);
            a.Children.Add(NxtPage);
            a.Children.Add(Prev_Page);
            a.Children.Add(ProducerCB);
            a.Children.Add(MarkFilterCB);
            a.Children.Add(ProducerBTN);
            a.Children.Add(AddNewCar);
            a.Children.Add(SortBT);
        }

        public void updateAfterChange()
        {
            Grid a = MyGrid;
            DataContext = new ViewModelCars(a, pageChecker, db, prodFilter, markFilter, sort);
        }

        private void AddComponenets()
        {
              List<ProducerC> Prods;
              Prods= new List<ProducerC> { };
             foreach (Producer prod in db.Producer)
            {
                Prods.Add(new ProducerC { ProducerName = prod.Producer1 });
            }


            for (int i = 0; i < Prods.Count; i++)
            {
                ProducerCB.Items.Add(Prods[i].ProducerName);
            }
            //ProducerCB.Items.Add("");


            List<MarkCC> Marks;
            Marks = new List<MarkCC> { };
            foreach (Mark prod in db.Mark)
            {
                Marks.Add(new MarkCC { MarkC = prod.Mark1 });
            }


            for (int i = 0; i < Marks.Count; i++)
            {
                MarkFilterCB.Items.Add(Marks[i].MarkC);
            }

        }

      

        private void ProducerBTN_Click(object sender, RoutedEventArgs e)
        {
            InUpdatePage();
            Grid a = MyGrid;
            pageChecker = 0;
            DataContext = new ViewModelCars(a, pageChecker, db, prodFilter, markFilter, sort);

        }

        private void ProducerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prodFilter = ProducerCB.SelectedItem.ToString();
            ProducerBTN.IsEnabled = true;
            
        }

        private void MAINPAGE_Click(object sender, RoutedEventArgs e)
        {
            NxtPage.IsEnabled = true;
            Prev_Page.IsEnabled = true;
            InUpdatePage();
            pageChecker = 0;
            prodFilter = "";
            markFilter = "";
            Grid a = MyGrid;
            DataContext = new ViewModelCars(a, pageChecker, db, "", "", sort);
        }

        private void MarkFilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            markFilter = MarkFilterCB.SelectedItem.ToString();
            ProducerBTN.IsEnabled = true;
        }

   

        private void SortBT_Click(object sender, RoutedEventArgs e)
        {
            sort = true;
            InUpdatePage();
            Grid a = MyGrid;
            pageChecker = 0;
            DataContext = new ViewModelCars(a, pageChecker, db, prodFilter, markFilter, sort);
        }

        private void AddNewCar_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCar = new AddCarWindow();
            addCar.Owner = this;
            addCar.Show();
        }
    }
}
