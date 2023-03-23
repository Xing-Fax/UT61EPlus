using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace UT61E_
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleFrame_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.DoWork += new DoWorkEventHandler(Backstage);
                bw.RunWorkerAsync();
            }
        }

        void Backstage(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                string Str = Connect.GetData("Original");

                string[] Data = Str.Split(' ');

                string Plar = Connect.Direction(Data[3]);

                string Value = Connect.Result(Data);


                new Thread(() =>//异步调用
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        new Action(() =>
                        {
                            if (Plar == "-")
                                Minus.Visibility = Visibility.Collapsed;
                            else
                                Minus.Visibility = Visibility.Visible;
                            ValueS.Text = Value;
                        }));
                }).Start();
                Thread.Sleep(0);
            }
        }
    }
}
