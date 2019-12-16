﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAI : MonoBehaviour
{
    Animator anim;
    float projectileTimer = 4.5f;
    float defaultProjectileTimer = 4.5f;
    void Awake()
    {
        projectileTimer = defaultProjectileTimer;
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        projectileTimer -= Time.deltaTime;
        if(projectileTimer <= 0){
            anim.SetTrigger("AiProjectileLauncher");
            projectileTimer = defaultProjectileTimer;
        }
    }

    public void SpawnFireBall(){

    }
}
