using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;

namespace Lab2.Services
{
    public class LocationWest : Toroid, ILocationService
    {
        public LocationWest(int worldSize) : base(worldSize)
        {
        }

        public Point[] getFrontPoints(Point currentLocation)
        {
            Point FrontCenter = this.getPosition(currentLocation.X - 2, currentLocation.Y);

            List<Point> points = new List<Point>();

            for (int i = FrontCenter.Y - 2; i <= FrontCenter.Y + 2; i++)
            {
                Point p = getPosition(FrontCenter.X, i);
                points.Add(p);
            }
            return points.ToArray();
        }

        public Point[] getLeftPoints(Point currentLocation)
        {
            Point LeftDownPoint = this.getPosition(currentLocation.X, currentLocation.Y + 2);
            Point LeftUpPoint = this.getPosition(LeftDownPoint.X - 1, LeftDownPoint.Y);

            List<Point> points = new List<Point>();
            points.Add(LeftDownPoint);
            points.Add(LeftUpPoint);

            return points.ToArray();
        }

        public Point getPositionToMove(int currentX, int currentY)
        {
            return this.getPosition(currentX - 1, currentY);
        }

        public Point[] getProximityPoints(Point currentLocation)
        {
            Point ProximityFrontCenter = this.getPosition(currentLocation.X - 1, currentLocation.Y);

            List<Point> points = new List<Point>();

            for (int i = ProximityFrontCenter.Y - 1; i <= ProximityFrontCenter.Y + 1; i++)
            {
                Point p = getPosition(ProximityFrontCenter.X, i);
                points.Add(p);
            }

            Point ProximityLeft = getPosition(currentLocation.X, currentLocation.Y + 1);
            Point ProximityRight = getPosition(currentLocation.X, currentLocation.Y - 1);

            points.Add(ProximityLeft);
            points.Add(ProximityRight);

            return points.ToArray();
        }

        public Point[] getRightPoints(Point currentLocation)
        {
            Point RightDownPoint = this.getPosition(currentLocation.X, currentLocation.Y - 2);
            Point RightUpPoint = this.getPosition(RightDownPoint.X - 1, RightDownPoint.Y);

            List<Point> points = new List<Point>();
            points.Add(RightDownPoint);
            points.Add(RightUpPoint);

            return points.ToArray();
        }
    }
}
