using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW2.ConditionsArraysLoops
{
    class Program
    {
        enum EnumDaysOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        };
        enum EnumLengthUnit
        {
            mm = 4,
            cm = 5,
            dm = 1,
            m = 3,
            km = 2
        };

        static void Main(string[] args)
        {
            Random randomizer = new Random();

            int numberIntA = randomizer.Next(-50, 50);
            int numberIntB = randomizer.Next(-50, 50);
            int numberIntC = randomizer.Next(-50, 50);
            Console.WriteLine($"ValueA = {numberIntA} ValueB = {numberIntB} ValueC = {numberIntC}");

            //----Task 1

            string outputString = numberIntA > 0 ? "positive" : "not positive";
            Console.WriteLine($"Number A = {numberIntA} is {outputString} ");

            //----Task 2 

            bool isOdd = (numberIntA % 2) != 0;
            outputString = isOdd ? "odd" : "even";
            Console.WriteLine($"Number A = {numberIntA} is {outputString} ");

            //----Task 3 

            bool isExpressionTrue = numberIntA < numberIntB && numberIntB < numberIntC;
            Console.WriteLine($"Expression A < B < C is  {isExpressionTrue}");

            //----Task 4 

            bool isAtLeastOnePositive = (numberIntA > 0) || (numberIntB > 0) || (numberIntC > 0);
            Console.WriteLine($"At least one is positive: {isAtLeastOnePositive}");

            //----Task 5

            bool isPositiveA = numberIntA > 0;
            bool isPositiveB = numberIntB > 0;
            bool isPositiveC = numberIntC > 0;
            bool isOnlyPositiveA = isPositiveA && !isPositiveB && !isPositiveC;
            bool isOnlyPositiveB = !isPositiveA && isPositiveB && !isPositiveC;
            bool isOnlyPositiveC = !isPositiveA && !isPositiveB && isPositiveC;
            bool isOnlyOnePositive = isOnlyPositiveA || isOnlyPositiveB || isOnlyPositiveC;
            Console.WriteLine($"Only one is positive: {isOnlyOnePositive}");

            //----Task 6

            int posNumberInt = randomizer.Next(1, 10000);
            bool isThreeDigits = posNumberInt > 99 && posNumberInt < 1000;
            bool isOddPosNumberInt = posNumberInt % 2 != 0;
            outputString = isThreeDigits && isOddPosNumberInt ? "Three digit number is odd" : "Number hasn't 3 digit or even";
            Console.WriteLine(outputString);

            //----Task 7

            // initializing coordinates of point and verteces of rectangle
            int numX = randomizer.Next(1, 50);
            int numY = randomizer.Next(1, 50);
            int vertexX1 = randomizer.Next(1, 50);
            int vertexY1 = randomizer.Next(1, 50);
            int vertexX2 = randomizer.Next(vertexX1 + 1, 51);
            int vertexY2 = randomizer.Next(0, vertexY1 - 1);

            bool isInsideRectangle = numX > vertexX1 && numX < vertexX2 && numY > vertexY2 && numY < vertexY1;
            outputString = isInsideRectangle ? "Inside recatangle" : "Outside rectangle";
            Console.WriteLine($"{outputString}: x,y = {numX},{numY}; x1,y1 = {vertexX1},{vertexY1}; x2,y2 = {vertexY1},{vertexY2}");

            //----Task 8

            int rectangleSideA = randomizer.Next(1, 30);
            int rectangleSideB = randomizer.Next(1, 30);
            int rectangleSideC = randomizer.Next(1, 30);
            bool isSumABGreaterC = rectangleSideA + rectangleSideB > rectangleSideC;
            bool isSumACGreaterB = rectangleSideA + rectangleSideC > rectangleSideB;
            bool isSumBCGreaterA = rectangleSideB + rectangleSideC > rectangleSideA;
            bool isTriangleExists = isSumBCGreaterA && isSumACGreaterB && isSumABGreaterC;
            outputString = isTriangleExists ? "Triangle exists" : "Triangle doesn't exist";
            Console.WriteLine($"{outputString}: {isTriangleExists}; a={rectangleSideA}, b={rectangleSideB}, c={rectangleSideC}");

            //----Task 9

            int coordX = randomizer.Next(1, 9);
            int coordY = randomizer.Next(1, 9);
            bool isWhite = (coordX + coordY) % 2 != 0;
            outputString = isWhite ? "white" : "black";
            Console.WriteLine($"Field is {outputString}: {coordX},{coordY}");

            //----Task 10

            int startFieldX = randomizer.Next(1, 9);
            int startFieldY = randomizer.Next(1, 9);
            int targetFieldX = randomizer.Next(1, 9);
            int targetFieldY = randomizer.Next(1, 9);

            while (startFieldX == targetFieldX && targetFieldX == targetFieldY)
            {
                targetFieldX = randomizer.Next(1, 9);
                targetFieldY = randomizer.Next(1, 9);
            }

            bool isMoveStrait = startFieldX == targetFieldX || startFieldY == targetFieldY;
            bool isMoveDiagonal = Math.Abs(startFieldX - targetFieldX) == Math.Abs(startFieldY - targetFieldY);
            bool isOneMoveFromStartToTarget = isMoveStrait || isMoveDiagonal;
            outputString = isOneMoveFromStartToTarget ? "It's possible to make one move from start to target" : "Queen can't get target by one move";
            Console.WriteLine($"{outputString}: x1,y1 = {startFieldX},{startFieldY}; x2,y2 = {targetFieldX},{targetFieldY}");

            //----Task 11

            int numA = randomizer.Next(1, 11);
            int numB = randomizer.Next(1, 11);

            Console.WriteLine($"Before: Number A = {numA}, number B = {numB}");
            numA = numA + numB;
            numB = numA - numB;
            numA = numA - numB;
            Console.WriteLine($"After: Number A = {numA}, number B = {numB}");

            //----Task 12

            int numberOfDay = randomizer.Next(1, 8);
            outputString = "";
            switch ((EnumDaysOfWeek) numberOfDay)
            {
                case EnumDaysOfWeek.Monday:
                    outputString = "Monday";
                    break;
                case EnumDaysOfWeek.Tuesday:
                    outputString = "Tuesday";
                    break;
                case EnumDaysOfWeek.Wednesday:
                    outputString = "Wednesday";
                    break;
                case EnumDaysOfWeek.Thursday:
                    outputString = "Thursday";
                    break;
                case EnumDaysOfWeek.Friday:
                    outputString = "Friday";
                    break;
                case EnumDaysOfWeek.Saturday:
                    outputString = "Saturday";
                    break;
                case EnumDaysOfWeek.Sunday:
                    outputString = "Sunday";
                    break;
                default:
                    outputString = "Error!";
                    break;

            }
            Console.WriteLine($"The day of Week is {outputString} ");

            //----Task 13

            int numberK = randomizer.Next(1, 10);
            outputString = "";
            switch (numberK)
            {
                case 1:
                case 2:
                    outputString = "Bad";
                    break;
                case 3:
                    outputString = "Good";
                    break;
                case 4:
                    outputString = "Very Good";
                    break;
                case 5:
                    outputString = "Excellent";
                    break;
                default:
                    outputString = "Mark is out of range";
                    break;
            }
            Console.WriteLine($"The mark is {outputString}");

            //----Task 14

            int lengthUnit = randomizer.Next(1, 6);
            double minRandomDouble = 0.0;
            double maxRandomDouble = 10.0;
            double randomDouble = minRandomDouble + randomizer.NextDouble() * (maxRandomDouble - minRandomDouble);
            double lengthInMeters;
            outputString = "";
            switch ((EnumLengthUnit) lengthUnit)
            {
                case EnumLengthUnit.mm:
                    outputString = "mm";
                    lengthInMeters = randomDouble / 1000;
                    break;
                case EnumLengthUnit.cm:
                    outputString = "cm";
                    lengthInMeters = randomDouble / 100;
                    break;
                case EnumLengthUnit.dm:
                    outputString = "dm";
                    lengthInMeters = randomDouble / 10;
                    break;
                case EnumLengthUnit.m:
                    outputString = "m";
                    lengthInMeters = randomDouble;
                    break;
                case EnumLengthUnit.km:
                    outputString = "km";
                    lengthInMeters = randomDouble * 1000;
                    break;
                default:
                    outputString = "error";
                    lengthInMeters = 0.0;
                    break;
            }

            Console.WriteLine($"The length is {lengthInMeters:f6} m. Initial unit is {randomDouble:f6} {outputString} and unit number is {lengthUnit}");

            //----Task 15

            string[] firstNineteenNumbers = new string[19]
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "ten",
                "eleven",
                "twelve",
                "thirteen",
                "fourteen",
                "fifteen",
                "sixteen",
                "seventeen",
                "eighteen",
                "nineteen"
            };
            string[] tensNumbers = new string[8]
            {
                "twenty",
                "thirty",
                "fourty",
                "fifty",
                "sixty",
                "seventy",
                "eighty",
                "ninety"
            };
            int randomIntNumber = randomizer.Next(1, 100);
            string resultString = "";

            if (randomIntNumber < 20)
            {
                resultString = firstNineteenNumbers[randomIntNumber - 1];
            }
            else
            {

                resultString = tensNumbers[randomIntNumber / 10 - 2] + " ";
                resultString += (randomIntNumber % 10) == 0 ? "" : firstNineteenNumbers[randomIntNumber % 10 - 1];
            }

            Console.WriteLine($"The result number of {randomIntNumber} is {resultString}");

            //----Task 16

            int firstArrayCount = randomizer.Next(1, 21),
                secondArrayCount = randomizer.Next(1, 21);
            int[] firstArray = new int[firstArrayCount];
            int[] secondArray = new int[secondArrayCount];

            for (int i = 0; i < firstArray.Length; i++)
            {
                firstArray[i] = randomizer.Next(-20, 21);
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = randomizer.Next(-20, 21);
            }

            int resultArrayCount = firstArrayCount > secondArrayCount ? firstArrayCount : secondArrayCount;
            int[] resultArray = new int[resultArrayCount];
            int lengthArrayDifference = firstArrayCount - secondArrayCount;
            for (int i = 0; i < resultArrayCount; i++)
            {
                if (i < resultArrayCount - Math.Abs(lengthArrayDifference))
                {
                    resultArray[i] = firstArray[i] > secondArray[i] ? firstArray[i] : secondArray[i];
                }
                else
                {
                    resultArray[i] = lengthArrayDifference > 0 ? firstArray[i] : secondArray[i];
                }
            }

            for (int i = 0; i < firstArrayCount; i++)
            {
                Console.Write($"{firstArray[i],4}");

            }
            Console.WriteLine();
            for (int i = 0; i < secondArrayCount; i++)
            {
                Console.Write($"{secondArray[i],4}");

            }
            Console.WriteLine();
            for (int i = 0; i < resultArrayCount; i++)
            {
                Console.Write($"{resultArray[i],4}");

            }
            Console.WriteLine();

            //----Task Broken eggs (optional)
            int minStep = 0,
                sumSteps = 0,
                averageSteps = 0;
            for (int i = 1; i < 100; i++)
            {
                int floorOfBrokenEgg = i;
                int numberOfEggs = 2;
                int step = 14;
                int stepCounter = 0;
                int currentFloor = 0;

                while (currentFloor < 101 && numberOfEggs > 0)
                {
                    currentFloor += step;

                    if (currentFloor >= floorOfBrokenEgg)   //if egg is broken
                    {
                        numberOfEggs--;                     //lost one egg
                        if (numberOfEggs == 1)
                        {
                            currentFloor -= step;           //return to safe floor
                            step = 1;                       //and now step is 1
                        }

                    }
                    if (numberOfEggs == 2)
                    {
                        step++;
                    }                                       //increment of step from 14
                    stepCounter++;                          //keep track number of steps

                }
                if (i == 1)
                {
                    minStep = stepCounter;
                }
                else
                {
                    if (minStep > stepCounter)
                    {
                        minStep = stepCounter;              //minimal number of steps
                    }
                }
                sumSteps += stepCounter;
            }
            averageSteps = sumSteps / 100;

            Console.WriteLine($" average number of steps {averageSteps}, minimal steps {minStep}");

            Console.ReadLine();
        }
    }
}
