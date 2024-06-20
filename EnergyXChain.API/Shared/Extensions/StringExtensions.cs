namespace EnergyXChain.API.Shared.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string? text)
    {
        static IEnumerable<char> Convert(IEnumerator<char> letterEnumerator)
        {
            // Validation for ensuring database tables were created.
            if(!letterEnumerator.MoveNext())
                yield break;

            yield return char.ToLower(letterEnumerator.Current);
            while (letterEnumerator.MoveNext())
            {
                if (char.IsUpper(letterEnumerator.Current))
                    yield return '_';
                yield return char.ToLower(letterEnumerator.Current);
            }
        }
        return new string(Convert(text!.GetEnumerator()).ToArray());
    }

    public static string Capitalize(this string text)
    {
        return text[0].ToString().ToUpper() + text.Substring(1).ToLower();
    }

    public static string ToSpaceSeparated1(this string text)
    {
        static IEnumerable<char> Convert(IEnumerator<char> letterEnumerator)
        {
            if (!letterEnumerator.MoveNext())
                yield break;
            yield return char.ToLower(letterEnumerator.Current);
            while (letterEnumerator.MoveNext())
            {
                if (char.IsUpper(letterEnumerator.Current))
                    yield return ' ';
                yield return letterEnumerator.Current;
            }
        }
        return new string(Convert(text!.GetEnumerator()).ToArray());
    }

    public static string ToFirstLetterLower(this string text)
    {
        string firstLetter = Char.ToLower(text[0]).ToString();
        string subString = text.Substring(1);
        return firstLetter + subString;
    }
    public static string UpperCamelCaseToSeparatedSpace(this string text)
    {
        static IEnumerable<char> Convert(IEnumerator<char> letterEnumerator)
        {
            if (!letterEnumerator.MoveNext())
                yield break;
            yield return Char.ToUpper(letterEnumerator.Current);
            while (letterEnumerator.MoveNext())
            {
                if (char.IsUpper(letterEnumerator.Current))
                    yield return ' ';
                yield return letterEnumerator.Current;
            }
        }
        return new string(Convert(text!.GetEnumerator()).ToArray());
    }
    
    public static string SeparatedSpaceToUpperCamelCase(this string text)
    {
        static IEnumerable<char> Convert(IEnumerator<char> letterEnumerator)
        {
            if (!letterEnumerator.MoveNext())
                yield break;
            yield return letterEnumerator.Current;
            while (letterEnumerator.MoveNext())
            {
                if (letterEnumerator.Current == ' ')
                    letterEnumerator.MoveNext();
                yield return letterEnumerator.Current;
            }
        }
        return new string(Convert(text!.GetEnumerator()).ToArray());
    }
}