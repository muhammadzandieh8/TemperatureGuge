using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace TemperatureGuage
{
    /// <summary>
    /// Interaction logic for UC_Temperature.xaml
    /// </summary>
    public partial class UC_Temperature : UserControl
    {
        public UC_Temperature()
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
            int tempSize = (int)sld.Height;
            int step = (int)sld.Height / TickNumber;
            int countstep = (Maximum - Minimum) / TickNumber;
            for (int i = 0; i <= TickNumber; i++)
            {
                Line lineScale = new Line
                {
                    X1 = 0,
                    Y1 = tempSize,
                    X2 = SizeOfLine,
                    Y2 = tempSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                };

                Label lbl = new Label
                {
                    Content = Minimum,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(0, tempSize - 5, 0, 0)
                };
                Minimum += countstep;

                tempSize -= step;

                details.Children.Add(lineScale);
                details.Children.Add(lbl);


            };
        }
        public void DefineMamuti()
        {
            Temperature.Width = 100;
            Temperature.Height = 500;

            sld.Height = 500;

            sld.Minimum = Minimum;
            sld.Maximum = Maximum;
        }




        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    int max = 90;
        //    int min = -10;
        //    //int ZSizeOfLabel = 10;
        //    int step = 10;
        //    int numberoflbl = 10;
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Label lbl = new Label();
        //        lbl.Content = max;
        //        max = max - step;
        //        lbl.VerticalAlignment = VerticalAlignment.Top;
        //        lbl.HorizontalAlignment = HorizontalAlignment.Center;
        //        //lbl.Width = ZSizeOfLabel;
        //        //lbl.Height = ZSizeOfLabel;

        //        //lbl.Margin = new Thickness(X2 - ZSizeOfLabel / 2, Y2 - ZSizeOfLabel / 2, 0, 0);
        //        //lbl.Margin = new Thickness(i, i, 0, 0);

        //        lbl.Foreground = Brushes.WhiteSmoke;
        //        canvas_number.Children.Add(lbl);

        //    }
        //}
    }
}
