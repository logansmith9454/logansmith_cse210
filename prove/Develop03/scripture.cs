using System.Globalization;
using System.IO;
class Scripture
{
    private string _reference;
    private List<Verse> _verses = new List<Verse>();
    private List<Word> _shownWords = new List<Word>();

    public Scripture()
    {
        string[] _scriptures = System.IO.File.ReadAllLines("C:/Users/Smith/cse210/logansmith_cse210/prove/Develop03/scriptures.csv");
        // foreach (var _thing in _scriptures)
        // {
        //     Console.WriteLine(_thing);
        // }
        var _rnd = new Random();
        int _scriptureIndex = _rnd.Next(_scriptures.Count());
        string _selectedScripture = _scriptures[_scriptureIndex];
        string[] _splitScripture = _selectedScripture.Split("`");
        SetReference(_splitScripture[0]);
        string[] _splitVerses = _splitScripture[1].Split("~");
        foreach (string _splitVerse in _splitVerses)
        {
            Verse _verse = new Verse();
            string[] _splitWords = _splitVerse.Split(" ");
            foreach (string _splitWord in _splitWords)
            {
                Word _word = new Word(_splitWord);
                _verse.AddWord(_word);
                AddShownWord(_word);
            }
            AddVerse(_verse);
        }
    }

    public void AddVerse(Verse _verse)
    {
        _verses.Add(_verse);
    }
    public void SetReference(string _ref)
    {
        _reference = _ref;
    }

    public void AddShownWord(Word _word)
    {
        _shownWords.Add(_word);
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"{_reference}");
        foreach (Verse _verse in _verses)
        {
            _verse.DisplayVerse();
        }
    }

    public bool IsFinished()
    {
        if (_shownWords.Count() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveWord()
    {
        var _rnd = new Random();
        int _wordIndex = _rnd.Next(_shownWords.Count());
        Word _wordToHide = _shownWords[_wordIndex];
        _wordToHide.HideWord();
        _shownWords.RemoveAt(_wordIndex);
    }
}