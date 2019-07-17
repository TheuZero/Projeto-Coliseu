using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{

    public float repeatRate = 0.1f;
    public float lifeTime = 0.3f;
    public float alphaDecrement = 0.7f;
    public float red = 0;
    public float green = 255;
    public float blue = 255;

    void Start()
    {
        InvokeRepeating("SpawnTrailPart", 0, repeatRate);
    }
    
    void SpawnTrailPart()
    {
        GameObject trailPart = new GameObject();
        SpriteRenderer trailPartRenderer = trailPart.AddComponent<SpriteRenderer>();
        trailPartRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
        trailPart.transform.position = transform.position;
        trailPart.transform.localScale = transform.localScale;
        trailPartRenderer.color = new Color(red,green,blue);
    
        StartCoroutine(FadeTrailPart(trailPartRenderer));
        Destroy(trailPart, lifeTime); 
    }
    
    IEnumerator FadeTrailPart(SpriteRenderer trailPartRenderer)
    {
        Color color = trailPartRenderer.color;
        color.a -= alphaDecrement;
        trailPartRenderer.color = color;
    
        yield return new WaitForEndOfFrame();
    }
}
