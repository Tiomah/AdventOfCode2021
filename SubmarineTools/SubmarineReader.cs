using System.Collections.Generic;

namespace SubmarineTools
{
    public static class SubmarineReader
    {
        public static IEnumerable<string> ReadTextToStringRows(string inputText)
        {
            return inputText.Split("\r\n");
        }
    }
}
