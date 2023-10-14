using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Game/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public int damage;
    public int cost;
    public AnimationClip animation;
    // Add more attributes as needed.
}