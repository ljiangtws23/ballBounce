using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace TestSkia
{
    public partial class MainPage : ContentPage
    {
        float xcoord1, ycoord1, radius1;
        float vx1, vy1;

        float xcoord2, ycoord2, radius2;
        float vx2, vy2;

        float xcoord3, ycoord3, radius3;
        float vx3, vy3;
        
        public MainPage()
        {
            InitializeComponent();

            xcoord1 = 200;
            ycoord1 = 200;
            radius1 = 50;
            vx1 = 15f; vy1 = 5f;

            xcoord2 = 300;
            ycoord2 = 100;
            radius2 = 45;
            vx2 = 9f; vy2 = -12f;
           

            xcoord3 = 400;
            ycoord3 = 150;
            radius3 = 34;
            vx3 = -7f; vy3 = 9f;

            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                canvasView.InvalidateSurface();
                return true;
            });
        }

        private void canvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColors.IndianRed);
            SKSize size = canvasView.CanvasSize;


            SKPaint ball1 = new SKPaint();
            ball1.Color = SKColors.MediumPurple;
            canvas.DrawCircle(xcoord1, ycoord1, radius1, ball1);
            xcoord1 += vx1;
            ycoord1 += vy1;

            SKPaint ball2 = new SKPaint();
            ball2.Color = SKColors.DodgerBlue;
            canvas.DrawCircle(xcoord2, ycoord2, radius2, ball2);
            xcoord2 += vx2;
            ycoord2 += vy2;

            SKPaint ball3 = new SKPaint();
            ball3.Color = SKColors.PapayaWhip;
            canvas.DrawCircle(xcoord3, ycoord3, radius3, ball3);
            xcoord3 += vx3;
            ycoord3 += vy3;

            if ((xcoord1 > size.Width - radius1) || (xcoord1 < radius1)) vx1 = -vx1;
            if ((ycoord1 > size.Height - radius1) || (ycoord1 < radius1)) vy1 = -vy1;

            if ((xcoord2 > size.Width - radius2) || (xcoord2 < radius2)) vx2 = -vx2;
            if ((ycoord2 > size.Height - radius2) || (ycoord2 < radius2)) vy2 = -vy2;

            if ((xcoord3 > size.Width - radius3) || (xcoord3 < radius3)) vx3 = -vx3;
            if ((ycoord3 > size.Height - radius3) || (ycoord3 < radius3)) vy3 = -vy3;

        }
    }
}
