using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private double angle;
        private Random random;
        private Pen pen;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ініціалізація таймера
            timer = new Timer();
            timer.Interval = 50; // Інтервал таймера у мілісекундах
            timer.Tick += Timer_Tick;

            // Ініціалізація випадкового генератора
            random = new Random();

            // Ініціалізація пера для малювання
            pen = new Pen(Color.Black, 2);

            // Початковий кут
            angle = 0;

            // Запуск таймера
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Збільшення кута для обертання
            angle += 0.1;

            // Випадкова зміна кольору та ширини пера
            pen.Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            pen.Width = random.Next(1, 10);

            // Обчислення нової позиції для Panel
            int radius = 100; // Радіус обертання
            int centerX = button1.Left + button1.Width / 2;
            int centerY = button1.Top + button1.Height / 2;

            int newX = centerX + (int)(radius * Math.Cos(angle)) - panel1.Width / 2;
            int newY = centerY + (int)(radius * Math.Sin(angle)) - panel1.Height / 2;

            panel1.Left = newX;
            panel1.Top = newY;

            // Виклик перерисування форми
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Малювання кола обертання
            int radius = 100;
            int centerX = button1.Left + button1.Width / 2;
            int centerY = button1.Top + button1.Height / 2;
            e.Graphics.DrawEllipse(pen, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Додайте тут код для обробки події Click для label1
        }
    }
}
