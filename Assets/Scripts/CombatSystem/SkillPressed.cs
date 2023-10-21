using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPressed : MonoBehaviour
{
    public PlayableCharacter player;

    public int skillIndex;

    CombatSystem CombatSystem;

    public SkillData skillData;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<PlayableCharacter>();
        CombatSystem = FindObjectOfType<CombatSystem>();
        skillIndex =int.Parse(gameObject.name[6].ToString())-1;
        skillData = player.characterData.availableSkills[skillIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressed()
    {
        CombatSystem.ProcessTurn(skillData);
    }
}
