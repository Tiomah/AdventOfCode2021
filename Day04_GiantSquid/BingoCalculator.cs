using System.Collections.Generic;
using System.Linq;

namespace Day04_GiantSquid
{
    public static class BingoCalculator
    {
        const int matrixSize = 5;

        public static int CalculateFirstBingoScore(IEnumerable<int> bingoNumbers, IEnumerable<IEnumerable<int>> matrixList)
        {
            if (bingoNumbers == null || matrixList == null)
                return 0;

            var bingoMatrixList = PopUpBingoMatrixes(matrixList).ToArray();

            for (int i = 0; i < bingoNumbers.Count(); i++)
            {
                for (int j = 0; j < bingoMatrixList.Count(); j++)
                {
                    if (CheckBingoMatrix(bingoMatrixList.ElementAt(j), bingoNumbers.ElementAt(i), i < matrixSize - 1))
                    {
                        return CalculateBingoMatrixScore(bingoMatrixList.ElementAt(j), bingoNumbers.ElementAt(i));
                    }
                }
            }

            return 0;
        }

        public static int CalculateLastBingoScore(IEnumerable<int> bingoNumbers, IEnumerable<IEnumerable<int>> matrixList)
        {
            if (bingoNumbers == null || matrixList == null)
                return 0;

            var bingoMatrixList = PopUpBingoMatrixes(matrixList).ToList();
            var indexesToRemove = new List<int>();

            for (int i = 0; i < bingoNumbers.Count(); i++)
            {
                for (int j = 0; j < bingoMatrixList.Count(); j++)
                {
                    if (CheckBingoMatrix(bingoMatrixList.ElementAt(j), bingoNumbers.ElementAt(i), i < matrixSize - 1))
                    {
                        if (bingoMatrixList.Count == 1)
                        {
                            return CalculateBingoMatrixScore(bingoMatrixList.ElementAt(j), bingoNumbers.ElementAt(i));
                        }

                        indexesToRemove.Add(j);
                    }
                }

                indexesToRemove.Reverse();

                foreach (var index in indexesToRemove)
                    bingoMatrixList.RemoveAt(index);

                indexesToRemove.Clear();
            }

            return 0;
        }

        private static IEnumerable<IEnumerable<BingoNode>> PopUpBingoMatrixes(IEnumerable<IEnumerable<int>> matrixes)
        {
            var bingoMatrixes = new List<List<BingoNode>>();

            for (int i = 0; i < matrixes.Count(); i ++)
            {
                bingoMatrixes.Add(matrixes.ElementAt(i).Select(num => new BingoNode(false, num)).ToList());
            }

            return bingoMatrixes;
        }

        private static bool CheckBingoMatrix(IEnumerable<BingoNode> bingoMatrix, int number, bool missCheck)
        {
            for (int i = 0; i < bingoMatrix.Count(); i++)
            {
                if (bingoMatrix.ElementAt(i).Value != number)
                    continue;

                bingoMatrix.ElementAt(i).IsMatched = true;

                if (missCheck)
                    return false;

                var leftIndexBorder = (i / matrixSize) * matrixSize;
                var matchesCount = 0;

                // Check row for completion
                for (int rowIndex = leftIndexBorder; rowIndex < leftIndexBorder + matrixSize; rowIndex++)
                {
                    if (bingoMatrix.ElementAt(rowIndex).IsMatched)
                        matchesCount++;
                }

                if (matchesCount == matrixSize)
                    return true;
                    
                matchesCount = 0;
                leftIndexBorder = (i % matrixSize);

                // Check column for completion
                for (int columnIndex = leftIndexBorder; columnIndex < matrixSize * matrixSize; columnIndex+= matrixSize)
                {
                    if (bingoMatrix.ElementAt(columnIndex).IsMatched)
                        matchesCount++;
                }

                if (matchesCount == matrixSize)
                    return true;
            }

            return false;
        }

        private static int CalculateBingoMatrixScore(IEnumerable<BingoNode> bingoMatrix, int number)
        {
            var sumOfUnmarked = 0;

            foreach (var node in bingoMatrix)
            {
                if (!node.IsMatched)
                    sumOfUnmarked += node.Value;
            }

            return sumOfUnmarked * number;
        }
    }
}
