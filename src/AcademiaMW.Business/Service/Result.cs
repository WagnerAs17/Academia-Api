namespace AcademiaMW.Business.Service
{
    public class Result<T>
    {
        public T Value { get; set; }
        public bool PrimeiroAcesso { get; set; }

        public Result(T value, bool primeiroAcesso)
        {
            Value = value;
            PrimeiroAcesso = primeiroAcesso;
        }
    }
}
