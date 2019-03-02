using System.Collections.Generic;
using UnityEngine;
using System;


public class GearsFactory
{
    public Dictionary<int, AObject> objs = new Dictionary<int, AObject>();

    public enum ID
    {
        UNKNOW = -1,

        STOCKAGE = 1,

        ARMOR = 2,

        BATTERY = 3,

        TASER = 4,

        PROPULSEUR = 5,

        LENGTH
    }

    public void InitializeFactory()
    {
        for (int id = -1; id < (int)ID.LENGTH; ++id)
            objs.Add(id, GetObject((ID)id));
    }

    Sprite GetSprite(ID obj)
    {
        if (obj == ID.UNKNOW)
            return null;
        return Resources.Load<Sprite>("Gears/" + (int)obj);
    }

    AObject GetObject(ID obj)
    {
        switch (obj)
        {
            case ID.STOCKAGE:
                {
                    Gear gear = new Gear();

                    gear.objectName = "Storage";

                    Gear.UpgradeCondition upgradeCondLvl1 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl2 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl3 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl4 = new Gear.UpgradeCondition();

                    // lvl 1
                    upgradeCondLvl1.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 1.ToString());
                    upgradeCondLvl1.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl1.prerequis.Add(new Gear.Prerequis { ressourceID = 1, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 1, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl1);

                    // lvl 2
                    upgradeCondLvl2.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 2.ToString());
                    upgradeCondLvl2.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl2.prerequis.Add(new Gear.Prerequis { ressourceID = 2, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 2, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl2);

                    // lvl 3
                    upgradeCondLvl3.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 3.ToString());
                    upgradeCondLvl3.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl3.prerequis.Add(new Gear.Prerequis { ressourceID = 3, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 3, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl3);

                    // lvl 4
                    upgradeCondLvl4.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 4.ToString());
                    upgradeCondLvl4.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl4.prerequis.Add(new Gear.Prerequis { ressourceID = 6, nbr = 1 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 4, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl4);
                    return gear;
                }
            case ID.ARMOR:
                {
                    Gear gear = new Gear();

                    gear.objectName = "Armor";

                    Gear.UpgradeCondition upgradeCondLvl1 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl2 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl3 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl4 = new Gear.UpgradeCondition();

                    // lvl 1
                    upgradeCondLvl1.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 1.ToString());
                    upgradeCondLvl1.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl1.prerequis.Add(new Gear.Prerequis { ressourceID = 1, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 1, energy = 0, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl1);

                    // lvl 2
                    upgradeCondLvl2.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 2.ToString());
                    upgradeCondLvl2.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl2.prerequis.Add(new Gear.Prerequis { ressourceID = 2, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 2, energy = 0, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl2);

                    // lvl 3
                    upgradeCondLvl3.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 3.ToString());
                    upgradeCondLvl3.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl3.prerequis.Add(new Gear.Prerequis { ressourceID = 3, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 3, energy = 0, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl3);

                    // lvl 4
                    upgradeCondLvl4.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 4.ToString());
                    upgradeCondLvl4.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl4.prerequis.Add(new Gear.Prerequis { ressourceID = 6, nbr = 1 });
                    gear.caracteristics.Add(new Caracteristic { armor = 4, energy = 0, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl4);
                    return gear;
                }
            case ID.BATTERY:
                {
                    Gear gear = new Gear();

                    gear.objectName = "Battery";

                    Gear.UpgradeCondition upgradeCondLvl1 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl2 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl3 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl4 = new Gear.UpgradeCondition();

                    // lvl 1
                    upgradeCondLvl1.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 1.ToString());
                    upgradeCondLvl1.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl1.prerequis.Add(new Gear.Prerequis { ressourceID = 1, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 1, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl1);

                    // lvl 2
                    upgradeCondLvl2.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 2.ToString());
                    upgradeCondLvl2.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl2.prerequis.Add(new Gear.Prerequis { ressourceID = 2, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 2, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl2);

                    // lvl 3
                    upgradeCondLvl3.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 3.ToString());
                    upgradeCondLvl3.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl3.prerequis.Add(new Gear.Prerequis { ressourceID = 3, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 3, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl3);

                    // lvl 4
                    upgradeCondLvl4.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 4.ToString());
                    upgradeCondLvl4.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl4.prerequis.Add(new Gear.Prerequis { ressourceID = 6, nbr = 1 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 4, propulsion = 0, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl4);
                    return gear;
                }
            case ID.TASER:
                {
                    Gear gear = new Gear();

                    gear.objectName = "Taser";

                    Gear.UpgradeCondition upgradeCondLvl1 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl2 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl3 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl4 = new Gear.UpgradeCondition();

                    // lvl 1
                    upgradeCondLvl1.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 1.ToString());
                    upgradeCondLvl1.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl1.prerequis.Add(new Gear.Prerequis { ressourceID = 1, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 0, taser = 1 });
                    gear.levelPreRequis.Add(upgradeCondLvl1);

                    // lvl 2
                    upgradeCondLvl2.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 2.ToString());
                    upgradeCondLvl2.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl2.prerequis.Add(new Gear.Prerequis { ressourceID = 2, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 0, taser = 2 });
                    gear.levelPreRequis.Add(upgradeCondLvl2);

                    // lvl 3
                    upgradeCondLvl3.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 3.ToString());
                    upgradeCondLvl3.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl3.prerequis.Add(new Gear.Prerequis { ressourceID = 3, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 0, taser = 3 });
                    gear.levelPreRequis.Add(upgradeCondLvl3);

                    // lvl 4
                    upgradeCondLvl4.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 4.ToString());
                    upgradeCondLvl4.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl4.prerequis.Add(new Gear.Prerequis { ressourceID = 6, nbr = 1 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 0, storage = 0, taser = 4 });
                    gear.levelPreRequis.Add(upgradeCondLvl4);
                    return gear;
                }
            case ID.PROPULSEUR:
                {
                    Gear gear = new Gear();

                    gear.objectName = "Propulseur";

                    Gear.UpgradeCondition upgradeCondLvl1 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl2 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl3 = new Gear.UpgradeCondition();
                    Gear.UpgradeCondition upgradeCondLvl4 = new Gear.UpgradeCondition();

                    // lvl 1
                    upgradeCondLvl1.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 1.ToString());
                    upgradeCondLvl1.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl1.prerequis.Add(new Gear.Prerequis { ressourceID = 1, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 1, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl1);

                    // lvl 2
                    upgradeCondLvl2.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 2.ToString());
                    upgradeCondLvl2.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl2.prerequis.Add(new Gear.Prerequis { ressourceID = 2, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 2, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl2);

                    // lvl 3
                    upgradeCondLvl3.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 3.ToString());
                    upgradeCondLvl3.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl3.prerequis.Add(new Gear.Prerequis { ressourceID = 3, nbr = 5 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 3, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl3);

                    // lvl 4
                    upgradeCondLvl4.sprite = Resources.Load<Sprite>("Gears/" + gear.objectName + 4.ToString());
                    upgradeCondLvl4.prerequis = new List<Gear.Prerequis>();
                    upgradeCondLvl4.prerequis.Add(new Gear.Prerequis { ressourceID = 6, nbr = 1 });
                    gear.caracteristics.Add(new Caracteristic { armor = 0, energy = 0, propulsion = 4, storage = 0, taser = 0 });
                    gear.levelPreRequis.Add(upgradeCondLvl4);
                    return gear;
                }
        }
        return null;
    }
}
