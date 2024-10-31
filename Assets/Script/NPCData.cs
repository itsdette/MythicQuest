/*using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCData", menuName = "NPC/NPCData")]
public class NPCData : ScriptableObject
{
    public string npcName;           // Name of the NPC
    public Sprite npcImage;          // Image to display in the interaction scene
    [TextArea] public string npcDescription; // Description or details to display in the interaction scene
    public string interactSceneName;  // Scene to load when the interact button is pressed
    public string fightSceneName;     // Scene to load when the attack button is pressed
}
*/

using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCData", menuName = "NPC/NPCData")]
public class NPCData : ScriptableObject
{
    public string npcName;               // Name of the NPC
    public Sprite npcImage;              // Image to display in the interaction scene
    [TextArea] public string npcDescription; // Description or details to display in the interaction scene
    public string interactSceneName;     // Scene to load when the interact button is pressed
    public string fightSceneName;        // Scene to load when the attack button is pressed
    public int creatureIndex;            // Index of the creature to encounter in battle
}
