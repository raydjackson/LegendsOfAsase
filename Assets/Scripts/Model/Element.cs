using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField]
    protected Element[] weaknesses;
    public Element[] Weaknesses { get { return weaknesses; } }
    [SerializeField]
    protected Element[] resistances;
    public Element[] Resistances { get { return resistances; } }
    [SerializeField]
    protected string elementName;
    public string ElementName { get { return elementName; } }
    [SerializeField]
    protected Color elementColor = Color.white;
    public Color ElementColor { get { return elementColor; } }


    public bool IsWeakness(Element attack)
    {
        foreach (Element element in weaknesses)
        {
            if (element == attack)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsResistance(Element attack)
    {
        foreach (Element element in resistances)
        {
            if (element == attack)
            {
                return true;
            }
        }

        return false;
    }
}
