using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    public GameObject projectile;
    void ProjectileEnable(){
        projectile.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
