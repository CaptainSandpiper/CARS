using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        CarsEntities db = MainWindow.db;
        private string choseMark;
        public bool add = true;
        public int index = 0;

        public AddCarWindow()
        {
            InitializeComponent();
            AddComponenets();
        }

        private void AddComponenets()
        {

            List<MarkCC> Marks;
            Marks = new List<MarkCC> { };
            foreach (Mark prod in db.Mark)
            {
                Marks.Add(new MarkCC { MarkC = prod.Mark1 });
            }


            for (int i = 0; i < Marks.Count; i++)
            {
                MarkCB.Items.Add(Marks[i].MarkC);
            }

            for (int i = 1980; i < 2018; i++)
            {
                YearCB.Items.Add(i);
            }

        }

        private void MarkCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            choseMark = MarkCB.SelectedItem.ToString();

            foreach (Mark u in db.Mark)
            {
                if (u.Mark1 == choseMark)
                {
                    ProducerTB.Text = u.Producer.ToString();
                }
            }

        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog imagePath = new OpenFileDialog();
            imagePath.ShowDialog();
            if (!File.Exists(imagePath.FileName) && !imagePath.FileName.Contains(".jpg"))
            {
                MessageBox.Show($"No selected files!");
                return;
            }
            FilePathTB.Text = imagePath.FileName;
        }

        private void Cost_Value_Chenged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CostTB.Text = "";
            CostTB.Text = ((int)(CostSlider.Value)).ToString();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            addCar();
        }

        private void addCar()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                if (add)
                {
                    if (MarkCB.SelectedItem != null && Color_TB.Text != "" && YearCB.SelectedItem != null && CostTB.Text != "")
                    {
                        Cars a = new Cars();
                        a.CarID = db.Cars.Count() + 1;
                        a.mark = MarkCB.SelectedItem.ToString();
                        a.producer = ProducerTB.Text;
                        a.color = Color_TB.Text;
                        a.cost = Convert.ToInt32(CostTB.Text);
                        a.year = Convert.ToInt32(YearCB.SelectedItem.ToString());

                        if (FilePathTB.Text != "")
                        {
                            a.photo = FilePathTB.Text;
                        }

                        db.Cars.Add(a);
                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Автомобиль успешно добавлен");

                    
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!!!");
                    }
                }
                else
                {
                    if (MarkCB.SelectedItem != null && Color_TB.Text != "" && YearCB.SelectedItem != null && CostTB.Text != "")
                    {
                  
                        var a = db.Cars
                            .Where(c => c.CarID == index)
                            .FirstOrDefault();

                        a.CarID = index;
                        a.mark = MarkCB.SelectedItem.ToString();
                        a.producer = ProducerTB.Text;
                        a.color = Color_TB.Text;
                        a.cost = Convert.ToInt32(CostTB.Text);
                        a.year = Convert.ToInt32(YearCB.SelectedItem.ToString());

                        if (FilePathTB.Text != "")
                        {
                            a.photo = FilePathTB.Text;
                        }

                      
                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Автомобиль успешно добавлен");

                        MainWindow main = this.Owner as MainWindow;
                        main.InUpdatePage();
                        main.updateAfterChange();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!!!");
                    }
                }
            }
        }
    }
}
