//Jonathan Brushey
//Unit 2 Summative Assignment - Spaceships
//
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
using System.Windows.Threading;

namespace u2_Summative_Brushey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Define the key configurations (forward, back, turn left, turn right)
        static Key[] keys_1 = { Key.Up, Key.Down, Key.Left, Key.Right };
        static Key[] keys_2 = { Key.W, Key.S, Key.A, Key.D };
        static Key[] keys_3 = { Key.I, Key.K, Key.J, Key.L };
        static Key[] keys_4 = { Key.NumPad8, Key.NumPad2, Key.NumPad4, Key.NumPad6 };

        Spaceship spaceship = new Spaceship(keys_1, 100, 200);
        Spaceship spaceship_2 = new Spaceship(keys_2, 300, 400);
        Spaceship spaceship_3 = new Spaceship(keys_3, 500, 200);
        Spaceship spaceship_4 = new Spaceship(keys_4, 700, 400);

        DispatcherTimer Timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            Timer.Interval = new TimeSpan(170000);
            Timer.Tick += Timer_Tick;
            Timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            spaceship.turn();
            spaceship_2.turn();
            spaceship_3.turn();
            spaceship_4.turn();

            spaceship.fly();
            spaceship_2.fly();
            spaceship_3.fly();
            spaceship_4.fly();

            spaceship.check_collision(spaceship_2);
            spaceship.check_collision(spaceship_3);
            spaceship.check_collision(spaceship_4);
            spaceship_2.check_collision(spaceship);
            spaceship_2.check_collision(spaceship_3);
            spaceship_2.check_collision(spaceship_4);
            spaceship_3.check_collision(spaceship);
            spaceship_3.check_collision(spaceship_2);
            spaceship_3.check_collision(spaceship_4);
            spaceship_4.check_collision(spaceship);
            spaceship_4.check_collision(spaceship_2);
            spaceship_4.check_collision(spaceship_3);

            for (int i = Canvas.Children.Count -1; i >= 1; i--)
            {
                Canvas.Children.RemoveAt(i);
            }

            Canvas.Children.Add(spaceship.display());
            Canvas.Children.Add(spaceship_2.display());
            Canvas.Children.Add(spaceship_3.display());
            Canvas.Children.Add(spaceship_4.display());
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {           
        } 


    }
}
