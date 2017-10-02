using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Smartphone : IBrowsable, ICallable
{
    public string Browse(string website)
    {

        bool hasDigit = website.Any(char.IsDigit);
        if (hasDigit)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Invalid URL!");
            return sb.ToString();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Browsing: {website}!");
            return sb.ToString();
        }
    }

    public string Call(string phone)
    {
        bool hasCharacter = phone.Any(char.IsLetter);
        if (hasCharacter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Invalid number!");
            return sb.ToString();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Calling... {phone}");
            return sb.ToString();
        }
    }
}

