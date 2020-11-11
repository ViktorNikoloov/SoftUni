namespace _03.Telephony.Models.Contracts
{
    public interface ICallable
    {
        public int MyProperty { get; set; }

        public string Call(string number);
    }
}
