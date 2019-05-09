using SRR.UIP.HW9.LandCalculator.Shared.Interfaces;
using SRR.UIP.HW9.LandCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRR.UIP.HW9.LandCalculator.BLL.Services
{
    public class PointsValidator : IPointsValidator
    {
        public PointsValidationResult GetValidationResult(List<Point> points)
        {
            PointsValidationResult validationResult = new PointsValidationResult();
            validationResult.Mistakes = PointsMistakes.Nothing;
            if (!IsPointsCountMoreThanTwo(points))
            {
                validationResult.Mistakes = PointsMistakes.NotEnoughUniquePoints;
                validationResult.ArePointsValid = false;
                validationResult.Message = $"Passed validation {validationResult.ArePointsValid}; Problems: {validationResult.Mistakes}";
                return validationResult;
            }
            bool AreDublicates = GetNumberOfDublicates(points) != 0;
            validationResult.Mistakes = AreDublicates ?
                validationResult.Mistakes | PointsMistakes.NotEnoughUniquePoints : validationResult.Mistakes;
            validationResult.Mistakes = IsClosedContour(points) ?
                validationResult.Mistakes : validationResult.Mistakes | PointsMistakes.NotClosedShape;
            validationResult.Mistakes = IsCrossedContour(points) ?
                validationResult.Mistakes | PointsMistakes.CrossedShape : validationResult.Mistakes;

            validationResult.ArePointsValid = validationResult.Mistakes == PointsMistakes.Nothing;
            validationResult.Message = $"Passed validation {validationResult.ArePointsValid}; Problems: {validationResult.Mistakes}";

            return validationResult;
        }

        private bool IsPointsCountMoreThanTwo(List<Point> points)
        {
            if (points == null)
            {
                return false;
            }
            return points.Count > 2;
        }

        private bool IsClosedContour(List<Point> points)
        {
            int pointsCount = points.Count;
            bool isLastAndFirstPointsConnected = points[0] == points[pointsCount - 1];
            bool isNotOneLineOfEdges = IsNotOneLineOfEdges(points);

            return isLastAndFirstPointsConnected && isNotOneLineOfEdges;
        }

        private bool IsNotOneLineOfEdges(List<Point> points)
        {
            Point pointStart, pointMiddle, pointEnd;
            for (int i = 2; i < points.Count - 1; i++)
            {
                pointStart = points[i - 2];
                pointMiddle = points[i - 1];
                pointEnd = points[i];
                bool isNotOneLineWithThreePoints = !double.IsNaN(FindIntersection(pointStart, pointMiddle, pointMiddle, pointEnd).X);
                if (isNotOneLineWithThreePoints)
                {
                    return true;
                }

            }
            return false;
        }

        private int GetNumberOfDublicates(List<Point> points)
        {
            List<Point> tempPoints = points.GetRange(0, points.Count - 1);
            return tempPoints.Count - tempPoints.Distinct().ToList().Count;
        }

        private bool IsCrossedContour(List<Point> points)
        {
            List<Point> tempPoints = points.Distinct().ToList();
            int pointsCount = tempPoints.Count;
            Point sectionAPoint1, sectionAPoint2, sectionBPoint1, sectionBPoint2;
            for (int i = 2; i < pointsCount - 1; i++)
            {
                sectionAPoint1 = tempPoints[i];
                sectionAPoint2 = tempPoints[i + 1];
                for (int j = 0; j < i - 1; j++)
                {
                    if (i == pointsCount - 2 && j == 0)
                    {
                        continue;
                    }
                    sectionBPoint1 = tempPoints[j];
                    sectionBPoint2 = tempPoints[j + 1];
                    if (IsIntersection(sectionAPoint1, sectionAPoint2, sectionBPoint1, sectionBPoint2))
                    {
                        return true;
                    }

                }

            }
            return false;
        }

        public static Point FindIntersection(Point s1, Point e1, Point s2, Point e2)
        {

            double a1 = e1.Y - s1.Y;
            double b1 = s1.X - e1.X;
            double c1 = a1 * s1.X + b1 * s1.Y;

            double a2 = e2.Y - s2.Y;
            double b2 = s2.X - e2.X;
            double c2 = a2 * s2.X + b2 * s2.Y;

            double delta = a1 * b2 - a2 * b1;
            //If lines are parallel, the result will be (NaN, NaN).
            return delta == 0 ? new Point(double.NaN, double.NaN)
                : new Point((b2 * c1 - b1 * c2) / delta, (a1 * c2 - a2 * c1) / delta);
        }

        public static bool IsIntersection(Point p1, Point p2, Point p3, Point p4)
        {
            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;
            double denominator = (dy12 * dx34 - dx12 * dy34);
            double t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            if (double.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                return false;
            }
            double t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;
            return ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));
        }
    }
}
