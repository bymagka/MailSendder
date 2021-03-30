using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace MyParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length of matrix");

            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter maxvalue");

            int maxvalue = int.Parse(Console.ReadLine());

            MyMatrix firstMatrix = new MyMatrix(length, maxvalue);
            MyMatrix secondMatrix = new MyMatrix(length, maxvalue);

            Console.WriteLine("First matrix:" + firstMatrix + "\n");
            
            Console.WriteLine("Second matrix:" + secondMatrix);

            MyMatrix resultMatrix = MyMatrix.Multiply(firstMatrix, secondMatrix);

            Console.WriteLine("\n" + "Result matrix: " + resultMatrix);

            Console.ReadKey();

            //files
            FileProcessing();

            Console.ReadKey();

        }

        //task2
        private static void FileProcessing()
        {
            DirectoryInfo di = new DirectoryInfo("../../Files");
            var files = di.GetFiles(@"*.txt");
            File.Delete(@"../../Files/result.dat");
            Task[] TaskArray = new Task[files.Count()];

            using (StreamWriter streamWriter = new StreamWriter("../../Files/result.dat",true))
            { 
                 
                Parallel.For(0, files.Count(), (iterator) =>
                 {
                    TaskArray[iterator] = Task.Factory.StartNew(() => GetInfoAndSave(streamWriter,files[iterator]));
                 });
            }
            Task.WaitAll(TaskArray);

        }

        static void GetInfoAndSave(StreamWriter streamWriter,FileInfo file)
        {

            string[] data = File.ReadAllText(file.FullName).Split(' ');

            string resultLine = string.Empty;

            switch (int.Parse(data[0]))
            {
                case 1:
                    {
                        resultLine += double.Parse(data[1].Replace('.',',')) * double.Parse(data[2].Replace('.', ','));
                        break;
                    }
                case 2:
                    {
                        resultLine += double.Parse(data[1].Replace('.', ',')) / double.Parse(data[2].Replace('.', ','));
                        break;
                    }
            }

            resultLine += "\n" + "From file " + file.Name;

            streamWriter.WriteLine(resultLine);

        }
    }

   

    //task1
    class MyMatrix
    {
        public int MaxValue { get; set; }

        int[][] data;
        Random rnd = new Random();
        private int length;
        int digitsNumber;
        

        public MyMatrix(int length,int maxValue,bool initialize = true)
        {
            data = new int[length][];
            this.length = length;
            digitsNumber = maxValue.ToString().Length;
            this.MaxValue = maxValue;

            if (initialize)
            {
                Parallel.For(0, length, (iterator) =>
                {
                    data[iterator] = new int[length];

                    Parallel.For(0, length, (secondIterator) =>
                    {
                        data[iterator][secondIterator] = rnd.Next(0, maxValue);
                    });
                });
            }
            else
            {
                for(int i = 0; i < length; i++)
                {
                    data[i] = new int[length];
                }
            }
        }

        public static MyMatrix Multiply(MyMatrix firstMatrix, MyMatrix secondMatrix)
        {
            MyMatrix resultMatrix = new MyMatrix(firstMatrix.length,firstMatrix.MaxValue * secondMatrix.MaxValue,false);

            Parallel.For(0, resultMatrix.length, (firstIterator) =>
            {
                Parallel.For(0, resultMatrix.length, (secondIterator) =>
                {
                    int sum = 0;

                    Parallel.For(0, resultMatrix.length, (innerIterator) =>
                    {
                        sum += firstMatrix[firstIterator][innerIterator] * secondMatrix[innerIterator][secondIterator];
                       
                    });

                    resultMatrix[firstIterator][secondIterator] = sum;
                });
            });

            return resultMatrix;
        }

        public int this[int firstIndex, int secondIndex]
        {
            get
            {
                if (firstIndex < 0 || firstIndex >= length || secondIndex < 0 || secondIndex >= length) throw new ArgumentOutOfRangeException();
                return data[firstIndex][secondIndex];
            }
            set
            {
                if (firstIndex < 0 || firstIndex >= length || secondIndex < 0 || secondIndex >= length) throw new ArgumentOutOfRangeException();
                data[firstIndex][secondIndex] = value;
            }
        }

        public int[] this[int index]
        {
            get
            {
                if (index < 0 || index >= length ) throw new ArgumentOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index < 0 || index >= length ) throw new ArgumentOutOfRangeException();
                data[index] = value;
            }
        }

        public override string ToString()
        {

            string view = "\n";
           
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    view += string.Format(" {0:d"+ digitsNumber + "}", this[i][j]); 
                }
                view += "\n";
            }

            return view;

        }



    }



}
