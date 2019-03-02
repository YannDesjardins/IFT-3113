using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject entity;
    public int comportement_type = 0; // 0 passif, 1 agressif, 2 fuyard, 3 speciale

    private GameObject player;
    private float speed_enemy = 0.015f;
    private Vector3 spawnPosition;
    private bool bmovement = false;

    private int nextRotateIn = 0;
    private Quaternion newRotation;
    private int rotateFrame = 0;

    private float distanceOnAction = 8f;

    void Start()
    {
        GetObjPlayer();
        spawnPosition = this.transform.position;
        Initialise_aptitude();
        InvokeRepeating("Comportement", .01f, 0.1f);
    }

    void Initialise_aptitude()
    {
        if (comportement_type == 0)
        {
            speed_enemy = 0.015f;
        }
        else if (comportement_type == 1)
        {
            speed_enemy = 0.010f;
            distanceOnAction = 12f;
        }
        else if (comportement_type == 2)
        {
            speed_enemy = 0.010f;
            distanceOnAction = 5f;
        }
    }

    void Comportement()
    {
        float distanceFromPlayer = Distance_from(player.transform.position);

        speed_enemy = 0.015f;
        if (distanceFromPlayer < distanceOnAction && comportement_type != 0)// Le joueur est très proche -> comportement actif
        {
            bmovement = true;
            if (comportement_type == 1)//agressif (avance vers le player)
            {
                //this.transform.LookAt(Random.Range(1.95f, 2.05f) * this.transform.position - player.transform.position);
                this.transform.LookAt(player.transform.position);
                //newRotation = Quaternion.LookRotation(player.transform.position - this.transform.position);
                //rotateFrame = 10;
                speed_enemy = 0.07f;
                
            }
            else if (comportement_type == 2)//fuyard (part dans la direction opossé au joueur)
            {
                newRotation = Quaternion.LookRotation(-(player.transform.position - this.transform.position));
                rotateFrame = 10;
                //this.transform.LookAt(player.transform.position);
                speed_enemy = 0.2f;
            }
        }
        else if (Distance_from(spawnPosition) > 20f)// On se redirige vers le spawn
        {
            bmovement = true;
            this.transform.LookAt(spawnPosition);
            speed_enemy = 0.05f;
        }
        else if (distanceFromPlayer < 50f || comportement_type == 0)// Le joueur est suffisamment proche -> comportement passif
        {
            entity.SetActive(true);
            bmovement = true;
            if (nextRotateIn == 0)
            {
                newRotation = Random.rotation;
                rotateFrame = 10;
                nextRotateIn = Random.Range(30, 100);
            }
            else
            {
                nextRotateIn--;
            }
        }
        else// Le joueur se trouve trop loin, on desactive les deplacements
        {
            bmovement = false;
            entity.SetActive(false);
        }    
    }

    void GetObjPlayer()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject obj in objs)
            player = obj;
    }

    float   Distance_from(Vector3 target)
    {
        return (Vector3.Distance(this.transform.position, target));
    }
    void    Update ()
    {
        if (bmovement == true)
            this.transform.position += this.transform.forward * speed_enemy;
        if (rotateFrame > 0)
        {
            this.transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 5 * Time.deltaTime);
            rotateFrame--;
        }
    }
}
