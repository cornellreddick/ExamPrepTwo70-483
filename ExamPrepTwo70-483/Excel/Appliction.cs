namespace Excel
{
    internal class Appliction
    {
        public Appliction()
        {
        }

        public bool Visible { get; internal set; }
        public object Workbooks { get; internal set; }
        public dynamic ActiveSheet { get; internal set; }

        public int Add()
        {
            return 1 + 1;
        }
    }
}