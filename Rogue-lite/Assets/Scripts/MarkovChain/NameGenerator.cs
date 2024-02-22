using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NameGenerator : MonoBehaviour
{
    //setup variables
    [SerializeField] private Text nameText;

    private List<KeyValuePair<string, MarkovLink>>
        _markovNamesDictionary = new List<KeyValuePair<string, MarkovLink>>();

    private string _firstName = "The ";

    // Start is called before the first frame update
    void Start()
    {
        //first node
        FirstNode();

        //second node
        SecondNode();

        //third node
        ThirdNode();

        //fourth node
        FourthNode();
    }

    //function that genrate a name
    public void Generate()
    {
        string currentName = _firstName;
        List<KeyValuePair<string, MarkovLink>> availableNames = new List<KeyValuePair<string, MarkovLink>>();
        nameText.text = currentName;

        do
        {
            //will look for the element, order them and make them into a list
            availableNames = _markovNamesDictionary.Where(n => n.Key == currentName)
                .OrderByDescending(n => n.Value.Weight)
                .ToList();
            Color32 colorRng = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255),
                (byte)Random.Range(0, 255), (byte) Random.Range(254, 255));

            int sumWeights = availableNames.Sum(n => n.Value.Weight);

            if (availableNames.Count > 0)
            {
                int rng = Random.Range(0, sumWeights);
                int partialSum = 0;

                foreach (var names in availableNames)
                {
                    partialSum += names.Value.Weight;
                    if (rng < partialSum)
                    {
                        //gg
                        currentName = names.Value.Text;
                        nameText.color = colorRng;
                        break;
                    }
                }

                nameText.text += currentName + "";
            }
        } while (availableNames.Count > 0);
    }

    //all function that adds pairs of strings in the dictionary
    private void FirstNode()
    {
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>("The ", new MarkovLink("Lord", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>("The ", new MarkovLink("Prince", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>("The ", new MarkovLink("King", 1)));
    }

    private void SecondNode()
    {
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>("Prince", new MarkovLink(" of", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>("Lord", new MarkovLink(" of", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>("King", new MarkovLink(" of", 1)));
    }

    private void ThirdNode()
    {
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" of", new MarkovLink(" silver", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" of", new MarkovLink(" golden", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" of", new MarkovLink(" blue", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" of", new MarkovLink(" vanished", 1)));
    }

    private void FourthNode()
    {
        //silver
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" silver", new MarkovLink(" lagoon", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" silver", new MarkovLink(" forest", 1)));
        //golden
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" golden", new MarkovLink(" forest", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" golden", new MarkovLink(" lagoon", 1)));
        //blue
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" blue", new MarkovLink(" lagoon", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" blue", new MarkovLink(" castle", 1)));
        //vanished
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" vanished", new MarkovLink(" lagoon", 1)));
        _markovNamesDictionary.Add(new KeyValuePair<string, MarkovLink>(" vanished", new MarkovLink(" castle", 1)));
    }
}