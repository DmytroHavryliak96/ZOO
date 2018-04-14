using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;

namespace Lab2.Services
{
    public abstract class Toroid
    {
        public int WorldSize { get; set; }

        public Toroid(int worldSize)
        {
            WorldSize = worldSize;
        }

        public Point getPosition(int desiredX, int desiredY)
        {
            Point desiredP = new Point();

            if(desiredX >= 0)
                desiredP.X = desiredX % WorldSize;
            else
            {
                desiredP.X = WorldSize + (desiredX % WorldSize);
            }


            if (desiredY >= 0)
                desiredP.Y = desiredY % WorldSize;
            else
            {
                desiredP.Y = WorldSize + (desiredY % WorldSize);
            }

            return desiredP;

        }
        
    }
}
