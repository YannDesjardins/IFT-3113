using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    static Manager instance = null;
    public static GearsFactory          gearsFactory = new GearsFactory();
    public static ConsumablesFactory    consumablesFactory = new ConsumablesFactory();
    public static ResourcesFactory      resourcesFactory = new ResourcesFactory();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
        gearsFactory.InitializeFactory();
        consumablesFactory.InitializeFactory();
        resourcesFactory.InitializeFactory();
    }

    public static KeyValuePair<Sprite, AObject> GetItem(Object obj)
    {
        if (obj.categorie == AObject.Categorie.CONSUMABLE)
            return consumablesFactory.objs[obj.id];
        else if (obj.categorie == AObject.Categorie.RESSOURCE)
            return resourcesFactory.objs[obj.id];
        else
            return resourcesFactory.objs[obj.id];
    }
}
