using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeStateManager : MonoBehaviour
{
    public class FreezeAnimTimers{

        public float c1Time;
        public float c2Time;
        public float c3Time;
        public float c4Time;
        public float dashTime;
        public float icePillar;
    }
    Animator anim;
    FreezeAnimTimers animTimers;
    void Start()
    {
        anim = GetComponent<Animator>();
        animTimers = new FreezeAnimTimers();
        getAnimTimers();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void getAnimTimers(){
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "Combo 1":
                    animTimers.c1Time = clip.length;
                    break;
                case "Combo 2":
                    animTimers.c2Time = clip.length;
                    break;
                case "Combo 3":
                    animTimers.c3Time = clip.length;
                    break;
                case "Combo 4":
                    animTimers.c4Time = clip.length;
                    break;
                case "Dash":
                    animTimers.dashTime = clip.length;
                    break;
                case "Ice Pillar":
                    animTimers.icePillar = clip.length;
                    break;
            }
        }
    }
}
