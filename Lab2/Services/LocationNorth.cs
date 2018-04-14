using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;

namespace Lab2.Services
{
    public class LocationNorth : Toroid, ILocationService
    {
        public LocationNorth(int worldSize) : base(worldSize)
        {
        }


        public Point[] getFrontPoints(Point currentLocation)
        {
            Point FrontCenter = this.getPosition(currentLocation.X, currentLocation.Y - 2);

            List<Point> points = new List<Point>();

            for(int i = FrontCenter.X - 2; i <= FrontCenter.X + 2; i++)
            {
                Point p = getPosition(i, FrontCenter.Y);
                points.Add(p);
            }
            return points.ToArray();
        }

        public Point[] getLeftPoints(Point currentLocation)
        {
            Point LeftDownPoint = this.getPosition(currentLocation.X -2, currentLocation.Y);
            Point LeftUpPoint = this.getPosition(LeftDownPoint.X, LeftDownPoint.Y - 1);

            List<Point> points = new List<Point>();
            points.Add(LeftDownPoint);
            points.Add(LeftUpPoint);

            return points.ToArray();
        }

        public Point getPositionToMove(int currentX, int currentY)
        {
            return getPosition(currentX, currentY - 1);
        }

        public Point[] getProximityPoints(Point currentLocation)
        {
            Point ProximityFrontCenter = this.getPosition(currentLocation.X, currentLocation.Y - 1);

            List<Point> points = new List<Point>();

            for (int i = ProximityFrontCenter.X - 1; i <= ProximityFrontCenter.X + 1; i++)
            {
                Point p = getPosition(i, ProximityFrontCenter.Y);
                points.Add(p);
            }

            Point ProximityLeft = getPosition(currentLocation.X - 1, currentLocation.Y);
            Point ProximityRight = getPosition(currentLocation.X + 1, currentLocation.Y);

            points.Add(ProximityLeft);
            points.Add(ProximityRight);

            return points.ToArray();
        }

        public Point[] getRightPoints(Point currentLocation)
        {
            Point RightDownPoint = this.getPosition(currentLocation.X + 2, currentLocation.Y);
            Point RightUpPoint = this.getPosition(RightDownPoint.X, RightDownPoint.Y - 1);

            List<Point> points = new List<Point>();
            points.Add(RightDownPoint);
            points.Add(RightUpPoint);

            return points.ToArray();
        }
    }
}
