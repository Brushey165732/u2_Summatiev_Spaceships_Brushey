//Jonathan Brushey
//Unit 2 Summative Assignment - Spaceships
//3/29/2018
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u2_Summative_Brushey
{
    class Spaceship
    {
        bool alive = true;

        int location_x = 100;
        int location_y = 100;

        double speed = 10;
        double speed_x;
        double speed_y;
        double angle = 0;

        Key input_up;
        Key input_down;
        Key input_left;
        Key input_right;

        
        SolidColorBrush Colour = new SolidColorBrush();

        public Spaceship(Key[] keyarray, int loc_x, int loc_y)
        {
            this.input_up = keyarray[0];
            this.input_down = keyarray[1];
            this.input_left = keyarray[2];
            this.input_right = keyarray[3];
            location_x = loc_x;
            location_y = loc_y;
        }

        public void turn()
        {
            if (Keyboard.IsKeyDown(input_left))
            {
                angle += 10;
            }

            if (Keyboard.IsKeyDown(input_right))
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

            Console.WriteLine(angle + " degrees");
        }

        public void fly()
        {
            double rad_angle = angle * (Math.PI / 180);
            double speed_x = Math.Sin(rad_angle) * speed;
            double speed_y = Math.Cos(rad_angle) * speed;
            Console.WriteLine("x velocity = " + speed_x + " y velocity = " + speed_y);
            

            if (Keyboard.IsKeyDown(input_up))
            {
                location_x += Convert.ToInt32(speed_x);
                location_y += Convert.ToInt32(speed_y);
                Console.WriteLine(location_x + ", " + location_y);
            }
          
            if (Keyboard.IsKeyDown(input_down))
            {
                location_x -= (Convert.ToInt32(speed_x) / 2);
                location_y -= (Convert.ToInt32(speed_y) / 2);
                Console.WriteLine(location_x + ", " + location_y);
            }

            if (location_x <= 0)
            {
                location_x = 800;
            }
            if (location_y <= 23)
            {
                location_y = 600;
            }
            if (location_x >= 801)
            {
                location_x = 0;
            }
            if (location_y >= 601)
            {
                location_y = 26;
            }

        }

        public void check_collision(Spaceship other_ship)
        {
            Rectangle rect = other_ship.display();
            double pos_x = Canvas.GetLeft(rect);
            double pos_y = Canvas.GetTop(rect);

            if (pos_x < location_x && (pos_x + rect.Width) > location_x && pos_y < location_y && location_y < (pos_y + rect.Height)
                 || location_x < pos_x && (location_x + rect.Width) > pos_x && location_y < pos_y && pos_y < (location_y + rect.Height))
            {
                MessageBox.Show("Collison Detected");
                alive = false;
            }

            if (alive == false)
            {
                rect.Visibility = Visibility.Hidden;
            }
        }


        public Rectangle display()
        {

            Rectangle rect = new Rectangle();
            rect.Height = 15;
            rect.Width = 15;
            rect.Fill = Brushes.SteelBlue;
            Canvas.SetLeft(rect, location_x);
            Canvas.SetTop(rect, location_y);

            RotateTransform rotateTransform = new RotateTransform(angle, rect.Width/2, rect.Height / 2);
            rect.RenderTransform = rotateTransform;

            return(rect);
        }
    }
}
