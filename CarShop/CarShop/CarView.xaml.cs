using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Логика взаимодействия для CarView.xaml
    /// </summary>
    public partial class CarView : UserControl
    {
        CarsEntities db = MainWindow.db;
        Cars s = new Cars();
        public int index=0;
        public CarView()
        {
            InitializeComponent();
        }

        private void ChangeBT_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(index.ToString());
            CarC carToChange = new CarC();
            foreach (Cars z in db.Cars)
            {
                if (z.CarID == index)
                {
                    
                    carToChange = new CarC { IndexC = z.CarID, MarkC = z.mark, ProducerC = z.producer, CostC = (int)z.cost, YearC = (int)z.year, ColorC = z.color, FileName = z.photo };
                }
            }

            AddCarWindow changeCar = new AddCarWindow();
            changeCar.MarkCB.SelectedItem = carToChange.MarkC;
            changeCar.Color_TB.Text = carToChange.ColorC;
            changeCar.YearCB.SelectedItem = carToChange.YearC;
            changeCar.CostTB.Text = carToChange.CostC.ToString();
            changeCar.FilePathTB.Text = carToChange.FileName;
            changeCar.AddCarButton.Content = "CHANGE";
            changeCar.add = false;
            changeCar.index = index;

            changeCar.Owner = MainWindow.ownt;
            
            
            changeCar.ShowDialog();
        }
    }
}
