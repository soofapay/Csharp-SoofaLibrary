namespace Soofa
{
    public interface ISoofaPay
    {
        Balance GetBalance();
        Transaction GetTransaction(string transaction_Id);
    }
}