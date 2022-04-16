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

namespace TemperatureGuage
{
    /// <summary>
    /// Interaction logic for UC_Temperature1.xaml
    /// </summary>
    public partial class UC_Temperature1 : UserControl
    {
        public UC_Temperature1()
        {
            InitializeComponent();

            Mamuti();

        }
        
        int Minimum = 00;
        int Maximum = 100;
        int TickNumber = 4;
        int SizeOfLine = 10;

        public void Mamuti()
        {
            DefineMamuti();
            int tempSize = (int)details.Height;
            int step = (int)details.Height / TickNumber;
            int countstep = (Maximum - Minimum) / TickNumber;
            for (int i = 0; i <= TickNumber; i++)
            {
                Line lineScale = new Line
                {
                    X1 = 0,
                    Y1 = tempSize,
                    X2 = SizeOfLine,
                    Y2 = tempSize,
                    Stroke = Brushes.DarkGray,
                    StrokeThickness = 1,
                };

                Label lbl = new Label
                {
                    Content = Minimum,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(0, tempSize-5, 0, 0)
                };
                Minimum += countstep;

                tempSize -= step;

                details.Children.Add(lineScale);
                details.Children.Add(lbl);


            };
           
        }
        public void DefineMamuti()
        {
            UC_Temp.Width = 100;
            UC_Temp.Height = 500;
        }
    }

}

