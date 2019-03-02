using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    Player player;

    public GameObject itemPrefab;

    public List<UpgradeObj> upgradableObjs = new List<UpgradeObj>();


    List<GameObject> plugins = new List<GameObject>();

    private void Start()
    {
        player = FindObjectOfType<Player>();

        foreach (Gear gear in player.subMarinGear)
        {
            for (int i = 0; i < gear.GetMaxLevel(); ++i)
            {
                plugins.Add(GameObject.Find("Plugin/" + gear.objectName + (i + 1).ToString()));
                if (gear.currentLevel < i + 1)
                    plugins[plugins.Count - 1].gameObject.SetActive(false);
            }

            if (gear.CanBeUpgrade())
            {
                GameObject obj = Instantiate(itemPrefab, transform);
                UpgradeObj tmp = obj.GetComponent<UpgradeObj>();

                tmp.objName = gear.objectName;
                tmp.gear.sprite.sprite = gear.GetGearUpgradeSprite();
                tmp.gear.data.text = gear.GetGearUpgradeTitle();

                foreach (var required in gear.GetGearUpgradePrerequis())
                    tmp.AddPreRequis(required);
                upgradableObjs.Add(tmp);
            }
        }
    }

    public void Update()
    {
        foreach (var upobj in upgradableObjs)
            if (upobj.click)
            {
                if (player.UpgradeGear(upobj.objName))
                    ChangeEquipement(upobj);
                upobj.click = false;
                return;
            }
    }

    public void ChangeEquipement(UpgradeObj objUI)
    {
        foreach (Gear gear in player.subMarinGear)
            if (objUI.objName == gear.objectName)
            {
                if (gear.CanBeUpgrade())
                {
                    GameObject obj = Instantiate(itemPrefab, transform);
                    UpgradeObj tmp = obj.GetComponent<UpgradeObj>();

                    tmp.objName = gear.objectName;
                    tmp.gear.sprite.sprite = gear.GetGearUpgradeSprite();
                    tmp.gear.data.text = gear.GetGearUpgradeTitle();

                    foreach (var required in gear.GetGearUpgradePrerequis())
                        tmp.AddPreRequis(required);
                    upgradableObjs.Add(tmp);
                }
                for (int i = 0; i < plugins.Count; ++i)
                    if (plugins[i].name == gear.objectName + gear.currentLevel.ToString())
                        plugins[i].SetActive(true);
                break;
            }
        objUI.gameObject.SetActive(false);
        upgradableObjs.Remove(objUI);
        Destroy(objUI.gameObject);
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }
}
