using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Game/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int maxHealth;
    public int maxMana;
    public SkillData[] availableSkills;
    // Add more attributes as needed.
}
