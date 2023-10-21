using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Game/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public SkillType skillType;
    public Target target;
    public string skillDescription;
    public int healthEffect;
    public int cost;
    public AnimationClip animation;
    // Add more attributes as needed.
}