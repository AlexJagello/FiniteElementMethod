using ClassLibrary1;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Path = System.Windows.Shapes.Path;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _h;
        private int _g;
        FileStream fstream;

        public MainWindow()
        {
           
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("en-EN", false);
            InitParam();
            Force1Up.Visibility = Visibility.Collapsed;
            Force1Down.Visibility = Visibility.Collapsed;
            Force2Up.Visibility = Visibility.Collapsed;
            Force2Down.Visibility = Visibility.Collapsed;
            Force3Up.Visibility = Visibility.Collapsed;
            Force3Down.Visibility = Visibility.Collapsed;
            Force4Up.Visibility = Visibility.Collapsed;
            Force4Down.Visibility = Visibility.Collapsed;

            Width1.SelectedIndex = 0;
            Width2.SelectedIndex = 1;
            Width3.SelectedIndex = 2;

            AmountElements.SelectedIndex = 0;           
        }

        private void InitParam()
        {
            Drect1.SelectedIndex = 0;
            Drect2.SelectedIndex = 0;
            Drect3.SelectedIndex = 0;
            _h = 3;
            _g = 1;
            GridGeometry.RowDefinitions[1].Height = new GridLength(100);
            GridGeometry.RowDefinitions[2].Height = new GridLength(100);
            GridGeometry.RowDefinitions[3].Height = new GridLength(100); 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeHeight(1, Drect1);
            _g = 1;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ChangeHeight(2, Drect2);
            _g = 2;
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            ChangeHeight(3, Drect3);
            _g = 3;
        }

        private void ChangeHeight(int i, ComboBox Drect)
        {
            if (Drect.SelectedIndex == 0)
            {
                _h++;
                _h -= _g;

                if (_h > 5)
                {
                    InitParam();
                    return;
                }
                GridGeometry.RowDefinitions[i].Height = new GridLength(100);              
            }
            if (Drect.SelectedIndex == 1)
            {
                _h += 2;
                _h -= _g;
                if (_h > 5)
                {
                    InitParam();
                    return;
                }
                GridGeometry.RowDefinitions[i].Height = new GridLength(200);
            }
            if (Drect.SelectedIndex == 2)
            {
                _h += 3;
                _h -= _g;
                if (_h > 5)
                {
                    InitParam();
                    return;
                }
                GridGeometry.RowDefinitions[i].Height = new GridLength(300);
            }
        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            ChangeWidth(Rect1, Width1, 1);
        }
       
        private void Width2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeWidth(Rect2, Width2, 2);
        }

        private void Width3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeWidth(Rect3, Width3, 3);
        }

        private void ChangeWidth(Rectangle rect, ComboBox Comb , int i)
        {
            if (Comb.SelectedIndex == 0)
            {
                rect.Width = 50;
            }
            if (Comb.SelectedIndex == 1)
            {
                rect.Width = 100;
            }
            if (Comb.SelectedIndex == 2)
            {
                rect.Width = 150;
            }
            if (Comb.SelectedIndex == 3)
            {
                rect.Width = 200;
            }
            if (Comb.SelectedIndex == 4)
            {
                rect.Width = 250;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ConstrainUp.Visibility = Visibility.Visible;
            ConstrainDown.Visibility = Visibility.Collapsed;      
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            ConstrainUp.Visibility = Visibility.Collapsed;
            ConstrainDown.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            g1.IsEnabled = true;
            tb1.Text = "1000";
            Force1Up.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            g2.IsEnabled = true;
            tb2.Text = "1000";
            Force2Up.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            g3.IsEnabled = true;
            tb3.Text = "1000";
            Force3Up.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            g4.IsEnabled = true;
            tb4.Text = "1000";
            Force4Up.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unloaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            g1.IsEnabled = false;
            tb1.Text = "0";
            Force1Up.Visibility = Visibility.Collapsed;
            Force1Down.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            g2.IsEnabled = false;
            tb2.Text = "0";
            Force2Up.Visibility = Visibility.Collapsed;
            Force2Down.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            g3.IsEnabled = false;
            tb3.Text = "0";
            Force3Up.Visibility = Visibility.Collapsed;
            Force3Down.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Unchecked_3(object sender, RoutedEventArgs e)
        {
            g4.IsEnabled = false;
            tb4.Text = "0";
            Force4Up.Visibility = Visibility.Collapsed;
            Force4Down.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Force1Up.Visibility = Visibility.Visible;
            Force1Down.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Force1Up.Visibility = Visibility.Collapsed;
            Force1Down.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Force2Up.Visibility = Visibility.Visible;
            Force2Down.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            Force2Up.Visibility = Visibility.Collapsed;
            Force2Down.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            Force3Up.Visibility = Visibility.Visible;
            Force3Down.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_7(object sender, RoutedEventArgs e)
        {
            Force3Up.Visibility = Visibility.Collapsed;
            Force3Down.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_8(object sender, RoutedEventArgs e)
        {
            Force4Up.Visibility = Visibility.Visible;
            Force4Down.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_9(object sender, RoutedEventArgs e)
        {
            Force4Up.Visibility = Visibility.Collapsed;
            Force4Down.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Helper.Clear();
            try
            {
                string writePath = @"TextFileForCalculate.txt";
                fstream = new FileStream(writePath, FileMode.Create);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("File not open for write");
            }
          
            byte[] array = System.Text.Encoding.Default.GetBytes(MaterialE.Text +", " + MaterialV.Text + "\n");
            fstream.Write(array, 0, array.Length);
            array = System.Text.Encoding.Default.GetBytes(Drect1.SelectedIndex + ", " + Drect2.SelectedIndex + ", " + Drect3.SelectedIndex +"\n");
            fstream.Write(array, 0, array.Length);
            array = System.Text.Encoding.Default.GetBytes(Width1.SelectedIndex + ", " + Width2.SelectedIndex + ", " + Width3.SelectedIndex +"\n");
            fstream.Write(array, 0, array.Length);

            if(ConstrDown.IsChecked == true)
            {
                array = System.Text.Encoding.Default.GetBytes("1\n");              
            }else array = System.Text.Encoding.Default.GetBytes("0\n");
            fstream.Write(array, 0, array.Length);


            if (Down1.IsChecked == true)
            {
                array = System.Text.Encoding.Default.GetBytes("-" + tb1.Text + ", ");
            }else
                array = System.Text.Encoding.Default.GetBytes(tb1.Text + ", ");
            fstream.Write(array, 0, array.Length);

            if (Down2.IsChecked == true)
            {
                array = System.Text.Encoding.Default.GetBytes("-" + tb2.Text + ", ");
            }
            else
                array = System.Text.Encoding.Default.GetBytes(tb2.Text + ", ");
            fstream.Write(array, 0, array.Length);

            if (Down3.IsChecked == true)
            {
                array = System.Text.Encoding.Default.GetBytes("-" + tb3.Text + ", ");
            }
            else
                array = System.Text.Encoding.Default.GetBytes(tb3.Text + ", ");
            fstream.Write(array, 0, array.Length);

            if (Down4.IsChecked == true)
            {
                array = System.Text.Encoding.Default.GetBytes("-" + tb4.Text + ", "+ "\n");
            }
            else
                array = System.Text.Encoding.Default.GetBytes(tb4.Text + "\n");
            fstream.Write(array, 0, array.Length);

            array = System.Text.Encoding.Default.GetBytes(Convert.ToString((AmountElements.SelectedIndex + 1)*3) + "\n");
            fstream.Write(array, 0, array.Length);

            array = System.Text.Encoding.Default.GetBytes(Tba.Text + ", " + tbA.Text);
            fstream.Write(array, 0, array.Length);

            fstream.Close();

            Class1 f = new Class1();
          double [] def = f.CalculteDeform();
          double[] stress = f.CalculateStress();
            Helper.Text += f.StrData();

            grid1.Children.Clear();
            grid2.Children.Clear();
            TabItemDraw();
            DrawDeform(def);
            DrawStress(stress);
        }

        #region Drawing
        private void DrawDeform(double[] deform)
        {
            int[] height = { DrawLine(Drect1), DrawLine(Drect2), DrawLine(Drect3) };
            int[] he = new int[6];
            if (AmountElements.SelectedIndex != 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i % 2 != 0)
                        he[i] = 0;
                        he[i] = height[i / 2] / 2;
                }
                height = he;
            }
            
            int h = 40;
            double max = deform[0];
            for(int i = 0; i < deform.Length; i++)
            {
                if(Math.Abs(deform[i]) > max )
                {
                    max = Math.Abs(deform[i]);
                }
            }
            for (int i = 0; i < deform.Length; i++)
            {
                deform[i] = (deform[i] / max) * 100;             
            }

            for (int i = 0; i < deform.Length - 1; i++)
            {
                h += height[i];
                if (i == 0)
                {
                    StressLine(150 + deform[0], 150 + deform[1], 40, h, grid2);
                    EprLines(deform[0], deform[1], 40, h);
                }              
                else
                { StressLine(150 + deform[i], 150 + deform[i + 1], h - height[i], h, grid2);
                    EprLines(deform[i], deform[i + 1], h - height[i], h);
                }              
            }
        }

        private void DrawStress(double[] stress)
        {
            int[] height = { DrawLine(Drect1), DrawLine(Drect2), DrawLine(Drect3) };
            int[] he = new int[6];
            if (AmountElements.SelectedIndex != 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i % 2 != 0)
                        he[i] = 0;

                        he[i] = height[i / 2] / 2;
                }
                height = he;
            }
            

            int h = 40;
            double max = stress[0];
            for (int i = 0; i < stress.Length; i++)
            {
                if (Math.Abs(stress[i]) > max)
                {
                    max = Math.Abs(stress[i]);
                }
            }
            for (int i = 0; i < stress.Length; i++)
            {
                stress[i] = (stress[i] / max) * 50;
            }
            for (int i = 0; i < stress.Length; i++)
            {
                h += height[i];
                    StressLine(150 + stress[i], 150 + stress[i], h - height[i], h, grid1);
                     EprLines2(150 + stress[i], h - height[i], h);
            }
        }

        private void StressLine(double StartX, double EndX, double StartY, double EndY, Grid grid)
        {
            Line vertL3 = new Line();
            vertL3.X1 = StartX;
            vertL3.Y1 = StartY;
            vertL3.X2 = EndX;
            vertL3.Y2 = EndY;
            vertL3.Stroke = Brushes.Red;
            vertL3.StrokeThickness = 4;
            grid.Children.Add(vertL3);
        }

        private void EprLines2(double EndX, double StartY, double EndY)
        {
            for (int i = 0; i < (EndY - StartY) / 10; i++)
            {
                Line vertL3 = new Line();
                vertL3.X1 = 150;
                vertL3.Y1 = StartY + 10 * i;
                vertL3.X2 = EndX;
                vertL3.Y2 = StartY + 10 * i;
                vertL3.Stroke = Brushes.YellowGreen;
                vertL3.StrokeThickness = 2;
                grid1.Children.Add(vertL3);
            }
        }

        private void EprLines(double StartX, double EndX, double StartY, double EndY)
        {
            for (int i = 0; i < (EndY - StartY)/10; i++) 
               { Line vertL3 = new Line();
                vertL3.X1 = 150;
                vertL3.Y1 = StartY + 10*i;
                vertL3.X2 = 150 - (((EndX - StartX) * (StartY + 10*i) + (StartX*EndY - EndX*StartY)) / (StartY - EndY));
                vertL3.Y2 = StartY + 10 * i;
                vertL3.Stroke = Brushes.GreenYellow;
                vertL3.StrokeThickness = 1;
                grid2.Children.Add(vertL3); }
        }



        private void TabItemDraw()
        {
            NewLine(grid1);
            NewLine(grid2);         
        }

        private void NewLine(Grid grid1)
        {
            int height = 40;
            Line vertL = new Line();
            NewPoint(height);
            vertL.X1 = tab.Width / 2;
            vertL.Y1 = height;
            height += DrawLine(Drect1);
            Line vertL3 = new Line();
            vertL3.X1 = tab.Width / 2 - 50;
            vertL3.Y1 = height;
            vertL3.X2 = tab.Width / 2 + 50;
            vertL3.Y2 = height;
            grid1.Children.Add(vertL3);
            NewPoint(height);
            height += DrawLine(Drect2);
            NewPoint(height);
            height += DrawLine(Drect3);
            NewPoint(height);
            vertL.X2 = tab.Width / 2;
            vertL.Y2 = height;
            vertL.Stroke = new SolidColorBrush(Color.FromArgb(225, 67, 221, 207));
            vertL.StrokeThickness = 4;
            grid1.Children.Add(vertL);
        }


        private void NewPoint(int height)
        {
            Line vertL3 = new Line();
            vertL3.X1 = tab.Width / 2 - 8;
            vertL3.Y1 = height;
            vertL3.X2 = tab.Width / 2 + 8;
            vertL3.Y2 = height;
            vertL3.Stroke = new SolidColorBrush(Color.FromArgb(225, 67, 221, 207));
            vertL3.StrokeThickness = 4;
            grid1.Children.Add(vertL3);
        }

        private int DrawLine(ComboBox comb)
        {
            int num = 0;
            switch(comb.SelectedIndex)
            {
                case 0: num = 100;
                    break;
                case 1: num = 200;
                    break;
                case 2: num = 300;
                    break;
            }
            return num;
        }
        #endregion
    }
}
