using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayableCharacter : Character
{
    protected void Awake()
    {
        base.Awake();
        //SetCharacterData(characterData);
        playable = true;

    }
    // Start is called before the first frame update

}
