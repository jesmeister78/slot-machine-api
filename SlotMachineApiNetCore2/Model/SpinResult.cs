using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachineApiNetCore2.Model
{
    public class SpinResult
    {
        public SpinResult(int numRows, int numCols)
        {
            NumCols = numCols;
            NumRows = numRows;

            ResultMap = GetResultMap();
        }

        public int NumCols { get; }
        public int NumRows { get; }

        public SymbolType[,] ResultMap { get; }

        private List<SymbolType> GetRandomisedReel()
        {
            var values = Enum.GetValues(typeof(SymbolType)).Cast<SymbolType>().ToList();
            var rng = new Random();

            var randomisedReel = values.OrderBy(a => rng.Next()).ToList();
            return randomisedReel;
        }

        private SymbolType[,] GetResultMap()
        {
            var result = new SymbolType[NumRows, NumCols];

            var random = new Random();

            for (var col = 0; col < NumCols; col++)
            {
                var reel = GetRandomisedReel();
                // simulate a reel where the order of the symbols is fixed but the start index is random
                for (var row = 0; row < NumRows; row++)
                {
                    result[row, col] = reel[row];
                    Console.WriteLine("row=" + row + " col=" + col + " result[row,col]=" + result[row, col]);
                }
            }

            return result;
        }

        public List<SymbolType> GetSymbolsForColumn(int col)
        {
            var colSymbols = new List<SymbolType>();

            for (var row = 0; row < NumRows; row++)
                colSymbols.Add(ResultMap[row, col]);

            return colSymbols;
        }
    }
}