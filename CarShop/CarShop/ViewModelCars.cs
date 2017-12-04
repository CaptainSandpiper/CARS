using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.IO;

namespace CarShop
{
    class ViewModelCars : INotifyPropertyChanged
    {
     
        private CarC selectedCar;

       
        public List<CarC> CarsOrderbyCost { get; set; }
        public List<CarC> Cars { get; set; }

        public CarC SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public ViewModelCars(Grid MyGrid, int k, CarsEntities db, string prodName, string MarkName, bool isorder)
        {
           
            Cars = new List<CarC> { };

            if (prodName == "" && MarkName =="")
            {
                foreach (Cars z in db.Cars)
                {
                    Cars.Add(new CarC { IndexC = z.CarID, MarkC = z.mark, ProducerC = z.producer, CostC = (int)z.cost, YearC = (int)z.year, ColorC = z.color, FileName = z.photo });
                };
            }
            else if(prodName !="" && MarkName =="")
            {
                foreach (Cars z in db.Cars)
                {
                    if (prodName == z.producer)
                    {
                        Cars.Add(new CarC { IndexC = z.CarID, MarkC = z.mark, ProducerC = z.producer, CostC = (int)z.cost, YearC = (int)z.year, ColorC = z.color, FileName = z.photo });
                    }
                };
            }
            else if (prodName == "" && MarkName != "")
            {
                foreach (Cars z in db.Cars)
                {
                    if (MarkName == z.mark)
                    {
                        Cars.Add(new CarC { IndexC = z.CarID, MarkC = z.mark, ProducerC = z.producer, CostC = (int)z.cost, YearC = (int)z.year, ColorC = z.color, FileName = z.photo });
                    }
                };
            }
            else if (prodName != "" && MarkName != "")
            {
                foreach (Cars z in db.Cars)
                {
                    if (MarkName == z.mark && prodName == z.producer)
                    {
                        Cars.Add(new CarC { IndexC = z.CarID, MarkC = z.mark, ProducerC = z.producer, CostC = (int)z.cost, YearC = (int)z.year, ColorC = z.color, FileName = z.photo });
                    }
                };
            }

            CarsOrderbyCost = new List<CarC> { };
            if (isorder)
            {

             
                var sorted = from u in Cars
                             orderby u.CostC
                             select u;
                
                foreach (CarC u in sorted)
                {
                    CarsOrderbyCost.Add(new CarC { IndexC = u.IndexC, MarkC = u.MarkC, ProducerC = u.ProducerC, CostC = (int)u.CostC, YearC = (int)u.YearC, ColorC = u.ColorC, FileName = u.FileName });
                }

            }



            MainWindow.checker = Cars.Count();
            int ken = 160;
            int sken = 2 * ken;
            int coutCarViews;
         
            CarView[] Ray = new CarView[] { };

            if (k + 4 < Cars.Count) { Ray = new CarView[4]; coutCarViews = 4; }
            else {
                
                if ((Cars.Count - k) < 0) { coutCarViews = 0; }
                else { coutCarViews = Cars.Count - k; }
                Ray = new CarView[coutCarViews];
               
            }
            for (int i = 0; i < coutCarViews; i++)
            {
                Ray[i] = new CarView();
                Ray[i].Width = 300;
                Ray[i].Height = 300;
                Ray[i].HorizontalAlignment = HorizontalAlignment.Left;
                Ray[i].VerticalAlignment = VerticalAlignment.Top;

                if (i % 2 == 0) { Ray[i].Margin = new Thickness(i * ken+5, 25, 0, 0); }
                else { Ray[i].Margin = new Thickness( (i-1) * ken+5 , 350, 0, 0); }
              
                MyGrid.Children.Add(Ray[i]);
            }

         
            for (int o = k,  j = 0 ; o<k+coutCarViews; o++,j++)
            {
                String FileName = "";
                if (!isorder)
                {
                    Ray[j].Mark_TB.Text = Cars[o].MarkC;
                    Ray[j].ProdTB.Text = Cars[o].ProducerC;
                    Ray[j].Year_TB.Text = (Cars[o].YearC).ToString();
                    Ray[j].Cost_TB.Text = (Cars[o].CostC).ToString();
                    Ray[j].Color_TB.Text = Cars[o].ColorC;
                    Ray[j].index = Cars[o].IndexC;

                    if (Cars[o].FileName != null)
                    {
                        FileName = Cars[o].FileName;
                        System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                        image.Stretch = Stretch.UniformToFill;
                        BitmapImage bmp = new BitmapImage(new Uri(FileName, UriKind.Relative));

                        image.Width = 100;
                        image.Height = 100;
                        image.Source = bmp;
                        Paragraph block = new Paragraph();
                        block.Margin = new Thickness(2);
                        block.Inlines.Add(image);
                        if (File.Exists(FileName))
                        {
                            Ray[j].ForImage.Source = new BitmapImage(new Uri(FileName, UriKind.Absolute));
                        }

                    }
                }
                else
                {
                    Ray[j].Mark_TB.Text = CarsOrderbyCost[o].MarkC;
                    Ray[j].ProdTB.Text = CarsOrderbyCost[o].ProducerC;
                    Ray[j].Year_TB.Text = (CarsOrderbyCost[o].YearC).ToString();
                    Ray[j].Cost_TB.Text = (CarsOrderbyCost[o].CostC).ToString();
                    Ray[j].Color_TB.Text = CarsOrderbyCost[o].ColorC;
                    Ray[j].index = CarsOrderbyCost[o].IndexC;

                    if (CarsOrderbyCost[o].FileName != null)
                    {
                 
                        FileName = CarsOrderbyCost[o].FileName;
                        System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                        image.Stretch = Stretch.UniformToFill;
                        BitmapImage bmp = new BitmapImage(new Uri(FileName, UriKind.Relative));

                        image.Width = 100;
                        image.Height = 100;
                        image.Source = bmp;
                        Paragraph block = new Paragraph();
                        block.Margin = new Thickness(2);
                        block.Inlines.Add(image);
                        if (File.Exists(FileName))
                        {
                            Ray[j].ForImage.Source = new BitmapImage(new Uri(FileName, UriKind.Absolute));
                        }

                    }
                }
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

