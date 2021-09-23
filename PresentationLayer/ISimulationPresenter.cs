using System;
using System.Collections.Generic;
using System.Drawing;

public interface ISimulationPresenter
{

    IList<Action<Graphics>> GetScene(); 

}
