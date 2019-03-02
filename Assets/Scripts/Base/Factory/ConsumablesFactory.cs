using System.Collections.Generic;
using UnityEngine;
using System;


public class ConsumablesFactory
{
    public Dictionary<int, KeyValuePair<Sprite, AObject>> objs = new Dictionary<int, KeyValuePair<Sprite, AObject>>();

    public enum ID
    {
        UNKNOW = -1,

        WOOD = 0,
        STONE = 1,

        LENGTH
    }

    public void InitializeFactory()
    {
        for (int id = -1; id < (int)ID.LENGTH; ++id)
            objs.Add(id, new KeyValuePair<Sprite, AObject>(GetSprite((ID)id), GetObject((ID)id)));
    }

    Sprite GetSprite(ID obj)
    {
        if (obj == ID.UNKNOW)
            return null;
        return Resources.Load<Sprite>("Consumables/" + (int)obj);
    }

    AObject GetObject(ID obj)
    {
        switch (obj)
        {
            case ID.WOOD:
                return new Ressource { objectName = "Wood", description = "Wood is used to build.", rarety = AObject.Rarety.COMMUN };
            case ID.STONE:
                return new Ressource { objectName = "Stone", description = "Stone is used to build.", rarety = AObject.Rarety.COMMUN };
        }
        return null;
    }
}
