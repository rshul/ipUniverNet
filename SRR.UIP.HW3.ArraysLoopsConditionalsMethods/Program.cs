using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW3.ArraysLoopsConditionalsMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();
            //--1--Даны два целых числа A и B (A < B). Вывести в порядке возрастания все целые числа,
            //расположенные между A и B (включая сами числа A и B), а также количество N этих чисел.
            int task1NumberA = randomizer.Next(-50, 50);
            int task1NumberB = randomizer.Next(task1NumberA + 1, 51);
            UpPrintNumbersBetweenABIncluding(task1NumberA, task1NumberB);

            //--2--Даны два целых числа A и B (A < B). Вывести в порядке убывания все целые числа,
            //расположенные между A и B (не включая числа A и B), а также количество N этих чисел.
            int task2NumberA = randomizer.Next(-50, 50);
            int task2NumberB = randomizer.Next(task2NumberA + 1, 51);
            DownPrintNumbersBetweenABNotIncluding(task2NumberA, task2NumberB);

            //--3--Начальный вклад в банке равен $1000. Через каждый месяц размер вклада увеличивается
            //на P процентов от имеющейся суммы (P — вещественное число, 0 < P < 25). По данному P определить,
            //через сколько месяцев размер вклада превысит $1100, и вывести найденное количество месяцев K (целое число)
            //и итоговый размер вклада S (вещественное число).
            double minDepositPercent = 0.001;
            double maxDepositPercent = 25.0;
            double depositPercent = minDepositPercent + randomizer.NextDouble() * (maxDepositPercent - minDepositPercent);
            double initialDepositSum = 1000;
            double targetDepositSum = 1100;
            double currentDepositSum = initialDepositSum;
            int numberOfMonthsToTargetSum = 0;
            while (currentDepositSum < targetDepositSum)
            {
                currentDepositSum += currentDepositSum * (double) depositPercent / 100;
                numberOfMonthsToTargetSum++;
            }
            Console.WriteLine($"percent {depositPercent}");
            Console.WriteLine($"Number of months to get more than $1100 is {numberOfMonthsToTargetSum} and final sum is {currentDepositSum}");

            //--4--Дано целое число N (> 0). Сформировать и вывести целочисленный массив размера N,
            //содержащий N первых положительных нечетных чисел: 1, 3, 5, … .
            int task4NumberN = randomizer.Next(1, 50);
            int[] oddNumbersArray = new int[task4NumberN];
            for (int i = 0; i < task4NumberN; i++)
            {
                oddNumbersArray[i] = (i+1) * 2 - 1;
            }
            PrintArray(oddNumbersArray);

            //--5--Дан массив размера N. Вывести его элементы в обратном порядке.
            int task5NumberN = randomizer.Next(1, 50);
            int[] task5RandomArray = MakeRandomArray(randomizer, task5NumberN, -50, 50);
            PrintArray(task5RandomArray);
            PrintReversedArray(task5RandomArray);

            //--6--Дан целочисленный массив размера N. Вывести вначале все содержащиеся в данном массиве
            //четные числа в порядке возрастания их индексов, а затем — все нечетные числа в порядке убывания их индексов.
            //Также вывести количество четных и нечетных членов массива.
            int task6NumberN = randomizer.Next(1, 50);
            int[] task6RandomArray = MakeRandomArray(randomizer, task6NumberN, -50, 50);
            Console.WriteLine();
            PrintArray(task6RandomArray);
            Console.Write("\n[");
            for (int i = 0; i < task6RandomArray.Length; i++) 
            {
                if (task6RandomArray[i] % 2 == 0)
                {
                    Console.Write($"{task6RandomArray[i],4}");
                }
            }
            Console.WriteLine("  ]");
            Console.Write("[");
            for (int i = task6RandomArray.Length - 1; i > -1; i--)
            {
                if (task6RandomArray[i] % 2 != 0)
                {
                    Console.Write($"{task6RandomArray[i],4}");
                }
            }
            Console.WriteLine("  ]");

            //--7--Дан массив A размера N (N — четное число). Вывести его элементы с четными номерами в порядке возрастания
            //номеров: A2, A4, A6, …, AN. Условный оператор не использовать.
            int task7NumberN = randomizer.Next(1, 50);
            task7NumberN = task7NumberN % 2 == 0 ? task7NumberN : task7NumberN + 1;
            int[] task7RandomArray = MakeRandomArray(randomizer, task7NumberN, -50, 50);
            Console.Write("[");
            for (int i = 1; i < task7RandomArray.Length; i += 2)
            {
                Console.Write($"{task7RandomArray[i],4}");
            }
            Console.WriteLine("  ]");

            //--8--Дан целочисленный массив размера N. Найти количество различных элементов в данном массиве.
            int task8NumberN = randomizer.Next(1, 50);
            int[] task8RandomArray = MakeRandomArray(randomizer, task8NumberN, -50, 50);
            int numberOfDifferentElementsInArray = FindNumberOfDifferentElementsInArray(task8RandomArray);
            Console.WriteLine($"Number of different elements is {numberOfDifferentElementsInArray}");
             
            //--9--Дано целое число N (> 0). Найти произведение N! = 1·2·…·N (N–факториал). Чтобы избежать целочисленного переполнения,
            //вычислять это произведение с помощью вещественной переменной и вывести его как вещественное число. Использовать рекурсию.
            int task9NumberN = randomizer.Next(1, 50);
            double factorialOfNumber = Factorial(task9NumberN);
            Console.WriteLine($"Factorial of {task9NumberN} is {factorialOfNumber}");

            //--10--Написать метод, который считает и выводит на консоль последовательность
            //Фибоначчи (число элементов в последовательности принимается, как входящий параметр), используя рекурсию.
            int task10NumberN = randomizer.Next(1, 50);
            CalculateAndPrintFibonacci(task10NumberN);

            //--11--Создать метод вычисляющий количество дней в месяце определённого года (с учётом високосности года)
            int year = 2020;
            int monthNumber = 2;
            int numberOfDaysInMonth = GetNumberOfDayInMonth(year,monthNumber);
            Console.WriteLine($"in the year {year} and month {monthNumber} there are {numberOfDaysInMonth} days");

            //--12--Дан массив размера N. Обнулить элементы массива, расположенные между его 
            //минимальным и максимальным элементами (не включая минимальный и максимальный элементы).
            int task12NumberN = randomizer.Next(1, 50);
            int[] task12RandomArray = MakeRandomArray(randomizer, task12NumberN);
            int maxValueIndex = FindMaxValueIndexInArrayFromTheEnd(task12RandomArray);
            int minValueIndex = FindMinValueIndexInArrayFromTheStart(task12RandomArray);
            bool isMinMaxValueIndicesSwaped = minValueIndex > maxValueIndex;

            maxValueIndex = FindMaxValueIndexInArrayFromTheStart(task12RandomArray);
            minValueIndex = FindMinValueIndexInArrayFromTheEnd(task12RandomArray);
            int startOfSectionInArray = isMinMaxValueIndicesSwaped ? minValueIndex : maxValueIndex;
            int endOfSectionInArray = isMinMaxValueIndicesSwaped ? maxValueIndex : minValueIndex;
            Console.WriteLine("make zero between max and min values:");
            PrintArray(task12RandomArray);

            if (task12RandomArray.Length > 2)
            {
                for (int i = startOfSectionInArray + 1; i < endOfSectionInArray; i++)
                {
                    task12RandomArray[i] = 0;
                }
            }
            else
            {
                Console.WriteLine("Array must have more than 2 elements");
            }
            PrintArray(task12RandomArray);

            //--13--Создайте массив N (случайноe число от 1 до 10) с массивами длинной М (случайноe число от 20 до 50).
            //Заполните его случайными целыми числами от 0 до 9. Выведите массив на экран. 
            //Отсортируйте каждую строку массива, по возрастанию. Выведите преобразованный массив на экран.
            int task13NumberN = randomizer.Next(1, 10);
            int[][] randomArrayOfArray = MakeRandomArrayOfArray(task13NumberN);
            PrintArrayOfArray(randomArrayOfArray);
            foreach (var item in randomArrayOfArray)
            {
                BubbleSort(item);
            }
            PrintArrayOfArray(randomArrayOfArray);

            Console.WriteLine($"ArrayOfArray length {randomArrayOfArray.Length}");

            //--14--Учитель задаёт каждому ученику пример из таблицы умножения. В классе 15 человек,
            //примеры среди них не должны повторяться. Напишите программу/метод, которая будет
            //выводить на экран 15 случайных примеров из таблицы умножения (от 2*2 до 9*9).
            //При этом среди 15 примеров не должно быть повторяющихся (примеры 2*3 и 3*2 и им подобные пары считать повторяющимися).
            int numberOfExamples = 15;
            int[,] examplesOfMultTable = GenerateMultTableExamples(numberOfExamples, randomizer);
            for (int i = 0; i < numberOfExamples; i++)
            {
                Console.WriteLine($"{examplesOfMultTable[i, 0]} X {examplesOfMultTable[i, 1]};");
            }

            //--15--Создать метод проверяющий, что у переданного числа первая цифра равна последней
            int givenNumber = 1334451;
            bool isFirstAndLastDigitsEqual = CheckFirstAndLastDigit(givenNumber);
            Console.WriteLine($"First and last digit of number {givenNumber} are equal: {isFirstAndLastDigitsEqual}");

            //--16--Путешественник проходит каждый день несколько километров. Создать метод, выводящий на экран
            //его путь с начала путешествия(в виде "День №1 : 10км; День №2 : 7км; День №3 : 13км; ").
            //Метод должен работать для любого количества дней путешествия.
            int numberOfTravelDays = randomizer.Next(0, 15);
            PrintWayOfTravel(numberOfTravelDays);

            //--17--Создать метод, возвращающий true, если заданное число находится "повсюду" в целочисленном массиве.
            //Под "повсюду" подразумевается, что при рассмотрении любой пары рядом стоящих элементов массива,
            //одним из элементов будет искомое число
            int checkingNumber = randomizer.Next(0,10);
            int[] task17RandomArray = MakeRandomArray(randomizer, 10, 0, 10);
            bool isNumberEverywhere = CheckIfEverywhere(task17RandomArray, checkingNumber);
            PrintArray(task17RandomArray);
            Console.WriteLine(isNumberEverywhere);
            int[] trueArray = GenerateIsEverywhereArray(checkingNumber);
            isNumberEverywhere = CheckIfEverywhere(trueArray, checkingNumber);
            PrintArray(trueArray);
            Console.WriteLine(isNumberEverywhere);

            //--18--Создать метод, проверяющий, может ли массив быть "сбалансированным", т.е. разделённым на две части в каком-то месте,
            //таким образом, чтобы сумма элементов одной части равнялась сумме элементов второй.
            int[] task18RandomArray = MakeRandomArray(randomizer, 10, 4, 10);
            bool isArrayBalanced = CheckIfArrayBalanced(task18RandomArray);
            PrintArray(task18RandomArray);
            Console.WriteLine($"Array is balanced: {isArrayBalanced}");

            //--19--Реализовать метод быстрой сортировки одномерного массива с помощью рекурсивного метода.
            int task19RandomNumber = randomizer.Next(4, 30);
            int[] task19RandomArray = MakeRandomArray(randomizer, task19RandomNumber);
            Console.WriteLine($"Before sorting");
            PrintArray(task19RandomArray);
            Console.WriteLine($"After sorting");
            QuickSortImplementation(task19RandomArray, 0, task19RandomArray.Length - 1);
            PrintArray(task19RandomArray);

            Console.ReadLine();
        }

        private static bool CheckIfArrayBalanced(int[] takenArray)
        {
            bool isBalanced = false;
            int currentSum = 0;
            int wholeSum = GetSumOfArray(takenArray);
            foreach(var item in takenArray)
            {
                currentSum += item;
                if(currentSum == wholeSum - currentSum)
                {
                    isBalanced = true;
                }
            }
            return isBalanced;
        }

        private static int GetSumOfArray(int[] takenArray)
        {
            int sumOfArray = 0;
            foreach(var item in takenArray)
            {
                sumOfArray += item;
            }
            return sumOfArray;
        }

        private static bool CheckIfEverywhere(int[] takenArray, int checkNumber)
        {
            int counter = takenArray[0] == checkNumber ? 0 : 1;
            bool isElementEverywhere = true;
            while (counter < takenArray.Length)
            {
                if (takenArray[counter] != checkNumber)
                {
                    isElementEverywhere = false;
                    break;
                }
                counter += 2;
            }
            return isElementEverywhere;

        }
        private static int[] GenerateIsEverywhereArray(int checkingNumber)
        {
            Random randomizer = new Random();
            int lengthOfArray = randomizer.Next(4, 10);
            int[] generatedArray = new int[lengthOfArray];
            int randomChoice = randomizer.Next(0, 2);
            for (int i = 0; i < lengthOfArray; i++)
            {
                generatedArray[i] = i % 2 == randomChoice ? checkingNumber : randomizer.Next(0, 10);
            }
            return generatedArray;
        }


        private static void PrintWayOfTravel(int numberOfTravelDays)
        {
            Random randomizer = new Random();
            for(int i = 0; i < numberOfTravelDays; i++)
            {
                int goneDistance = randomizer.Next(1, 30);
                Console.WriteLine($"Day {i+1,3}: {goneDistance,3}km;");
            }

        }

        private static bool CheckFirstAndLastDigit(int givenNumber)
        {
            string numberToString = givenNumber.ToString();
            bool isFirstAndLastCharEqual = numberToString[0] == numberToString[numberToString.Length - 1];
            return isFirstAndLastCharEqual;
        }

        private static int[,] GenerateMultTableExamples(int numberOfExamples, Random randomizer)
        {
            int[,] tableOfBusyElements = new int[8, 8];                                         // for checking duplicates 
            for (int i = 0; i < 8; i++)                                                         // 0 - free, 1 - busy
            {
                for (int j = 0; j < 8; j++)
                {
                    tableOfBusyElements[i, j] = 0;
                }
            }
            int[,] generatedExamplesOfMultTable = new int[numberOfExamples, 2];                 // examples placed in array n x 2
            int firstNumber = 0;
            int secondNumber = 0;
            for (int i = 0; i < numberOfExamples; i++)
            {
                firstNumber = randomizer.Next(2, 10);
                secondNumber = randomizer.Next(2, 10);
                bool isBusyExample = tableOfBusyElements[firstNumber - 2, secondNumber - 2] == 1;   // check duplicates
                while (isBusyExample)                                                               // preventing duplicates
                {
                    firstNumber = randomizer.Next(2, 10);
                    secondNumber = randomizer.Next(2, 10);
                    isBusyExample = tableOfBusyElements[firstNumber - 2, secondNumber - 2] == 1;
                }
                generatedExamplesOfMultTable[i, 0] = firstNumber;
                generatedExamplesOfMultTable[i, 1] = secondNumber;
                tableOfBusyElements[firstNumber - 2, secondNumber - 2] = 1;                         // +2 is offset from array index
                tableOfBusyElements[secondNumber - 2, firstNumber - 2] = 1;
            }
            return generatedExamplesOfMultTable;
        }

        private static int[][] MakeRandomArrayOfArray(int numberN)
        {
            Random randomizer = new Random();
            int[][] randomArrayOfArray = new int[numberN][];
            for(int i = 0; i < randomArrayOfArray.Length; i++)
            {
                randomArrayOfArray[i] = MakeRandomArray(randomizer, randomizer.Next(20, 50), 0, 10);
            }
            return randomArrayOfArray;
        }
        private static void PrintArrayOfArray(int [][] takenArrayOfArray)
        {
            int counter = 0;
            foreach (var item in takenArrayOfArray)
            {
                Console.WriteLine($"array number {counter++}:");
                PrintArray(item);
            }
        }

        private static int FindMaxValueIndexInArrayFromTheEnd(int[] takenArray)
        {
            int maxValueIndex = takenArray.Length - 1;
            for (int i = takenArray.Length -1; i > -1; i--)
            {
                if (takenArray[maxValueIndex] < takenArray[i])
                {
                    maxValueIndex = i;
                }
            }
            return maxValueIndex;
        }
        private static int FindMaxValueIndexInArrayFromTheStart(int[] takenArray)
        {
            int maxValueIndex = 0;
            for (int i = 0; i < takenArray.Length; i++)
            {
                if (takenArray[maxValueIndex] > takenArray[i])
                {
                    maxValueIndex = i;
                }
            }
            return maxValueIndex;
        }
        private static int FindMinValueIndexInArrayFromTheStart(int[] takenArray)
        {
            int minValueIndex = 0;
            for (int i = 0; i < takenArray.Length; i++)
            {
                if (takenArray[minValueIndex] > takenArray[i])
                {
                    minValueIndex = i;
                }
            }
            return minValueIndex;
        }
        private static int FindMinValueIndexInArrayFromTheEnd(int[] takenArray)
        {
            int minValueIndex = takenArray.Length - 1;
            for (int i = takenArray.Length - 1; i > -1; i--)
            {
                if (takenArray[minValueIndex] < takenArray[i])
                {
                    minValueIndex = i;
                }
            }
            return minValueIndex;
        }

        private static int GetNumberOfDayInMonth(int year, int monthNumber)
        {
            int leapYear = 1900;
            bool isLeapYear = Math.Abs(year - leapYear) % 4 == 0;
            int[] daysInMonth = new int[12]
            {
                31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
            };
            int calculatedDaysInMonth = isLeapYear && monthNumber == 2 ? daysInMonth[monthNumber - 1] + 1 : daysInMonth[monthNumber - 1];
            return calculatedDaysInMonth;
        }

        private static void CalculateAndPrintFibonacci(int numberN, int firstElement = 0, int secondElement = 1)
        {
            Console.WriteLine(firstElement);
            if (numberN > 1)
            {
                CalculateAndPrintFibonacci(--numberN, secondElement, firstElement + secondElement); 
            }
        }

        private static double Factorial(int numberN)
        {
            if (numberN < 1)
            {
                return 1;
            }
            return Factorial(numberN - 1) * numberN;
        }

        private static int FindNumberOfDifferentElementsInArray(int[] takenArray)
        {
            int counter = 1;
            int[] tempArray = (int[])takenArray.Clone();
            BubbleSort(tempArray);
            //PrintArray(tempArray);
            if (tempArray.Length > 1)
            {
                for (int i = 1; i < tempArray.Length; i++)
                {
                    if (tempArray[i-1] != tempArray[i])
                    {
                        counter++;
                    }
                }
            }
            else
            {
                counter = tempArray.Length;
            }

            return counter;
        }

        private static void PrintArray(int[] sampleArray)
        {
            int indexOfArray = 0;
            Console.Write("[");
            foreach (int arrayItem in sampleArray)
            {
                Console.Write($"{arrayItem,4}");
                indexOfArray++;
            }
            Console.Write("  ]\n");
        }
        private static void PrintReversedArray(int[] takenArray)
        {
            Console.WriteLine("Reversed array");
            Console.Write("[");
            for (int i = takenArray.Length - 1; i > -1; i--)
            {
                Console.Write($"{takenArray[i],4}");
            }
            Console.Write("  ]");
        }

        private static int[] MakeRandomArray(Random randomizer, int arraySize, int minItemNumber = 0, int maxItemNumber = 100)
        {
            int[] generatedArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                generatedArray[i] = randomizer.Next(minItemNumber, maxItemNumber + 1);
            }
            return generatedArray;
        }

        private static void QuickSortImplementation(int[] takenArray, int lowIndex, int highIndex)
        {
            // https://en.wikipedia.org/wiki/Quicksort
            //-------Lomuto partition scheme------
            //         *** Pseudocode****
            //
            // algorithm quicksort(A, lo, hi) is
            //     if lo < hi then
            //        p := partition(A, lo, hi)
            //        quicksort(A, lo, p - 1)
            //        quicksort(A, p + 1, hi)

            //algorithm partition(A, lo, hi) is
            //     pivot := A[hi]
            //     i := lo
            //     for j := lo to hi - 1 do
            //         if A[j] < pivot then
            //             swap A[i] with A[j]
            //             i := i + 1
            //     swap A[i] with A[hi]
            //     return i

            if (lowIndex < highIndex)
            {
                int pivotElement = PartitionQSI(takenArray, lowIndex, highIndex);
                QuickSortImplementation(takenArray, lowIndex, pivotElement - 1);
                QuickSortImplementation(takenArray, pivotElement + 1, highIndex);

            }

        }
        private static int PartitionQSI(int[] takenArray, int lowIndex, int highIndex)
        {
            // refer to QuickSortImplementation
            int pivotElement = takenArray[highIndex];
            int leftIndex = lowIndex;
            for(int rightIndex = lowIndex; rightIndex < highIndex; rightIndex++)
            {
                if (takenArray[rightIndex] < pivotElement)
                {
                    SwapElementsOfArray(takenArray, leftIndex, rightIndex);
                    leftIndex++;
                }
            }
            SwapElementsOfArray(takenArray, leftIndex, highIndex);
            return leftIndex;
        }
        private static void SwapElementsOfArray(int[] takenArray, int firstItemIndex, int secondItemIndex)
        {
            int tempItem = takenArray[firstItemIndex];
            takenArray[firstItemIndex] = takenArray[secondItemIndex];
            takenArray[secondItemIndex] = tempItem;
        }
        private static void BubbleSort(int[] takenArray , bool isReversed = false)
        {
            for (int i = takenArray.Length - 1; i > 0; i--)
            {
                int reversedSortingSwitch = isReversed ? -1 : 1;
                for (int j = 0; j < i; j++)
                {
                    if ( reversedSortingSwitch * takenArray[j] > reversedSortingSwitch * takenArray[j+1])
                    {
                        SwapElementsOfArray(takenArray, j, j + 1);
                    }
                }
            }
        }
        private static void UpPrintNumbersBetweenABIncluding(int integerNumberA, int integerNumberB)
        {
            int counter = 0;
            while(integerNumberA <= integerNumberB)
            {
                Console.Write($"{integerNumberA++,3}");
                counter++;
            }
            Console.WriteLine($"\nThere are {counter} numbers");
        }
        private static void DownPrintNumbersBetweenABNotIncluding(int integerNumberA, int integerNumberB)
        {
            int counter = 0;
            while (integerNumberA + 1 < integerNumberB)
            {
                Console.Write($"{--integerNumberB,3}");
                counter++;
            }
            Console.WriteLine($"\nThere are {counter} numbers");
        }


    }
}
