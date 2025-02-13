class Word
{
    private string _word;
    private bool _isHidden = false;

    public Word(string text)
    {
        _word = text;
    }

    public void DisplayWord()
    {
        if (!_isHidden)
        {
            Console.Write($"{_word} ");
        }
        else
        {
            string wordPunctuation = "";
            if (_word.EndsWith("."))
            {
                wordPunctuation = ".";
            }
            else if (_word.EndsWith(","))
            {
                wordPunctuation = ",";
            }
            else if (_word.EndsWith(";"))
            {
                wordPunctuation = ";";
            }
            else if (_word.EndsWith("?"))
            {
                wordPunctuation = "?";
            }
            if (wordPunctuation == "")
            {
                for (int i = 0; i < _word.Length; i++)
                {
                    Console.Write("_");
                }
                Console.Write(" ");
            }
            else
            {
                for (int i = 0; i < (_word.Length - 1); i++)
                {
                    Console.Write("_");
                }
                Console.Write($"{wordPunctuation} ");
            }
        }
    }

    public void HideWord()
    {
        _isHidden = true;
    }

}