using System.Collections.Generic;
using UnityEngine;

public class Gear : AObject
{
    public struct Prerequis
    {
        public int ressourceID;
        public int nbr;
    }

    public struct UpgradeCondition
    {
        public Sprite sprite;
        public List<Prerequis> prerequis;
    }

    public List<Caracteristic> caracteristics = new List<Caracteristic>();

    public List<UpgradeCondition> levelPreRequis = new List<UpgradeCondition>();

    public int currentLevel = 0;
    public Caracteristic currentCaracteristic = new Caracteristic();

    public Gear()
    {
        this.categorie = Categorie.GEAR;
        currentCaracteristic.armor = 0;
        currentCaracteristic.energy = 0;
        currentCaracteristic.propulsion = 0;
        currentCaracteristic.storage = 0;
        currentCaracteristic.taser = 0;
    }

    public void Upgrade()
    {
        currentLevel += 1;
        if (currentLevel < levelPreRequis.Count)
            currentCaracteristic = caracteristics[currentLevel];
    }

    public string GetGearUpgradeTitle()
    {
        return objectName + " lvl " + (currentLevel + 1).ToString();
    }

    public Sprite GetGearUpgradeSprite()
    {
        return levelPreRequis[currentLevel].sprite;
    }

    public List<Prerequis> GetGearUpgradePrerequis()
    {
        return levelPreRequis[currentLevel].prerequis;
    }

    public int GetMaxLevel()
    {
        return levelPreRequis.Count;
    }

    public bool CanBeUpgrade()
    {
        return currentLevel < levelPreRequis.Count;
    }
}
