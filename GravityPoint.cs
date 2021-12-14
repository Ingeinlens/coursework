using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class GravityPoint : IImpactPoint
    {
        public int PointCounter = 0;

        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle, int x, int y)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r - particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                particle.Life = 0;
                PointCounter++;
            }
        }

        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );

            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

            // обязательно выносим текст и шрифт в переменные
            var text = "" + PointCounter;
            var font = new Font("Verdana", 10);

            // вызываем MeasureString, чтобы померить размеры текста
            var size = g.MeasureString(text, font);

            // рисуем подложку под текст
            g.FillRectangle(
                new SolidBrush(Color.Red),
                X - size.Width / 2, // так как я выравнивал текст по центру то подложка должна быть центрирована относительно X,Y
                Y - size.Height / 2,
                size.Width,
                size.Height
            );

            g.DrawString(
                text, // надпись
                font, // шрифт и его размер
                new SolidBrush(Color.White), // цвет шрифта
                X, // расположение в пространстве
                Y,
                stringFormat // передаем инфу о выравнивании
            );
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle, int x, int y)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            // разница в высоте источника частиц и отражателя
            float yY = Y - y;
            float xX = X - x;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r - 2 * particle.Radius <= Power / 2) // если частица оказалась внутри окружности
            {
                particle.SpeedX *= (float)0.9;
                particle.SpeedY *= (float)0.9;
                if (particle.X < X && particle.SpeedX > 0)
                {
                    particle.SpeedX *= -1;
                }
                if (particle.Y < Y && particle.SpeedY > 0)
                {
                    particle.SpeedY *= -1;
                }
                if (particle.Y >= Y && particle.SpeedY <= 0)
                {
                    particle.SpeedY *= -1;
                }
                if (particle.X >= X && particle.SpeedX <= 0)
                {
                    particle.SpeedX *= -1;
                }
            }
        }

        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(Color.Red, 3),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );

            g.FillEllipse(
                new SolidBrush(Color.Black),
                    X - Power / 2,
                    Y - Power / 2,
                    Power,
                    Power
            );
        }
    }
}