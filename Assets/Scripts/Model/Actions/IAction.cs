using System.Collections;
using System.Collections.Generic;

public interface IAction 
{
    public string GetActionType();

    public void ExecuteFirst(Legend defendingLegend);

    public void ExecuteSecond(Legend defendingLegend);
}
