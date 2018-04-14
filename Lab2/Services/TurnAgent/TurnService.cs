using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.TurnAgent
{
    public class TurnService
    {
        public TurnService()
        {

        }

        public SightDirection getSightDirectionLeft(SightDirection direction)
        {
            var leftDirection = direction;
            switch (direction)
            {
                case SightDirection.North:
                    {
                        leftDirection = SightDirection.West;
                        break;
                    }
                case SightDirection.South:
                    {
                        leftDirection = SightDirection.East;
                        break;
                    }
                case SightDirection.East:
                    {
                        leftDirection = SightDirection.North;
                        break;
                    }
                case SightDirection.West:
                    {
                        leftDirection = SightDirection.South;
                        break;
                    }
                default:
                    break;
            }
            return leftDirection;

        }

        public SightDirection getSightDirectionRight(SightDirection direction)
        {
            var rightDirection = direction;
            switch (direction)
            {
                case SightDirection.North:
                    {
                        rightDirection = SightDirection.East;
                        break;
                    }
                case SightDirection.South:
                    {
                        rightDirection = SightDirection.West;
                        break;
                    }
                case SightDirection.East:
                    {
                        rightDirection = SightDirection.South;
                        break;
                    }
                case SightDirection.West:
                    {
                        rightDirection = SightDirection.North;
                        break;
                    }
                default:
                    break;
            }
            return rightDirection;

        }
    }
}
