using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;
using Lab2.Properties;
using System.Configuration;
using Lab2.Services;

namespace Lab2.Services
{
    public class LocationServiceBuilder
    {
        private ILocationService getLocationServiceSight(SightDirection Direction)
        {
            int worldSize = Convert.ToInt32(Settings.Default.WorldSize);
            ILocationService service;
            switch (Direction)
            {
                case SightDirection.North:
                    {
                        service = new LocationNorth(worldSize);
                        break;
                    }
                case SightDirection.South:
                    {
                        service = new LocationSouth(worldSize);
                        break;
                    }
                case SightDirection.East:
                    {
                        service = new LocationEast(worldSize);
                        break;
                    }
                case SightDirection.West:
                    {
                        service = new LocationWest(worldSize);
                        break;
                    }
                default:
                    {
                        service = new LocationNorth(worldSize);
                        break;
                    }
            }
            return service;
        }
        public LocationService getLocationService(Point currentPoint, SightDirection direct)
        {
            ILocationService sightService = getLocationServiceSight(direct);
            LocationService service = new LocationService(currentPoint, direct, sightService);
            return service;
        }
        
    }

    public class LocationService
    {
        public Point BasePoint { get; set; }
        private SightDirection Direction;
        private ILocationService locationService;

        public LocationService(Point p, SightDirection direct, ILocationService locationService)
        {
            BasePoint = p;
            Direction = direct;
            this.locationService = locationService;
        }

        public Point[] getFrontPoints()
        {
            return locationService.getFrontPoints(BasePoint);
        }

        public Point[] getLeftPoints()
        {
            return locationService.getLeftPoints(BasePoint);
        }

        public Point[] getRightPoints()
        {
            return locationService.getRightPoints(BasePoint);
        }

        public Point[] getProximityPoints()
        {
            return locationService.getProximityPoints(BasePoint);
        }

        public Point getPositionToMove()
        {
            return locationService.getPositionToMove(BasePoint.X, BasePoint.Y);

        }

       /* public List<Point> getProximityOfCurrentLocation()
        {
            List<Point> points = new List<Point>();
            for (int x = BasePoint.X - 1; x <= BasePoint.X + 1; x++)
            {
                points.Add(locationService.getPosition(x, BasePoint.Y - 1));
                points.Add(locationService.getPosition(x, BasePoint.Y + 1));
            }
            points.Add(locationService.getPosition(BasePoint.X - 1, BasePoint.Y));
            points.Add(locationService.getPosition(BasePoint.X + 1, BasePoint.Y));
            return points;
        }*/
    }

   
}
