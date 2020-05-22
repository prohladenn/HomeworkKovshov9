
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lab9_Parallelism
{
    public partial class AppForm : Form
    {
        public delegate void MyDelegate();
        const int DEFAULT_TIME = 25;
        const int DEFAULT_CNT = 5;
        public static int timeout = 25;
        public static int cnt = 5;
        public static int counter = 0;
        public static Point cursor;

        public AppForm()
        {
            InitializeComponent();
            CreateButtons();
        }

        /// <summary>
        /// Смена числа кнопок
        /// </summary>
        private void CntChanged(object o, EventArgs e)
        {
            if (Int32.TryParse(cntTB.Text, out cnt))
            {
                for (int i = 0; i < counter; i++)
                {
                    Controls.RemoveByKey("b");
                }
                if (cnt <= 0  ||  cnt > 50)
                {
                    cnt = DEFAULT_CNT;
                }
                CreateButtons();
            }
        }

        public void CreateButtons()
        {
            counter = cnt;
            for (int i = 0; i < cnt; i++)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MyDelegate(CreateButton));
                }
                else
                {
                    CreateButton();
                }
            }
        }
        /// <summary>
        /// Создание кнопки
        /// </summary>
        public void CreateButton()
        {
            RunningButton but = new RunningButton(Width - 110, Height - 150, this);
            Thread t = new Thread(new ThreadStart(but.FormMove));
            t.Start();
        }

        public void UpdateCursor()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MyDelegate(() => { cursor = PointToClient(Cursor.Position); }));
            }
        }

        private void SpeedChanged(object o, EventArgs e)
        {
            if (!Int32.TryParse(speedTB.Text, out timeout))
            {
                timeout = DEFAULT_TIME;
            }
            if (timeout > 50) timeout = 50;
            if (timeout < 1) timeout = 1;
        }
    }
}