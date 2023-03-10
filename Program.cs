using System;

namespace seminar8
{
    class Program
    {
        static int ReadInt(string prompt){
            Console.WriteLine(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

        static int[,] FillIntArray(int rows, int cols){
            int[,] array = new int[rows, cols];
            Random rand = new Random();
            for(int i = 0; i < rows; i++){
                for(int j = 0; j < cols; j++){
                    array[i, j] = rand.Next(1, 10);
                }
            }
            return array;
        }

        static void WriteIntArray(int[,] array){
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]+"\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void SwapRowsOfIntArray(int[,] array){
            for (int j = 0; j < array.GetLength(1); j++){
                int number = array[0, j];
                array[0, j] = array[array.GetLength(0)-1, j];
                array[array.GetLength(0)-1, j] = number;
            }
        }
        // smart, mathematical language FTW!!
        static int[,] TransposeIntArray(int[,] array){
            int[,] result = new int[array.GetLength(1), array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result[j, i] = array[i, j];
                }
            }
            return result;
        }

        static int[] CountElems(int[,] array){
            int[] countDictionary = new int[9];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    countDictionary[array[i, j]-1]++;
                }
            }
            return countDictionary;
        }

        static void WriteCountDictionary(int[] array){
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0){
                    Console.WriteLine(i+1 + " встречается " + array[i] + " раз");
                }
            }
        }

        static void FindMinIdx(int[,] array, out int mini, out int minj){
            mini = 0; 
            minj = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[mini, minj] > array[i, j]){
                        mini = i;
                        minj = j;
                    }
                }
            }
        }

        static int[,] DeleteRowAndCol(int[,] array, int mini, int minj){
            int[,] result = new int[array.GetLength(0)-1, array.GetLength(1)-1];
            int row = 0;
            int col = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i == mini) continue;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == minj) continue;
                    result[row, col] = array[i, j];
                    col++;
                }
                row++;
                col = 0;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[,] array1 = FillIntArray(ReadInt("Введите кол.во строк: "), ReadInt("Введите кол.во столбцов: "));
            WriteIntArray(array1);
            SwapRowsOfIntArray(array1);
            WriteIntArray(array1);

            int[,] array2 = FillIntArray(ReadInt("Введите кол.во строк: "), ReadInt("Введите кол.во столбцов: "));
            WriteIntArray(array2);
            WriteIntArray(TransposeIntArray(array2));

            int[,] array3 = FillIntArray(ReadInt("Введите кол.во строк: "), ReadInt("Введите кол.во столбцов: "));
            WriteIntArray(array3);
            WriteCountDictionary(CountElems(array3));

            int[,] array4 = FillIntArray(ReadInt("Введите кол.во строк: "), ReadInt("Введите кол.во столбцов: "));
            WriteIntArray(array4);
            int mini = 0;
            int minj = 0;
            FindMinIdx(array4, out mini, out minj);
            WriteIntArray(DeleteRowAndCol(array4, mini, minj));
        }
    }
}
