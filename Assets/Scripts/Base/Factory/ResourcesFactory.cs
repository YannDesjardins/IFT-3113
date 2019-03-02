using System.Collections.Generic;
using UnityEngine;
using System;


public class ResourcesFactory
{
    public Dictionary<int, KeyValuePair<Sprite, AObject>> objs = new Dictionary<int, KeyValuePair<Sprite, AObject>>();

    public enum ID
    {
        UNKNOW = -1,

        TOILE = 0,
        PLANTE = 1,
        PLANCTON = 2,
        PERLE = 3,
        MUCUS = 4,
        OEIL = 5,
        ECLAT = 6,

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
        return Resources.Load<Sprite>("Resources/" + (int)obj);
    }

    AObject GetObject(ID obj)
    {
        switch (obj)
        {
            case ID.TOILE:
                return new Ressource { objectName = "Toile", description = "Des toiles dans l'eau ?", rarety = AObject.Rarety.EPIC };
            case ID.PLANTE:
                return new Ressource { objectName = "Plante lunaire", description = "Plante crée lors de pleine lune.", rarety = AObject.Rarety.LEGENDARY };
            case ID.PLANCTON:
                return new Ressource { objectName = "Plancton", description = "Petits déchets marin.", rarety = AObject.Rarety.COMMUN };
            case ID.PERLE:
                return new Ressource { objectName = "Perle", description = "Caché un peu partout.", rarety = AObject.Rarety.RARE };
            case ID.MUCUS:
                return new Ressource { objectName = "Mucus", description = "Mucus crée par la pression des fonds marin.", rarety = AObject.Rarety.COMMUN };
            case ID.OEIL:
                return new Ressource { objectName = "Oeil", description = "Les yeux sont ne sont trouvable que sur les monstres dangeureux.", rarety = AObject.Rarety.RARE };
            case ID.ECLAT:
                return new Ressource { objectName = "Eclat solaire", description = "Eclat crée lors d'une éruption solaire.", rarety = AObject.Rarety.LEGENDARY };
        }
        return null;
    }
}
