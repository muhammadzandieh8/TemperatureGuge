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
    /// Interaction logic for UC_Temperature2.xaml
    /// </summary>
    public partial class UC_Temperature2 : UserControl
    {
        #region Zwidth
        public int Zwidth
        {
            get { return (int)GetValue(ZwidthProperty); }
            set
            {
                SetValue(ZwidthProperty, value);
            }
        }
        public static DependencyProperty ZwidthProperty = DependencyProperty.Register("Zwidth", typeof(int), typeof(UC_Temperature2), new PropertyMetadata(200, OnChangeZwidth));
        private static void OnChangeZwidth(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as UC_Temperature2;
            ct.UpdateZwidth((int)e.NewValue);
        }
        public void UpdateZwidth(int _Zwidth)
        {
            
        }
        #endregion
        #region ZHeight
        public int ZHeight
        {
            get { return (int)GetValue(ZHeightProperty); }
            set
            {
                SetValue(ZHeightProperty, value);
            }
        }
        public static DependencyProperty ZHeightProperty = DependencyProperty.Register("ZHeight", typeof(int), typeof(UC_Temperature2), new PropertyMetadata(050, OnChangeZHeight));
        private static void OnChangeZHeight(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as UC_Temperature2;
            ct.UpdateZHeight((int)e.NewValue);
        }
        public void UpdateZHeight(int _ZHeight)
        {

        }
        #endregion
        #region ZMinimum
        public int ZMinimum
        {
            get { return (int)GetValue(ZMinimumProperty); }
            set
            {
                SetValue(ZMinimumProperty, value);
            }
        }
        public static DependencyProperty ZMinimumProperty = DependencyProperty.Register("ZMinimum", typeof(int), typeof(UC_Temperature2), new PropertyMetadata(00, OnChangeZMinimum));
        private static void OnChangeZMinimum(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as UC_Temperature2;
            ct.UpdateZMinimum((int)e.NewValue);
        }
        public void UpdateZMinimum(int _ZMinimum)
        {
            Minimum = _ZMinimum;
            details_RightSide.Children.Clear();
            details_LeftSide.Children.Clear();
            Mamuti();
        }
        #endregion
        #region ZMaximum
        public int ZMaximum
        {
            get { return (int)GetValue(ZMaximumProperty); }
            set
            {
                SetValue(ZMaximumProperty, value);
            }
        }
        public static DependencyProperty ZMaximumProperty = DependencyProperty.Register("ZMaximum", typeof(int), typeof(UC_Temperature2), new PropertyMetadata(100, OnChangeZMaximum));
        private static void OnChangeZMaximum(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as UC_Temperature2;
            ct.UpdateZMaximum((int)e.NewValue);
        }
        public void UpdateZMaximum(int _ZMaximum)
        {
            Maximum = _ZMaximum;

            details_RightSide.Children.Clear();
            details_LeftSide.Children.Clear();
            Mamuti();
        }
        #endregion
        #region ZTickNumber
        public int ZTickNumber
        {
            get { return (int)GetValue(ZTickNumberProperty); }
            set
            {
                SetValue(ZTickNumberProperty, value);
            }
        }
        public static DependencyProperty ZTickNumberProperty = DependencyProperty.Register("ZTickNumber", typeof(int), typeof(UC_Temperature2), new PropertyMetadata(050, OnChangeZTickNumber));
        private static void OnChangeZTickNumber(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as UC_Temperature2;
            ct.UpdateZTickNumber((int)e.NewValue);
        }
        public void UpdateZTickNumber(int _ZTickNumber)
        {

        }
        #endregion
        #region ZSizeOfLine
        public int ZSizeOfLine
        {
            get { return (int)GetValue(ZSizeOfLineProperty); }
            set
            {
                SetValue(ZSizeOfLineProperty, value);
            }
        }
        public static DependencyProperty ZSizeOfLineProperty = DependencyProperty.Register("ZSizeOfLine", typeof(int), typeof(UC_Temperature2), new PropertyMetadata(050, OnChangeZSizeOfLine));
        private static void OnChangeZSizeOfLine(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ct = d as UC_Temperature2;
            ct.UpdateZSizeOfLine((int)e.NewValue);
        }
        public void UpdateZSizeOfLine(int _ZSizeOfLine)
        {

        }
        #endregion

        int Minimum = 00;
        int Maximum = 100;
        int TickNumber = 4;
        int SizeOfLine = 10;
        public UC_Temperature2()
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
            for (int i = 0; i <= TickNumber; i++)
            {
                #region Right Side
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
                details_RightSide.Children.Add(lineScale);
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
                    Margin = new Thickness(-18, tempSize-5,0,0 )
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
            Temperature2.Width = 100;
            Temperature2.Height = 500;

            sld.Height = 500;

            sld.Minimum = Minimum;
            sld.Maximum = Maximum;
        }
    }
}
