using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.LogStorages.Add(new ConsoleLogStorage());
            logger.LogStorages.Add(new FileLogStorage());
            logger.LogLevel = LogLevels.Warn;

            List<Point> points = GetPoints(5, logger);
            Console.WriteLine($"{CalculateArea(points, true, logger)} = {CalculateArea(points, false, logger)}");
            logger.LogLevel = LogLevels.Fatal;
            long calculatedArea = CalculateArea(points, true, logger);
            bool isCalculatedAreaValid = calculatedArea == CalculateArea(points, false, logger);
            if (isCalculatedAreaValid && calculatedArea > 0)
            {
                Console.WriteLine($"Caclulated area is {calculatedArea}");
            }
            Console.ReadKey();
        }

        static List<Point> GetPointsTest()
        {
            List<Point> setOfPoints = new List<Point>
            {
                new Point(0,0),
                new Point(1,1),
                new Point(2,4),
                new Point(3,1),
                new Point(4,0)
            };
            return setOfPoints;
        }

        static List<Point> GetPoints(int PointsNumber, Logger logger)
        {
            if (PointsNumber <= 0 || PointsNumber > 20)
            {
                logger.Warn("Number of points must be  0 < x <=20");
                return null;
            }
            Point tempPoint;
            List<Point> tempListOfPoints = new List<Point>();
            int pointsCounter = 0;
            while (pointsCounter < PointsNumber)
            {
                tempPoint = GetPoint(pointsCounter, logger);
                bool isInputValid = IsPointValid(tempListOfPoints, tempPoint, logger);
                if (!isInputValid)
                {
                    continue;
                }
                tempListOfPoints.Add(tempPoint);
                logger.Info($"Point {pointsCounter} with value ({tempPoint.X},{tempPoint.Y}) added");
                pointsCounter++;

            }

            return tempListOfPoints;
        }

        static bool IsPointValid(List<Point> pointsCollection, Point takenPoint,  Logger logger)
        {
            if (pointsCollection.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (var point in pointsCollection)
                {
                    if (takenPoint.Equals(point))
                    {
                        logger.Warn("Points can not be the same");
                        return false;
                    }
                }
                return true;
            }
         
        }

        static long CalculateArea(List<Point> points, bool isAltAppr, Logger logger)
        {
            string calculationMode = isAltAppr ? "Main Calculation" : "Control calculation";
            logger.Info(calculationMode);
            long landArea = 0;
            for (int i = 0; i < points.Count; i++)
            {
                int nextIndex = (i == points.Count - 1) ? 0 : i + 1;
                int prevIndex = (i == 0) ? points.Count - 1 : i - 1;
                long par1 = isAltAppr ? points[i].X : points[i].Y;
                long par2_1 = isAltAppr ? points[nextIndex].Y : points[prevIndex].X;
                long par2_2 = isAltAppr ? points[prevIndex].Y : points[nextIndex].X;
                landArea += par1 * (par2_1 - par2_2);
            }
            long result = (long)Math.Abs(landArea / 2);
            logger.Info($"Calculated result {result}");
            return result;
        }

        static Point GetPoint(int pointNumber, Logger logger)
        {
            int xCoord;
            int yCoord;
            
            Console.WriteLine($"Enter coordinates of {pointNumber} point");
            InputCoordinate("X",logger, out xCoord);
            InputCoordinate("Y", logger, out yCoord);
            logger.Info($"Point {pointNumber} created, ({xCoord},{yCoord})");
            return new Point(xCoord, yCoord);
        }

        private static void InputCoordinate(string coordinateName,Logger logger, out int coordinate)
        {
            bool isParsedOK = false;
            do
            {
                Console.Write($"{coordinateName} => ");
                string enteredStringNumber = Console.ReadLine();
                isParsedOK = int.TryParse(enteredStringNumber, out coordinate);
                if (!isParsedOK)
                {
                    logger.Error($"Not valid value of {coordinateName}");
                }
            } while (!isParsedOK);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodName()
        {
            StackFrame sf = new StackTrace().GetFrame(1);
            return sf.GetMethod().Name;
        }

    }
}
