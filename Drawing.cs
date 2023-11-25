using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Task5._3

{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        public Drawing(Color bg)
        {
            _shapes = new List<Shape>();
            _background = bg;

        }
        public Drawing() : this(Color.White)
        {

        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(Background1);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }

        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }
        public List<Shape> Selectedshapes
        {
            get
            {
                List<Shape> _result = new List<Shape>();


                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                    {
                        _result.Add(s);
                    }
                }
                return _result;
            }
        }
        public Color Background1
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public void DeleteShape(Shape s)
        {
            _shapes.Remove(s);
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            //Shape s;

            writer.WriteColor(Background1);
            writer.WriteLine(ShapeCount);

            foreach(Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try { 
            
            int count;
            Shape s;
            string kind;
            Background1 = reader.ReadColor();
            count = reader.ReadInteger();

            _shapes.Clear();

                for (int i = 0; i < count; i += 1)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;

                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown Shape Kind: " + kind);
                    }

                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
            
        }
    }
}




