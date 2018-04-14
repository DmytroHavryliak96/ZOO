using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;

namespace Lab2.Services
{
    public interface ILocationService
    {
        Point[] getLeftPoints(Point currentLocation);
        Point[] getRightPoints(Point currentLocation);
        Point[] getFrontPoints(Point currentLocation);
        Point[] getProximityPoints(Point currentLocation);
        Point getPositionToMove(int currentX, int currentY);
        Point getPosition(int desiredX, int desiredY);
        
    }
}
