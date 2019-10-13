using System;
using System.Diagnostics;
using System.Linq;
using IronXL;

namespace ExcelLerEEscrever
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vetorDesordenado = new int[1001];
            int[] vetorGuarda = new int[1001];
            int[] vetorQuickSortORdenado;
            int[] vetorBubbleSortORdenado;
            QuickSort quicksort = new QuickSort();
            BubbleSort bubblesort = new BubbleSort();
            
            WorkBook workbook = WorkBook.Load(@"ordenacao.xlsx");
            WorkSheet sheet = workbook.WorkSheets.First();

            for (int i = 1; i <= 1000; i++) {
                vetorDesordenado[i] = sheet["A" + i].IntValue;
                vetorGuarda[i] = sheet["A" + i].IntValue;
                //Console.WriteLine("Vetor Desordenado " + i + " : " + vetorDesordenado[i]);
            }

            //verificando tempo decorrido na execucao da ordenacao dometodo QuickSort
            var stopwatchQuick = new Stopwatch();
            stopwatchQuick.Start();
            vetorQuickSortORdenado = quicksort.ordena(vetorDesordenado);
            stopwatchQuick.Stop();
            Console.WriteLine($"Tempo passado QuickSort: {stopwatchQuick.Elapsed}");

            //verificando tempo decorrido na execucao da ordenacao do metodo BubbleSort
            var stopwatchBubble = new Stopwatch();
            stopwatchBubble.Start();
            vetorBubbleSortORdenado = bubblesort.ordena(vetorDesordenado);
            stopwatchBubble.Stop();
            Console.WriteLine($"Tempo passado Bubble Sort: {stopwatchBubble.Elapsed}");


            for (int i = 1; i <= 1000; i++)
            {
                //Console.WriteLine("Vetor Ordenado QuickSort " + i + " : " + vetorQuickSortORdenado[i]);
            }

            for (int i = 1; i <= 1000; i++)
            {
                //Console.WriteLine("Vetor Ordenado BubbleSort " + i + " : " + vetorBubbleSortORdenado[i]);
            }

            //Criando um arquivo Excel e exportando na primeira coluna os valores desordenados e na segunda coluna 
            //com os valores ordenados
            WorkBook workbookSave = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheetSave = workbookSave.CreateWorkSheet("example_sheet");

            for (int i = 1; i <= 1000; i++)
            {
                sheetSave["A" + i].IntValue = vetorGuarda[i];
            }

            for (int i = 1; i <= 1000; i++)
            {
                sheetSave["B" + i].IntValue = vetorBubbleSortORdenado[i];
            }

            workbookSave.SaveAs(@"ordenacao2.xlsx");
        }
    }
}