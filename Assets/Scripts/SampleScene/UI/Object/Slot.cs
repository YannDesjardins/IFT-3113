using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Object                      obj = new Object();
    Image                       img;
    Text                        quantity;

    public int              uid = -1;

    public void Start()
    {
        img = transform.GetComponentInChildren<DragObject>(true).gameObject.GetComponent<Image>();
        quantity = img.gameObject.GetComponentInChildren<Text>(true);
        Assign(obj);
    }

    public bool Assign(Object newObj)
    {
        KeyValuePair<Sprite, AObject> itemData;

        if (newObj.id == -1)
            return true;
        itemData = Manager.GetItem(newObj);
        obj.categorie = newObj.categorie;
        obj.id = newObj.id;
        obj.quantity = newObj.quantity;
        img.gameObject.SetActive(obj.id != -1);
        img.overrideSprite = itemData.Key;
        quantity.text = obj.quantity.ToString();
        quantity.gameObject.SetActive(obj.quantity > 1);

        return true;
    }

    public void Clear()
    {
        obj.id = -1;
        obj.quantity = 1;
        img.gameObject.SetActive(false);
        img.overrideSprite = null;
    }
}
