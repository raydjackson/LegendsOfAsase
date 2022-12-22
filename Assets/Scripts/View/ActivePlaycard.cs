using UnityEngine;
using TMPro;
using LegendsOfAsaseEnums;

public class ActivePlaycard : Playcard
{
    public TMP_Text speed;
    public TMP_Text techniqueName;

    protected override void SetFields()
    {
        SetSpeed();
        //technique name
        base.SetFields();
    }

    protected override void SetName()
    {
        legendName.text = legend.GetFullName();
    }

    protected void SetSpeed()
    {
        speed.text = $"Speed: {legend.GetSpeed()}";
    }
}
