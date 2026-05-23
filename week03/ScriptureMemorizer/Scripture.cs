
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordTexts = text.Split(' ');
        foreach (string word in wordTexts)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                _words.Add(new Word(word));
            }
        }
    }
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return string.Join(" ", displayWords);
    }
    public string GetReference()
    {
        return _reference.GetReference();
    }
    public void HideRandomWord()
    {
        List<int> unhiddenIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                unhiddenIndices.Add(i);
            }
        }
        if (unhiddenIndices.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(unhiddenIndices.Count);
            int wordIndex = unhiddenIndices[randomIndex];
            _words[wordIndex].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    public int GetWordCount()
    {
        return _words.Count;
    }
    public int GetHiddenWordCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }
}