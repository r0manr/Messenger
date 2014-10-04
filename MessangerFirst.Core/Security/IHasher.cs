namespace MessangerFirst.Core.Security
{
    //Интерейс шифрования
    public interface IHasher
    {
        string Encrypt(string original);
        bool CompareStringToHash(string s, string hash);
    }
}
