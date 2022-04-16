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
    /// Interaction logic for UC_Temperature3.xaml
    /// </summary>
    public partial class UC_Temperature3 : UserControl
    {


        int Minimum = 00;
        int Maximum = 100;
        int TickNumber = 4;
        int SizeOfLine = 10;
        public UC_Temperature3()
        {
            InitializeComponent();
            Mamuti();

        }
        public void Mamuti()
        {
            DefineMamuti();
            int tempSize = (int)sld.Height;
            int step = (int)sld.Height / TickNumber;
            int countstep = (Maximum - Minimum) / TickNumber;
            for (int i = 0; i < ((int)sld.Height)/5; i++)
            {
                Line SmalllineRight = new Line
                {
                    X1 = 0,
                    Y1 = tempSize,
                    X2 = SizeOfLine-5,
                    Y2 = tempSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                };
                details_RightSide.Children.Add(SmalllineRight);
                Line SmalllineLeft = new Line
                {
                    X1 = 0,
                    Y1 = tempSize,
                    X2 = -(SizeOfLine-5),
                    Y2 = tempSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                };
                details_LeftSide.Children.Add(SmalllineLeft);


                tempSize -= 5;
            }

            tempSize = (int)sld.Height;

            for (int i = 0; i <= TickNumber; i++)
            {
                #region Right Side
                Line BiglineRight = new Line
                {
                    X1 = 0,
                    Y1 = tempSize,
                    X2 = SizeOfLine,
                    Y2 = tempSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };


                Label lbl = new Label
                {
                    Content = Minimum,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(00, tempSize - 5, 0, 0)
                };

                details_RightSide.Children.Add(BiglineRight);
                details_RightSide.Children.Add(lbl);
                #endregion
                #region Left Side
                Line lineScale2 = new Line
                {
                    X1 = 0,
                    Y1 = tempSize,
                    X2 = -SizeOfLine,
                    Y2 = tempSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                };
                Label lbl2 = new Label
                {
                    Content = Minimum,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(-20, tempSize - 5, 0, 0)
                };
                details_LeftSide.Children.Add(lineScale2);
                details_LeftSide.Children.Add(lbl2);
                #endregion
                Minimum += countstep;
                tempSize -= step;

            };
        }
        public void DefineMamuti()
        {

            Temperature3.Width = 100;
            Temperature3.Height = 500;

            sld.Height = 500;

            sld.Minimum = Minimum;
            sld.Maximum = Maximum;
        }
    }
}
