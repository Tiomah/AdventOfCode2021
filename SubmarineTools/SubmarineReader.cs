using System;
using System.Collections.Generic;
using System.Linq;

namespace SubmarineTools
{
    public static class SubmarineReader
    {
        public static IEnumerable<string> ReadTextToStringRows(string inputText)
        {
            return inputText.Split("\r\n");
        }

        public static (IEnumerable<int>, IEnumerable<IEnumerable<int>>) ReadTextToBingoMatrixes(string inputText)
        {
            var stringBlocks = inputText.Split("\r\n\r\n");

            var stringBingoNumbers = stringBlocks[0].Split(',');
            var bingoNumbers = stringBingoNumbers.Select(s => int.Parse(s));

            var bingoMatrixList = new List<List<int>>();

            for (int i = 1; i < stringBlocks.Length; i++)
            {
                var stringBingoMatrix = stringBlocks[i].Split(new char[] { ',', '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                bingoMatrixList.Add(stringBingoMatrix.Select(s => int.Parse(s)).ToList());
            }

            return (bingoNumbers, bingoMatrixList);
        }
    }
}
