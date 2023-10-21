using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayableCharacter : Character
{
    AI ai;
    protected void Awake()
    {
        base.Awake();
        ai = new AI();
        playable = false;
    }
    // Start is called before the first frame update

}
