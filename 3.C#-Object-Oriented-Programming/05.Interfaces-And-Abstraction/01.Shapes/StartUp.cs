using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable circle = new Circle(6);

            List<IDrawable> drawableObjects = new List<IDrawable>();

            drawableObjects.Add(new Rectangle(7, 2));

            drawableObjects.Add(new Circle(3));

            drawableObjects.Add(new Rectangle(9, 4));

            drawableObjects.Add(new Circle(6));

            drawableObjects.Add(new Rectangle(2, 7));

            drawableObjects.Add(new Circle(9));

            foreach (var item in drawableObjects)
            {
                item.Draw();
            }
        }
    }
}