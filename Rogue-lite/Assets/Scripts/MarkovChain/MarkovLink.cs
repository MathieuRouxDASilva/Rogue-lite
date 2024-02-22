//class that will take path and probabilities

public class MarkovLink
{
    public MarkovLink(string text, int weight)
    {
        _text = text;
        _weight = weight;
    }

    private string _text;
    //get _text
    public string Text => _text;
    private int _weight;
    //get _weight
    public int Weight => _weight;
}