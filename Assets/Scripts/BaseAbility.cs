
using UnityEngine;

public class BaseAbility : MonoBehaviour
{
    public AbilityManagerScriptableObject abilityValues;

    float my_cooldown;

    // Start is called before the first frame update
    void Start()
    {
        my_cooldown = abilityValues.cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
