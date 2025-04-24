using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public float damage;
    public float range;
    public Sprite icon;

    public abstract void Execute(GameObject user);
}
