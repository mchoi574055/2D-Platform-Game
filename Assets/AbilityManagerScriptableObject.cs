using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AbilityManagerScriptableObject", order = 1)]
public class AbilityManagerScriptableObject : ScriptableObject
{
    public float cooldown;
    public string sdsname;

    public Sprite aSprite;
}