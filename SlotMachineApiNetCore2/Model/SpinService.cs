using System;
using System.Collections.Generic;

namespace SlotMachineApiNetCore2.Model
{
    public class SpinService : ISpinService
    {
        public SpinResult GetSpinResult(int numRows, int numCols)
        {
            return new SpinResult(numRows, numCols);
        }

        public Dictionary<SymbolType, int> CalculateScore(SpinResult spinResult)
        {
            var score = new Dictionary<SymbolType, int>();
            for (var rowIndex = 0; rowIndex < spinResult.NumRows; rowIndex++)
            for (var colIndex = 0; colIndex < spinResult.NumCols; colIndex++)
            {
                // get the symbols for this col
                var curColSymbols = spinResult.GetSymbolsForColumn(colIndex);
                var curSymbol = curColSymbols[rowIndex];
                // add the first symbol to the score dictionary if it is not there yet
                if (!score.ContainsKey(curSymbol))
                    score[curSymbol] = 0;
                var currentSymbolScore = score[curSymbol];

                // no point calculating the score if the current score is already bigger than the next possible score
                if (currentSymbolScore < spinResult.NumCols - colIndex)
                    currentSymbolScore = GetScoreForSymbol(spinResult, curSymbol, ++colIndex, 1);

                score[curSymbol] = currentSymbolScore > score[curSymbol] ? currentSymbolScore : score[curSymbol];
            }


            return score;
        }

        public Dictionary<SymbolType, int> CalculateScoreSingleRow(SpinResult spinResult)
        {
            var score = new Dictionary<SymbolType, int>();
            for (var rowIndex = 0; rowIndex < spinResult.NumRows; rowIndex++)
            for (var colIndex = 0; colIndex < spinResult.NumCols; colIndex++)
            {
                // get the symbol for this col
                var curSymbol = spinResult.ResultMap[rowIndex, colIndex];
                // add the first symbol to the score dictionary if it is not there yet
                if (!score.ContainsKey(curSymbol))
                    score[curSymbol] = 0;
                var currentSymbolScore = score[curSymbol];

                // no point calculating the score if the current score is already bigger than the next possible score
                if (currentSymbolScore < spinResult.NumCols - colIndex)
                    currentSymbolScore = GetScoreForSymbolSingleRow(spinResult, curSymbol, rowIndex, ++colIndex, 1);

                score[curSymbol] = currentSymbolScore > score[curSymbol] ? currentSymbolScore : score[curSymbol];
            }


            return score;
        }

        public PlayerGroup GetPlayerGroup()
        {
            var rng = new Random();

            return (PlayerGroup)rng.Next(1, Enum.GetValues(typeof(PlayerGroup)).Length);
        }

        private int GetScoreForSymbol(SpinResult resultMap, SymbolType symbol, int nextColIndex, int score)
        {
            if (nextColIndex > resultMap.NumCols - 1)
                return score;
            var nextColSymbols = resultMap.GetSymbolsForColumn(nextColIndex);
            if (nextColSymbols.Contains(symbol))
                return GetScoreForSymbol(resultMap, symbol, ++nextColIndex, ++score);
            return score;
        }
        private int GetScoreForSymbolSingleRow(SpinResult resultMap, SymbolType symbol, int rowIndex, int nextColIndex, int score)
        {
            if (nextColIndex > resultMap.NumCols - 1)
                return score;
            var nextColSymbol = resultMap.ResultMap[rowIndex, nextColIndex];
            if (nextColSymbol == symbol)
                return GetScoreForSymbolSingleRow(resultMap, symbol, rowIndex, ++nextColIndex, ++score);
            return score;
        }
    }
}
