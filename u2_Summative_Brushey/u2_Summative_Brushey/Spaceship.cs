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
    class Spaceship
    {
        bool alive = true;

        int location_x = 0;
        int location_y = 0;

        double speed = 10;
        double speed_x;
        double speed_y;
        double angle = 0;

        public Spaceship()
        {

        }

        public void turn()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                angle += 10;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                angle -= 10;
            }

            if (angle == 360)
            {
                angle = 0;
            }

            if (angle < 0)
            {
                angle += 360;
            }

            Console.WriteLine(angle);
        }

        public void fly()
        {
            double rad_angle = angle * (Math.PI / 180);
            double speed_x = Math.Sin(angle) * speed;
            double speed_y = Math.Cos(angle) * speed;
            if (Keyboard.IsKeyDown(Key.Up))
            {
                location_x = Convert.ToInt32(speed_x);
                location_y += Convert.ToInt32(speed_y);
                if (location_x < 0)
                {
                    location_x = 0;
                }
                if (location_y < 0)
                {
                    location_y = 0;
                }
            }
        }

        public void check_collision()
        {

        }

        public Rectangle display()
        {
            Rectangle extramartianaerospacecraft = new Rectangle();
            extramartianaerospacecraft.Height = 5;
            extramartianaerospacecraft.Width = 5;
            extramartianaerospacecraft.Fill = Brushes.Fuchsia;
            Canvas.SetLeft(extramartianaerospacecraft, location_x);
            Canvas.SetRight(extramartianaerospacecraft, location_y);
            return(extramartianaerospacecraft);
                
            
        }

    }
}
