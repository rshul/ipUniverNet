using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW2.ConditionsArraysLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            int numberIntA = randomizer.Next(-50, 50);
            int numberIntB = randomizer.Next(-50, 50);
            int numberIntC = randomizer.Next(-50, 50);
            Console.WriteLine($"ValueA = {numberIntA} ValueB = {numberIntB} ValueC = {numberIntC}");

            //----Task 1 

            if (numberIntA > 0)
            {
                Console.WriteLine($"Number A is positive {numberIntA}");
            }
            else
            {
                Console.WriteLine($"Number A is negative {numberIntA}");
            }

            //----Task 2 

            bool isOdd = (numberIntA % 2) != 0;

            if (isOdd)
            {
                Console.WriteLine($"Number A is odd {numberIntA}");
            }
            else
            {
                Console.WriteLine($"Number A is even {numberIntA}");
            }

            //----Task 3 

            bool isExpressionTrue = numberIntA < numberIntB && numberIntB < numberIntC;

            if (isExpressionTrue)
            {
                Console.WriteLine($"Expression A < B < C is  {isExpressionTrue}");
            }
            else
            {
                Console.WriteLine($"Expression A < B < C is {isExpressionTrue}");
            }

            //----Task 4 

            bool isAtLeastOnePositive = (numberIntA > 0) || (numberIntB > 0) || (numberIntC > 0);

            if (isAtLeastOnePositive)
            {
                Console.WriteLine($"At least one is positive: {isAtLeastOnePositive}");
            }
            else
            {
                Console.WriteLine($"At least one is positive: {isAtLeastOnePositive}");
            }

            //----Task 5

            bool isPositiveA = numberIntA > 0;
            bool isPositiveB = numberIntB > 0;
            bool isPositiveC = numberIntC > 0;
            bool isOnlyPositiveA = isPositiveA && !isPositiveB && !isPositiveC;
            bool isOnlyPositiveB = !isPositiveA && isPositiveB && !isPositiveC;
            bool isOnlyPositiveC = !isPositiveA && !isPositiveB && isPositiveC;
            bool isOnlyOnePositive = isOnlyPositiveA || isOnlyPositiveB || isOnlyPositiveC;

            if (isOnlyOnePositive)
            {
                Console.WriteLine($"Only one is positive: {isOnlyOnePositive}");
            }
            else
            {
                Console.WriteLine($"Only one is positve: {isOnlyOnePositive}");
            }

            //----Task 6

            int posNumberInt = randomizer.Next(1, 10000);
            bool isThreeDigits = posNumberInt > 99 && posNumberInt < 1000;
            bool isOddPosNumberInt = posNumberInt % 2 != 0;

            if (isThreeDigits && isOddPosNumberInt)
            {
                Console.WriteLine($" OK ({isThreeDigits && isOddPosNumberInt}). The number {posNumberInt} has 3 digits - {isThreeDigits} and odd - {isOddPosNumberInt}");
            }
            else
            {
                Console.WriteLine($"The number {posNumberInt} has 3 digits - {isThreeDigits} and odd - {isOddPosNumberInt}");
            }

            //----Task 7

            // initializing coordinates of point and verteces of rectangle
            int numX = randomizer.Next(1, 50), numY = randomizer.Next(1, 50);
            int vertexX1 = randomizer.Next(1, 50), vertexY1 = randomizer.Next(1, 50);
            int vertexX2 = randomizer.Next(vertexX1 + 1, 51), vertexY2 = randomizer.Next(0, vertexY1 - 1);

            bool isInsideRectangle = numX > vertexX1 && numX < vertexX2 && numY > vertexY2 && numY < vertexY1;
            if (isInsideRectangle)
            {
                Console.WriteLine($"Inside Rectangle: x,y = {numX},{numY}; x1,y1 = {vertexX1},{vertexY1}; x2,y2 = {vertexY1},{vertexY2}");
            }
            else
            {
                Console.WriteLine($"x,y = {numX},{numY}; x1,y1 = {vertexX1},{vertexY1}; x2,y2 = {vertexY1},{vertexY2}");
            }

            //----Task 8

            int rectangleSideA = randomizer.Next(1, 30),
                rectangleSideB = randomizer.Next(1, 30),
                rectangleSideC = randomizer.Next(1, 30);
            bool isSumABGreaterC = rectangleSideA + rectangleSideB > rectangleSideC;
            bool isSumACGreaterB = rectangleSideA + rectangleSideC > rectangleSideB;
            bool isSumBCGreaterA = rectangleSideB + rectangleSideC > rectangleSideA;
            bool isTriangleExists = isSumBCGreaterA && isSumACGreaterB && isSumABGreaterC;

            if (isTriangleExists)
            {
                Console.WriteLine($"Triangle exitsts: {isTriangleExists}; a={rectangleSideA}, b={rectangleSideB}, c={rectangleSideC}");
            }
            else
            {
                Console.WriteLine($"Triangle doesn't exitst: {isTriangleExists}; a={rectangleSideA}, b={rectangleSideB}, c={rectangleSideC}");
            }

            //----Task 9

            int coordX = randomizer.Next(1, 9),
                coordY = randomizer.Next(1, 9);
            bool isWhite = (coordX + coordY) % 2 != 0;

            if (isWhite)
            {
                Console.WriteLine($"Field is white: {coordX},{coordY}");
            }
            else
            {
                Console.WriteLine($"Field is black: {coordX},{coordY}");
            }

            //----Task 10

            int firstFieldX = randomizer.Next(1, 9),
                firstFieldY = randomizer.Next(1, 9),
                secondFieldX = randomizer.Next(1, 9),
                secondFieldY = randomizer.Next(1, 9);

            while (firstFieldX == secondFieldX && secondFieldX == secondFieldY)
            {
                secondFieldX = randomizer.Next(1, 9);
                secondFieldY = randomizer.Next(1, 9);
            }

            bool isMoveStrait = firstFieldX == secondFieldX || firstFieldY == secondFieldY;
            bool isMoveDiagonal = Math.Abs(firstFieldX - secondFieldX) == Math.Abs(firstFieldY - secondFieldY);
            bool isOneMove = isMoveStrait || isMoveDiagonal;

            if (isOneMove)
            {
                Console.WriteLine($"It's possible to make one move: x1,y1 = {firstFieldX},{firstFieldY}; x2,y2 = {secondFieldX},{secondFieldY}");
            }
            else
            {
                Console.WriteLine($"Queen can't make only one move: x1,y1 = {firstFieldX},{firstFieldY}; x2,y2 = {secondFieldX},{secondFieldY}");
            }

            //----Task 11

            int numA = randomizer.Next(1, 11),
                numB = randomizer.Next(1, 11);

            Console.WriteLine($"Before: Number A = {numA}, number B = {numB}");
            numA = numA + numB;
            numB = numA - numB;
            numA = numA - numB;
            Console.WriteLine($"After: Number A = {numA}, number B = {numB}");

            //----Task 12

            string[] daysWeek = new string[7]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int numberOfDay = randomizer.Next(1, 8);
            Console.WriteLine($"The day of Week is {daysWeek[numberOfDay - 1]}");

            //----Task 13

            int numberK = randomizer.Next(1, 10);
            string[] markDescription = new string[4]
            {
                "Bad",
                "Good",
                "Very good",
                "Exellent"
            };

            if (numberK == 1 || numberK == 2)
            {
                Console.WriteLine($"The mark {numberK} is {markDescription[0]}");
            }
            else if (numberK < 6)
            {
                Console.WriteLine($"The mark {numberK} is {markDescription[numberK - 2]}");
            }
            else
            {
                Console.WriteLine($"Error! Mark {numberK} is out of range.");
            }

            //----Task 14

            int lengthUnit = randomizer.Next(1, 6);

            double minRandomDouble = 0.0,
                maxRandomDouble = 10.0,
                randomDouble = minRandomDouble + randomizer.NextDouble() * (maxRandomDouble - minRandomDouble);
            double[] convertNumber = new double[5]
            {
                0.1,
                1000,
                1.0,
                0.001,
                0.01
            };
            double lengthInMeters = randomDouble * convertNumber[lengthUnit - 1];

            Console.WriteLine($"The length is {lengthInMeters:f6} m. Initial unit is {lengthUnit} and value is {randomDouble:f6}");

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

            for(int i = 0; i<firstArray.Length; i++)
            {
                firstArray[i] = randomizer.Next(-20, 21);
            }

            for(int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = randomizer.Next(-20, 21);
            }

            int resultArrayCount = firstArrayCount > secondArrayCount ? firstArrayCount : secondArrayCount;
            int[] resultArray = new int[resultArrayCount];
            int lengthArrayDifference = firstArrayCount - secondArrayCount;
            for (int i = 0; i < resultArrayCount; i++)
            {
                if (i < resultArrayCount - Math.Abs(lengthArrayDifference ))
                {
                    resultArray[i] = firstArray[i] > secondArray[i] ? firstArray[i] : secondArray[i];
                }
                else
                {
                    resultArray[i] = lengthArrayDifference > 0  ? firstArray[i] : secondArray[i];
                }
            }

            for(int i = 0; i<firstArrayCount; i++)
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
            for(int i = 1; i < 100; i++)
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
                    if (numberOfEggs == 2) step++;          //increment of step from 14
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
