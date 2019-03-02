using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceObj : MonoBehaviour {

    public float life = 100;
    public ResourcesFactory.ID id;
    public int quantity = 5;

    bool isAttack = false;

    Player ressourceTarget = null;

    private void Start()
    {
        life = ((Ressource)Manager.GetItem(new Object { id = (int)this.id, categorie = AObject.Categorie.RESSOURCE, quantity = this.quantity }).Value).life;
    }

    public void TakeDamage(bool attack, Player player)
    {
        isAttack = attack;
        ressourceTarget = player;
    }

    public void Update()
    {
        if (isAttack)
        {
            life -= 10f * Time.deltaTime;
        }
        if (life <= 0f)
        {
            gameObject.SetActive(false);
            if (ressourceTarget != null)
                ressourceTarget.inventory.AddRessource(id, quantity);
        }
    }
}
