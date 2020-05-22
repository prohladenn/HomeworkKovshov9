using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lab9_Parallelism
{
    class RunningButton
    {
        public delegate void MyDelegate(Point p);

        readonly Button button;
        readonly AppForm form;
        readonly Random rnd = new Random();
        private readonly int maxX;
        private readonly int maxY;
        private int cursX;
        private int cursY;

        /// <summary>
        /// конструктор
        /// </summary>
        public RunningButton(int maxX, int maxY, AppForm form)
        {
            button = new Button
            {
                BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)),
                Text = "push me",
                Name = "b",
                TabStop = false,
                Size = new Size(70, 70),
                Location = new Point(rnd.Next(20, form.Width - 90), rnd.Next(60, form.Height - 150))
            };
            form.Controls.Add(button);
            this.form = form;
            this.maxX = maxX;
            this.maxY = maxY;
            cursX = AppForm.cursor.X;
            cursY = AppForm.cursor.Y;
            button.Click += new EventHandler(ButtonClick);
        }

        /// <summary>
        /// Обработчик движения мышки
        /// </summary>
        public void FormMove()
        {
            while (true)
            {
                form.UpdateCursor();
                Point b = button.Location;
                int newX = b.X + (AppForm.cursor.X - cursX) + rnd.Next(-30, 30);
                int newY = b.Y + (AppForm.cursor.Y - cursY) + rnd.Next(-30, 30);
                if (newX > maxX)
                {
                    newX = maxX;
                }
                if (newY > maxY)
                {
                    newY = maxY;
                }
                if (newX < 20)
                {
                    newX = 20;
                }
                if (newY < 60)
                {
                    newY = 60;
                }
                int r1 = (newX - AppForm.cursor.X) * (newX - AppForm.cursor.X) + (newY - AppForm.cursor.Y) * (newY - AppForm.cursor.Y);
                int r2 = (b.X - AppForm.cursor.X) * (b.X - AppForm.cursor.X) + (b.Y - AppForm.cursor.Y) * (b.Y - AppForm.cursor.Y);
                if (r2 < 40000 && r1 > r2)
                {
                    if (form.InvokeRequired)
                    {
                        form.BeginInvoke(new MyDelegate((Point p) => { button.Location = p; }), new Point(newX, newY));
                    }
                    else
                    {
                        button.Location = new Point(newX, newY);
                    }
                }
                cursX = AppForm.cursor.X;
                cursY = AppForm.cursor.Y;
                Thread.Sleep(AppForm.timeout * 10);
            }
        }
        private void ButtonClick(object o, EventArgs e)
        {
            form.Controls.Remove((Button)o);
            Interlocked.Decrement(ref AppForm.counter);
            if (AppForm.counter == 0)
            {
                MessageBox.Show("Поздравляем! Вы смогли нажать на все кнопки!", "Победа");
                form.CreateButtons();
            }
        }
    }
}
