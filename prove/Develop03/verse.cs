class Verse
{
    private List<Word> _words = new List<Word>();

    public void AddWord(Word _word)
    {
        _words.Add(_word);
    }

    public void DisplayVerse()
    {
        foreach (Word _word in _words)
        {
            _word.DisplayWord();
        }
        Console.WriteLine();
    }
}