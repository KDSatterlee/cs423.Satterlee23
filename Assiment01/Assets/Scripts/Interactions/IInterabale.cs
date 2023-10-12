using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterabale 
{
    public string InteractPromp { get;  }

    public bool InterACT(Interactor interactor);
}
