using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KeyboardSimulator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CapsLockState();
        }
        int n = 0, p = 0, k = 0; //колво введенных с клавиатуры символов/не верных/верных
        string str = "";//сгенерированная строка
        private DispatcherTimer timer = null;
        private int x = 0;//секунды

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            difficulteCount.Text = (slider.Value).ToString("0");
            if (slider.Value == 0) textbox.MaxLength = 1;
        }
        private void CapsLockState()//состояние клавиши CapsLock
        {
            if (Console.CapsLock == true) { capsLock.Foreground = Brushes.Red; Klava(3); }
            else { capsLock.Foreground = Brushes.Black; Klava(1); }
        }
        private void timerStart()
        {
            timeBox.Text = "Time: " + 0.ToString();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            x++;
            timeBox.Text = "Time: " + x.ToString();
            SpeedChar();
            if (x == 60) { 
                GameOver();
                start.IsEnabled = true;
                stop.IsEnabled = false;
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                Klava(3);
                Klava(4);//при нажатой CapsLock не переопределяются
            }
            if (Keyboard.IsKeyDown(Key.CapsLock))
            {
                CapsLockState();
            }
            switch (e.Key)
            {
                case Key.OemTilde: r0_c0.Foreground = Brushes.LightPink; break;
                case Key.D1: r0_c1.Foreground = Brushes.LightPink; break;
                case Key.D2: r0_c2.Foreground = Brushes.LightPink; break;
                case Key.D3: r0_c3.Foreground = Brushes.LightPink; break;
                case Key.D4: r0_c4.Foreground = Brushes.LightPink; break;
                case Key.D5: r0_c5.Foreground = Brushes.LightPink; break;
                case Key.D6: r0_c6.Foreground = Brushes.LightPink; break;
                case Key.D7: r0_c7.Foreground = Brushes.LightPink; break;
                case Key.D8: r0_c8.Foreground = Brushes.LightPink; break;
                case Key.D9: r0_c9.Foreground = Brushes.LightPink; break;
                case Key.D0: r0_c10.Foreground = Brushes.LightPink; break;
                case Key.Subtract: r0_c11.Foreground = Brushes.LightPink; break;
                case Key.Add: r0_c12.Foreground = Brushes.LightPink; break;

                case Key.Q: r1_c1.Foreground = Brushes.Red; break;
                case Key.W: r1_c2.Foreground = Brushes.Red; break;
                case Key.E: r1_c3.Foreground = Brushes.Red; break;
                case Key.R: r1_c4.Foreground = Brushes.Red; break;
                case Key.T: r1_c5.Foreground = Brushes.Red; break;
                case Key.Y: r1_c6.Foreground = Brushes.Red; break;
                case Key.U: r1_c7.Foreground = Brushes.Red; break;
                case Key.I: r1_c8.Foreground = Brushes.Red; break;
                case Key.O: r1_c9.Foreground = Brushes.Red; break;
                case Key.P: r1_c10.Foreground = Brushes.Red; break;

                case Key.A: r2_c1.Foreground = Brushes.Red; break;
                case Key.S: r2_c2.Foreground = Brushes.Red; break;
                case Key.D: r2_c3.Foreground = Brushes.Red; break;
                case Key.F: r2_c4.Foreground = Brushes.Red; break;
                case Key.G: r2_c5.Foreground = Brushes.Red; break;
                case Key.H: r2_c6.Foreground = Brushes.Red; break;
                case Key.J: r2_c7.Foreground = Brushes.Red; break;
                case Key.K: r2_c8.Foreground = Brushes.Red; break;
                case Key.L: r2_c9.Foreground = Brushes.Red; break;

                case Key.Z: r3_c1.Foreground = Brushes.Red; break;
                case Key.X: r3_c2.Foreground = Brushes.Red; break;
                case Key.C: r3_c3.Foreground = Brushes.Red; break;
                case Key.V: r3_c4.Foreground = Brushes.Red; break;
                case Key.B: r3_c5.Foreground = Brushes.Red; break;
                case Key.N: r3_c6.Foreground = Brushes.Red; break;
                case Key.M: r3_c7.Foreground = Brushes.Red; break;

                case Key.Back: backspase.Foreground = Brushes.Green; break;
                case Key.Tab: tab.Foreground = Brushes.Green; break;
                case Key.Enter: enter.Foreground = Brushes.Green; break;
                case Key.LeftShift: shiftLeft.Foreground = Brushes.Green; break;
                case Key.RightShift: shiftRight.Foreground = Brushes.Green; break;
                case Key.LeftCtrl: ctrlLeft.Foreground = Brushes.Green; break;
                case Key.LWin: winLeft.Foreground = Brushes.Green; break;
                case Key.LeftAlt: altLeft.Foreground = Brushes.Green; break;
                case Key.Space: spase.Foreground = Brushes.Green; break;
                case Key.RightAlt: altRight.Foreground = Brushes.Green; break;
                case Key.RWin: winRight.Foreground = Brushes.Green; break;
                case Key.RightCtrl: ctrlRight.Foreground = Brushes.Green; break;
            }
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyUp(Key.LeftShift) || Keyboard.IsKeyUp(Key.RightShift))
            {
                Klava(1);
                Klava(2);//при нажатой CapsLock не переопределяются
            }
            if (Keyboard.IsKeyUp(Key.CapsLock))
            {
                CapsLockState();
            }
            switch (e.Key)
            {
                case Key.OemTilde: r0_c0.Foreground = Brushes.Black; break;
                case Key.D1: r0_c1.Foreground = Brushes.Black; break;
                case Key.D2: r0_c2.Foreground = Brushes.Black; break;
                case Key.D3: r0_c3.Foreground = Brushes.Black; break;
                case Key.D4: r0_c4.Foreground = Brushes.Black; break;
                case Key.D5: r0_c5.Foreground = Brushes.Black; break;
                case Key.D6: r0_c6.Foreground = Brushes.Black; break;
                case Key.D7: r0_c7.Foreground = Brushes.Black; break;
                case Key.D8: r0_c8.Foreground = Brushes.Black; break;
                case Key.D9: r0_c9.Foreground = Brushes.Black; break;
                case Key.D0: r0_c10.Foreground = Brushes.Black; break;
                case Key.Subtract: r0_c10.Foreground = Brushes.Black; break;
                case Key.Add: r0_c10.Foreground = Brushes.Black; break;

                case Key.Q: r1_c1.Foreground = Brushes.Black; break;
                case Key.W: r1_c2.Foreground = Brushes.Black; break;
                case Key.E: r1_c3.Foreground = Brushes.Black; break;
                case Key.R: r1_c4.Foreground = Brushes.Black; break;
                case Key.T: r1_c5.Foreground = Brushes.Black; break;
                case Key.Y: r1_c6.Foreground = Brushes.Black; break;
                case Key.U: r1_c7.Foreground = Brushes.Black; break;
                case Key.I: r1_c8.Foreground = Brushes.Black; break;
                case Key.O: r1_c9.Foreground = Brushes.Black; break;
                case Key.P: r1_c10.Foreground = Brushes.Black; break;

                case Key.A: r2_c1.Foreground = Brushes.Black; break;
                case Key.S: r2_c2.Foreground = Brushes.Black; break;
                case Key.D: r2_c3.Foreground = Brushes.Black; break;
                case Key.F: r2_c4.Foreground = Brushes.Black; break;
                case Key.G: r2_c5.Foreground = Brushes.Black; break;
                case Key.H: r2_c6.Foreground = Brushes.Black; break;
                case Key.J: r2_c7.Foreground = Brushes.Black; break;
                case Key.K: r2_c8.Foreground = Brushes.Black; break;
                case Key.L: r2_c9.Foreground = Brushes.Black; break;

                case Key.Z: r3_c1.Foreground = Brushes.Black; break;
                case Key.X: r3_c2.Foreground = Brushes.Black; break;
                case Key.C: r3_c3.Foreground = Brushes.Black; break;
                case Key.V: r3_c4.Foreground = Brushes.Black; break;
                case Key.B: r3_c5.Foreground = Brushes.Black; break;
                case Key.N: r3_c6.Foreground = Brushes.Black; break;
                case Key.M: r3_c7.Foreground = Brushes.Black; break;

                case Key.Back: backspase.Foreground = Brushes.Black; break;
                case Key.Tab: tab.Foreground = Brushes.Black; break;
                case Key.Enter: enter.Foreground = Brushes.Black; break;
                case Key.LeftShift: shiftLeft.Foreground = Brushes.Black; break;
                case Key.RightShift: shiftRight.Foreground = Brushes.Black; break;
                case Key.LeftCtrl: ctrlLeft.Foreground = Brushes.Black; break;
                case Key.LWin: winLeft.Foreground = Brushes.Black; break;
                case Key.LeftAlt: altLeft.Foreground = Brushes.Black; break;
                case Key.Space: spase.Foreground = Brushes.Black; break;
                case Key.RightAlt: altRight.Foreground = Brushes.Black; break;
                case Key.RWin: winRight.Foreground = Brushes.Black; break;
                case Key.RightCtrl: ctrlRight.Foreground = Brushes.Black; break;
            }
        }
        //переопределение названий клавиш
        private void Klava(int r)
        {
            if (r == 1)
            {
                r0_c0.Content = "`";
                r0_c1.Content = "1";
                r0_c2.Content = "2";
                r0_c3.Content = "3";
                r0_c4.Content = "4";
                r0_c5.Content = "5";
                r0_c6.Content = "6";
                r0_c7.Content = "7";
                r0_c8.Content = "8";
                r0_c9.Content = "9";
                r0_c10.Content = "0";
                r0_c11.Content = "-";
                r0_c12.Content = "=";

                r1_c1.Content = "q";
                r1_c2.Content = "w";
                r1_c3.Content = "e";
                r1_c4.Content = "r";
                r1_c5.Content = "t";
                r1_c6.Content = "y";
                r1_c7.Content = "u";
                r1_c8.Content = "i";
                r1_c9.Content = "o";
                r1_c10.Content = "p";

                r2_c1.Content = "a";
                r2_c2.Content = "s";
                r2_c3.Content = "d";
                r2_c4.Content = "f";
                r2_c5.Content = "g";
                r2_c6.Content = "h";
                r2_c7.Content = "j";
                r2_c8.Content = "k";
                r2_c9.Content = "l";

                r3_c1.Content = "z";
                r3_c2.Content = "x";
                r3_c3.Content = "c";
                r3_c4.Content = "v";
                r3_c5.Content = "b";
                r3_c6.Content = "n";
                r3_c7.Content = "m";
            }
            else if (r == 2)
            {
                r1_c11.Content = "[";
                r1_c12.Content = "]";
                r1_c13.Content = "\\";

                r2_c10.Content = ";";
                r2_c11.Content = "'";

                r3_c8.Content = ",";
                r3_c9.Content = ".";
                r3_c10.Content = "/";
            }
            else if (r == 3)
            {
                r0_c0.Content = "~";
                r0_c1.Content = "!";
                r0_c2.Content = "@";
                r0_c3.Content = "#";
                r0_c4.Content = "$";
                r0_c5.Content = "%";
                r0_c6.Content = "^";
                r0_c7.Content = "&";
                r0_c8.Content = "*";
                r0_c9.Content = "(";
                r0_c10.Content = ")";
                r0_c11.Content = "_";
                r0_c12.Content = "+";

                r1_c1.Content = "Q";
                r1_c2.Content = "W";
                r1_c3.Content = "E";
                r1_c4.Content = "R";
                r1_c5.Content = "T";
                r1_c6.Content = "Y";
                r1_c7.Content = "U";
                r1_c8.Content = "I";
                r1_c9.Content = "O";
                r1_c10.Content = "P";

                r2_c1.Content = "A";
                r2_c2.Content = "S";
                r2_c3.Content = "D";
                r2_c4.Content = "F";
                r2_c5.Content = "G";
                r2_c6.Content = "H";
                r2_c7.Content = "J";
                r2_c8.Content = "K";
                r2_c9.Content = "L";

                r3_c1.Content = "Z";
                r3_c2.Content = "X";
                r3_c3.Content = "C";
                r3_c4.Content = "V";
                r3_c5.Content = "B";
                r3_c6.Content = "N";
                r3_c7.Content = "M";
            }
            else if (r == 4)
            {
                r1_c11.Content = "{";
                r1_c12.Content = "}";
                r1_c13.Content = "|";

                r2_c10.Content = ":";
                r2_c11.Content = "\"";

                r3_c8.Content = "<";
                r3_c9.Content = ">";
                r3_c10.Content = "?";
            }
            else MessageBox.Show("UPS");
        }
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            x = n = p = k = 0;
            textbox2.Clear();
            stop.IsEnabled = true;
            start.IsEnabled = false;
            if(checkBox.IsChecked == false) { str = LoremNET.Lorem.Words(Convert.ToInt32(slider.Value)); }
            else { str = LoremNET.Lorem.Words(Convert.ToInt32(slider.Value), true, true); }
            textbox.Text = str;
            timerStart();
            textbox2.IsEnabled = true;
            textbox2.Focus();

        }
        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            start.IsEnabled = true;
            stop.IsEnabled = false;
            textbox2.IsEnabled = false;
            GameOver();
        }
        private void SpeedChar()
        {
            count.Text = (k * 60 / x).ToString();
        }

        private void textbox2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = true;
            }
            
        }

        private void textblock2_TextChanged(object sender, TextChangedEventArgs e)
        {
            n = textbox2.GetLineLength(0);//длина введенной строки или индекс последнего символа
            if (n == 0)
                return;
            if (textbox2.Text[n - 1].ToString() == textbox.Text[n - 1].ToString())
                ++k;
            else if (textbox2.Text[n - 1].ToString() != textbox.Text[n - 1].ToString())
            {
                try
                {
                    ++p;
                    if (textbox2.Text.Length != 1)
                        textbox2.Text = textbox2.Text.Substring(0, textbox2.Text.Length - 1);
                    else
                        textbox2.Clear();
                    if(textbox2.Text.Length!=0)
                        textbox2.SelectionStart = textbox2.Text.Length;
                    System.Media.SystemSounds.Beep.Play();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }


            //статистика по символам
            failsCount.Text = n.ToString() + "/" + k.ToString() + "/" + p.ToString();
            //если введены символы до конца строки
            if(textbox2.GetLineLength(0) == textbox.GetLineLength(0))
                GameOver();
        }
        private void GameOver()
        {
            timer.Stop();
            MessageBox.Show($"Game over!!!\nЗадание выполнено за {timeBox.Text} с.\nСимволов:{n}\nВерных:{k} \nНе верных:{p} \nСкорость набора:{count.Text}");
        }
    }
}