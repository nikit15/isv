using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeeeeee
{
    public partial class Form1 : Form
    {
        private float angle = 0;
        private int x = 220; 
        private int y = 60;
        private int width = 80;
        private int height = 40;
        private SolidBrush yellowBrush = new SolidBrush(Color.Yellow); 
        private Timer timer = new Timer(); 
        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer1_Tick;
            timer.Interval = 100; 
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            // Кисти и ручки
            Pen blackPen = new Pen(Color.Black, 2);
            Pen redPen = new Pen(Color.Red, 3);
            redPen.DashStyle = DashStyle.Dash;
            Pen bluePen = new Pen(Color.Blue, 1);
            bluePen.DashStyle = DashStyle.DashDot;
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

            // Прямоугольники
            g.DrawRectangle(blackPen, 120, 10, 80, 40);
            g.FillRectangle(greenBrush, 120, 60, 80, 40);

            // Линии
            g.DrawLine(blackPen, 10, 10, 100, 10);
            g.DrawLine(redPen, 10, 30, 100, 30);
            g.DrawLine(bluePen, 10, 50, 100, 50);




            // Эллипсы
            g.DrawEllipse(redPen, 220, 10, 80, 40);
          


            // Многоугольники
            Point[] points = {
            new Point(330, 20),
            new Point(360, 10),
            new Point(390, 40),
            new Point(360, 70)
        };
            g.DrawPolygon(bluePen, points);
            g.FillPolygon(greenBrush, points);

            Graphics ga = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            Brush brownBrush = new SolidBrush(Color.SaddleBrown);
            Brush redBrush = new SolidBrush(Color.Red);
            Brush greenBrush1 = new SolidBrush(Color.Green);
            Brush yellowBrush1 = new SolidBrush(Color.Yellow);
            Pen brownPen = new Pen(brownBrush, 2);

            int ba = 100;

            // Дом
            int houseX = 50;
            int houseY = 100 + ba;
            int houseWidth = 150;
            int houseHeight = 120;
            g.FillRectangle(brownBrush, houseX, houseY, houseWidth, houseHeight);

            // Крыша
            Point[] roofPoints = {
            new Point(houseX, houseY),
            new Point(houseX + houseWidth / 2, houseY - 50),
            new Point(houseX + houseWidth, houseY)
        };
            g.FillPolygon(redBrush, roofPoints);

            // Окно
            g.FillRectangle(Brushes.White, houseX + 30, houseY + 30, 30, 30);


            // Поле
            int fieldX = houseX + houseWidth + 20;
            int fieldY = houseY;
            int fieldWidth = 100;
            int fieldHeight = 100;
            ga.FillRectangle(greenBrush1, fieldX, fieldY, fieldWidth, fieldHeight);

            // Цветы
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int flowerX = fieldX + rnd.Next(fieldWidth);
                int flowerY = fieldY + rnd.Next(fieldHeight);
                ga.FillEllipse(yellowBrush1, flowerX, flowerY, 5, 5);
            }


            // Дуб 
            int treeX = fieldX + fieldWidth + 20;
            int treeY = houseY + houseHeight / 2;
            int treeTrunkHeight = 60;

            //Ствол
            ga.FillRectangle(brownBrush, treeX, treeY, 20, treeTrunkHeight);

            //Крона
            ga.FillEllipse(greenBrush1, treeX - 20, treeY - 40, 60, 60);
            ga.FillEllipse(greenBrush1, treeX - 30, treeY - 10, 80, 60);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Matrix matrix = new Matrix()) 
            {
                matrix.RotateAt(angle, new PointF(x + width / 2, y + height / 2)); 
                g.Transform = matrix; 
                g.FillEllipse(yellowBrush, x, y, width, height);
                g.ResetTransform();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 2; 
            Invalidate(); 
        }
 
    }
}
    



