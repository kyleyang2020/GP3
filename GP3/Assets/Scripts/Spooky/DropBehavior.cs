using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehavior : MonoBehaviour
{
    // put something here as default drop
    public GameObject droppedItemPrefab;
    public List<Drop> dropList = new List<Drop>();

    void Start()
    {
        // this is using the constructor made in loot script
        // think back to 235 class

        // you can do this way in code or using scriptable obj
        //lootList.Add(new Loot("Gem", 80));
    }

    // by uncommenting, you can make the bag/enemy drop multiple items rather than one
    List<Drop> GetDroppedItems()
    {
        int randomNum = Random.Range(1, 101); // 1-100
        List<Drop> possibleItems = new List<Drop>();

        foreach (Drop item in dropList)
        {
            if (randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
                //*return possibleItems;
            }
            if (possibleItems.Count == 10) { return possibleItems; }
        }
        return possibleItems;
    }

    Drop GetDroppedItem()
    {
        int randomNum = Random.Range(1, 101); // 1-100
        List<Drop> possibleItems = new List<Drop>();

        foreach (Drop item in dropList)
        {
            if (randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
                //*return possibleItems;
            }
        }

        if (possibleItems.Count > 0)
        {
            // this make it randomly choose a random item, but can be changed
            // to drop the better loot or worst loot
            Drop droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        // this happens when there is no loot with 100% drop chance
        Debug.Log("no loot dropped");
        return null;
    }

    public void InstantiateDrop(Vector3 spawnPosition, bool isOneDrop)
    {
        // if we are doing multiple drops
        List<Drop> droppedItems = GetDroppedItems();
        Drop droppedItem = GetDroppedItem();

        // in case when there is no loot, dont run, also check for when it's one item or multiple
        if (droppedItem != null && isOneDrop)
        {
            // spawn the loot with its own sprite at the position it was dropped
            GameObject dropGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            dropGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.dropSprite;

            // here you add animation and flare to make it look nice
            // here we added a dropforce in a random dropdirection and shoot it there
            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            dropGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
        if (droppedItem != null && !isOneDrop)
        {
            for(int i = 0; i < droppedItems.Count; i++)
            {
                // spawn the loot with its own sprite at the position it was dropped
                GameObject dropGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
                dropGameObject.GetComponent<SpriteRenderer>().sprite = droppedItems[i].dropSprite;

                // here you add animation and flare to make it look nice
                // here we added a dropforce in a random dropdirection and shoot it there
                float dropForce = 300f;
                Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                dropGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
            }
        }
    }
}
