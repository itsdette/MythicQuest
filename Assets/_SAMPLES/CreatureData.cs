using UnityEngine;

[CreateAssetMenu(fileName = "NewCreatureData", menuName = "Creature Data", order = 51)]
public class CreatureData : ScriptableObject
{
    public string creatureName;
    public string description;
    public Sprite creatureImage;
}
