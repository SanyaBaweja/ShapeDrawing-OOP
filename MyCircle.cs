using System;
using SplashKitSDK;
namespace Task5._3
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle():this(Color.Blue, 0, 0, 50)
        {

        }
        public MyCircle(Color clor,int x, int Y, int radius):base(clor)
        {
            _color = clor; 
            _radius = radius;
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }

        }
        public override void Draw()
        {
            if (Selected)
                Outline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void Outline()
        {
            
            SplashKit.FillCircle(Color.Black, X , Y , Radius+2);


        }
        public override bool IsAt(Point2D pt)
        {

            double point1 = (pt.X - X) * (pt.X - X);

            double point2 = (pt.Y - Y) * (pt.Y - Y);

            if(Math.Sqrt(point1+point2)<_radius)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");

            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}

