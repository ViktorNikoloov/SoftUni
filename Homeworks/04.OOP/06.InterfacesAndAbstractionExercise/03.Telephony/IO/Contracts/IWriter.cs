namespace _03.Telephony.IO.Contracts
{
    public interface IWriter
    {
        public int MyProperty { get; set; }

        public void Write(string text);

        public void WriteLine(string text);
    }
}
