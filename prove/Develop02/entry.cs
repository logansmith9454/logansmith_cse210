class Entry
{
    public string _date;
    public string _prompt;
    public string _text;

    public void DisplayEntry()
    /*
    Displays all values for the entry.

    Parameters: none

    Returns: none
    */
    {
        Console.WriteLine($"\nDate: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Text: {_text}\n");
    }
}