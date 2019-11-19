using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames : MonoBehaviour
{
    public float iFrameDuration = 1.3f;
    public float transparencyInterval = 0.05f;
    public GameObject hurtBox;
    public SpriteRenderer sprite;
    Color nColor = new Color(1,1,1,1);
    Color iColor = new Color(1,1,1,0.3f);

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")){
            StartCoroutine(Invulnerability());
        }
    }

    public IEnumerator Invulnerability(){

        float duration = iFrameDuration;
        StartCoroutine(Transparency(duration));
        while(duration > 0){
            hurtBox.SetActive(false);
            duration -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        hurtBox.SetActive(true);
        yield break;
    }

    public IEnumerator Transparency(float duration){
        while(duration > 0){
            sprite.color = iColor;
            duration -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        sprite.color = nColor;
        yield break;
    }
}
