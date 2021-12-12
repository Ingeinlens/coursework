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

        private AntiGravityPoint point1; // добавил поле под первую точку
        private AntiGravityPoint point2; // добавил поле под вторую точку
        private AntiGravityPoint point3; // добавил поле под вторую точку

        private GravityPoint counter; // поле для счётчика

        public Form1()
        {
            InitializeComponent();

            //Добавляем привязку изображения
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // привязываем реакцию на скролл мыши
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 10,
                Y = picDisplay.Height / 8,
            };

            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

            // добавил антигравитон
            point1 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 + 200,
                Y = picDisplay.Height / 3,
            };

            // добавил второй антигравитон
            point2 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2 + 100,
            };

            // добавил движемый антигравитон
            point3 = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 - 70,
                Y = picDisplay.Height / 2 + 100,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            emitter.impactPoints.Add(point3);
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
            point3.Power = tbGraviton2.Value;
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                point2.Power += 3;
            }
            else
            {
                point2.Power -= 3;
            }
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;

            float lx;
            float rx;

            float ty;
            float by;

            // область счётчика
            if (counter != null)
            {
                lx = counter.X - counter.Power / 2;
                rx = counter.X + counter.Power / 2;

                ty = counter.Y - counter.Power / 2;
                by = counter.Y + counter.Power / 2;

                if (e.Button == MouseButtons.Right && e.X > lx && e.X < rx && e.Y > ty && e.Y < by)
                {
                    emitter.impactPoints.Remove(counter);
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                counter = new GravityPoint
                {
                    X = e.X,
                    Y = e.Y
                };

                counter.Power = point2.Power;

                emitter.impactPoints.Add(counter);
            }
        }
    }
}