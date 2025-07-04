using System.Text;

namespace treadmill_server.Utils;

public static class StringUtils
{

    public static string FormatHaikuWords(string input, char delimiter = '-')
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        
        var capitalizedWords = input.Split(delimiter)
            .Select(word => string.IsNullOrEmpty(word) 
                ? "" 
                : char.ToUpper(word[0]) + word.Substring(1));

        return string.Join("_", capitalizedWords);
    }
    
    public static string ToPascalCase(string input, char delimiter = '-')
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        
        string[] words = input.Split(delimiter);
        
        var resultBuilder = new StringBuilder();
        
        foreach (var word in words)
        {
            if (string.IsNullOrEmpty(word))
            {
                continue;
            }
            
            resultBuilder.Append(char.ToUpper(word[0]));
            
            if (word.Length > 1)
            {
                resultBuilder.Append(word.Substring(1));
            }
        }
        
        return resultBuilder.ToString();
    }
}