using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        private List<Emitter> emitters = new List<Emitter>();
        private Emitter emitter; // добавим поле для эмиттера

        private GravityPoint point1; // добавил поле под первую точку
        private GravityPoint point2; // добавил поле под вторую точку

        public Form1()
        {
            InitializeComponent();

            //Добавляем привязку изображения
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

            // добавил гравитон
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };

            // добавил второй гравитон
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // обновляем состояние системы
            emitter.UpdateState();

            //Используя класс графики будет отрисовывать частицы
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // очищаем поле
                emitter.Render(g);
            }

            //Обновляем картинку
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;

            // а тут передаем положение мыши, в положение гравитона
            point2.X = e.X;
            point2.Y = e.Y;
        }

        // ползунок для настройки поворота эмитера
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка
            lblDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }
    }
}