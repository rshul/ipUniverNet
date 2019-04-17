using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    enum LevelsOfLog
    {
        Info = 1,
        Debug = 2,
        Warn = 3,
        Error = 4,
        Fatal = 5
    }
    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.LogStorages.Add(new ConsoleLogStorage());
            logger.LogStorages.Add(new FileLogStorage());
            logger.LogLevel = LevelsOfLog.Info;

            List<Point> points = GetPoints(5, logger);
            Console.WriteLine($"{CalculateArea(points, true, logger)} = {CalculateArea(points, false, logger)}");

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
            bool isWrongInput = false;
            while (pointsCounter < PointsNumber)
            {
                tempPoint = GetPoint(pointsCounter, logger);
                if (pointsCounter > 0)
                {
                    foreach (var point in tempListOfPoints)
                    {
                        if (tempPoint.Equals(point))
                        {
                            isWrongInput = true;
                            logger.Warn("Points can not be the same");
                            break;
                        }
                    }
                    if (isWrongInput)
                    {
                        continue;
                    }
                }
                tempListOfPoints.Add(tempPoint);
                logger.Info($"Point {pointsCounter} with value ({tempPoint.X},{tempPoint.Y}) added");
                CalculateArea(tempListOfPoints, true, logger);
                CalculateArea(tempListOfPoints, false, logger);
                pointsCounter++;

            }

            return tempListOfPoints;
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
            string enteredStringNumber;
            int xCoord;
            int yCoord;
            bool isParsedOK = false;
            Console.WriteLine($"Enter coordinates of {pointNumber} point");
            do
            {
                Console.Write("X => ");
                enteredStringNumber = Console.ReadLine();
                isParsedOK = int.TryParse(enteredStringNumber, out xCoord);
                if (!isParsedOK)
                {
                    logger.Error($"Point {pointNumber}, not valid value X");
                }
            } while (!isParsedOK);

            do
            {
                Console.Write("Y => ");
                enteredStringNumber = Console.ReadLine();
                isParsedOK = int.TryParse(enteredStringNumber, out yCoord);
                if (!isParsedOK)
                {
                    logger.Error($"Point {pointNumber}, not valid value Y");
                }
            } while (!isParsedOK);
            logger.Info($"Point {pointNumber} created, ({xCoord},{yCoord})");
            return new Point(xCoord, yCoord);

        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodName()
        {
            StackFrame sf = new StackTrace().GetFrame(1);
            return sf.GetMethod().Name;
        }

    }
}
