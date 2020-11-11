namespace _03.Telephony.IO.Contracts
{
    public interface IReader
    {
        public int MyProperty { get; set; }

        public string ReadLine();
    }
}
