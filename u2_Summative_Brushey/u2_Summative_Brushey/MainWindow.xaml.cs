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

namespace u2_Summative_Brushey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Key[] keys = { Key.Up, Key.Down, Key.Left, Key.Right };
        Spaceship spaceship = new Spaceship();

        public MainWindow()
        {
            InitializeComponent();

               


        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            spaceship.turn();
            spaceship.fly();
            Canvas.Children.RemoveAt(0);
            Canvas.Children.Add(spaceship.display());
            
        }
    }
}
