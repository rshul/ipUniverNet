﻿using SRR.UIP.HW8.LandCalculator.BLL.Services;
using SRR.UIP.HW8.LandCalculator.Shared;
using SRR.UIP.HW8.LandCalculator.Shared.Interfaces;
using SRR.UIP.HW8.LandCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW8.LandCalculator.UIConsole
{
    public class UIConsoleInteractor
    {
        private ILandCalculator LandAreaCalculator { get; set; }
        private IPointsValidator PointsValidator { get; set; }

        public UIConsoleInteractor(ILandCalculator landAreaCalculator, IPointsValidator pointsValidator)
        {
            this.LandAreaCalculator = landAreaCalculator;
            this.PointsValidator = pointsValidator;

        }

        internal void Start()
        {
            List<Point> points = GetPoints();
            PointsValidationResult validationResult = PointsValidator.GetValidationResult(points);
            Console.WriteLine($"Result validation: {validationResult.Message}; ");
            if (validationResult.ArePointsValid)
            {
                long landArea = LandAreaCalculator.CalculateLandArea(points);
                Console.WriteLine($"Result = {landArea}");
            }
        }

        private List<Point> GetPointsTest(int choice = -1)
        {
            List<Point> setOfPoints;

            switch (choice)
            {
                case 0:
                    setOfPoints = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1),
                        new Point(2,2),
                        new Point(3,3),
                        new Point(4,4),
                        new Point(0,0)
                    };
                    break;
                case 1:
                    setOfPoints = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1)
                    };
                    break;
                case 2://crossed
                    setOfPoints = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1),
                        new Point(2,4),
                        new Point(3,1),
                        new Point(0,4),
                        new Point(0,0)
                    };
                    break;
                case 3://same point
                    setOfPoints = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1),
                        new Point(1,1),
                        new Point(3,1),
                        new Point(4,0),
                        new Point(0,0)
                    };
                    break;
                default:
                    setOfPoints = new List<Point>
                    {
                        new Point(0,0),
                        new Point(0,1),
                        new Point(1,1),
                        new Point(1,0),
                        new Point(0,0)
                    };
                    break;
            }
            return setOfPoints;
        }

        private List<Point> GetPoints()
        {
            Point tempPoint;
            List<Point> tempListOfPoints = new List<Point>();
            int pointsCounter = 0;
            int pointsNumber;
            bool isParsedOK;
            do
            {
                Console.Write($"How many points?");
                string enteredStringNumber = Console.ReadLine();
                isParsedOK = int.TryParse(enteredStringNumber, out pointsNumber);
                if (!isParsedOK)
                {
                    StaticInjector.Logger.Error($"Not valid value of {pointsNumber}");
                }
            } while (!isParsedOK);

            while (pointsCounter < pointsNumber)
            {
                tempPoint = GetPoint(pointsCounter);
                if (pointsCounter != pointsNumber - 1)
                {
                    bool isInputValid = IsPointValid(tempListOfPoints, tempPoint);
                    if (!isInputValid)
                    {
                        continue;
                    }

                }
                tempListOfPoints.Add(tempPoint);
                StaticInjector.Logger.Info($"Point {pointsCounter} with value ({tempPoint.X},{tempPoint.Y}) added");
                pointsCounter++;

            }

            return tempListOfPoints;
        }

        private bool IsPointValid(List<Point> pointsCollection, Point takenPoint)
        {
            if (pointsCollection.Count == 0)
            {
                return true;
            }
            else
            {
                return !pointsCollection.Contains(takenPoint); 
            }

        }

        private Point GetPoint(int pointNumber)
        {
            int xCoord;
            int yCoord;

            Console.WriteLine($"Enter coordinates of {pointNumber} point");
            xCoord = GetCoordinateValueFromConsole("X");
            yCoord = GetCoordinateValueFromConsole("Y");
            StaticInjector.Logger.Info($"Point {pointNumber} created, ({xCoord},{yCoord})");

            return new Point(xCoord, yCoord);
        }

        private int GetCoordinateValueFromConsole(string coordinateName)
        {
            bool isParsedOK = false;
            int coordinate;
            do
            {
                Console.Write($"{coordinateName} => ");
                string enteredStringNumber = Console.ReadLine();
                isParsedOK = int.TryParse(enteredStringNumber, out coordinate);
                if (!isParsedOK)
                {
                    StaticInjector.Logger.Error($"Not valid value of {coordinateName}");
                }
            } while (!isParsedOK);
            return coordinate;
        }
    }
}
