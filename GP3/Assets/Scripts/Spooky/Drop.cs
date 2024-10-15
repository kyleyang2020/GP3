using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// make it so that we can make loot objects from the unity project rather than code
// just right click in assets and loot should pop up since its a scriptable object
[CreateAssetMenu]
public class Drop : ScriptableObject
{
    public Sprite dropSprite;
    public string dropName;
    public int dropChance; // 1-100

    // allows usage of loot class in other scripts, creating loot
    public Drop(string dropName, int dropChance)
    {
        this.dropName = dropName;
        this.dropChance = dropChance;
    }
}
