using UnityEngine;
using System.Collections.Generic;
public class Character : MonoBehaviour
{
    public CharacterData characterData;

    public int currentHealth;
    public int currentMana;

    protected bool playable;
    public List<SkillData> skillList = new List<SkillData>();
    
    protected void Awake()
    {

        // Initialize character attributes from CharacterData.
        currentHealth = characterData.maxHealth;
        currentMana = characterData.maxMana;

        foreach (SkillData skill in characterData.availableSkills)
        {
            skillList.Add(skill); }

    }

    public void EffectedWith(SkillData skill)
    {currentHealth += skill.healthEffect; }

    public int GetMana()
    { return currentMana; }
    public void ReduceMana(int amount)
    { currentMana -= amount;}
    public void AddMana(int amount)
    { currentMana += amount;}
    public int GetHealth()
    { return currentHealth; }
    public int GetMaxHealth()
    { return characterData.maxHealth; }
}
