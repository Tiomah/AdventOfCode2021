namespace Day04_GiantSquid
{
    public class BingoNode
    {
        public bool IsMatched { get; set; }

        public int Value { get; set; }

        public BingoNode(bool isMatched, int value)
        {
            IsMatched = isMatched;
            Value = value;
        }
    }
}
