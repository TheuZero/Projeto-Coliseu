using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status : MonoBehaviour, IHpNotifier
{
    public int playerNumber;
    public float hp;
    public float maxHp = 30;
    float mp;
    public float maxMp;
    public float timeFactor = 1;


    public bool canMove;
    public bool canAttack;
    public bool canSpecial;

    Animator anim;
    AnimatorStateInfo stateInfo;
    AnimatorStateInfo previousStateInfo;

    [SerializeField]
    public List<IHpListener> hpListeners = new List<IHpListener>();

    int baseTag;
    void Start()
    {
        hp = maxHp;
        anim = GetComponent<Animator>();
        baseTag = Animator.StringToHash("Base");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            ReduceHp(5f);
        }
    }
    void FixedUpdate(){
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.fullPathHash != previousStateInfo.fullPathHash){
            if(stateInfo.tagHash == baseTag){
                canMove = true;
                canAttack = true;
                canSpecial = true;
            }
        }
        previousStateInfo = anim.GetCurrentAnimatorStateInfo(0);
    }

    public void DisableActions(){
        canAttack = false;
        canMove = false;
        canSpecial = false;  
    }

    public void ReduceHp(float damage){
        hp -= damage;
        NotifyOnHpChange(hpListeners, playerNumber);
    }

    public IEnumerator FreezeCharacter(float duration){
        while(duration > 0){
            duration -= Time.deltaTime;
            timeFactor = 0;
            anim.speed = 0;
            yield return null;
        }
        timeFactor = 1;
        anim.speed = 1;
    }

    public IEnumerator SlowCharacter(float slow, float duration){
        while(duration > 0){
            duration -= Time.deltaTime;
            timeFactor = 1 - slow;
            anim.speed = 1 - slow;
            yield return null;
        }
        timeFactor = 1;
        anim.speed = 1;
    }

    public void AttachHpListeners(IHpListener listener){
        hpListeners.Add(listener);
    }
    public void AttachListHpListeners(List<IHpListener> listeners){
        foreach (IHpListener listener in listeners){
            hpListeners.Add(listener);
        }
    }
    public void DetachHpListeners(List<IHpListener> listener){
        foreach (IHpListener listeners in listener){
            hpListeners.Remove(listeners);
        }
    }
    public void NotifyOnHpChange(List<IHpListener> listener, int playerNumber){
        foreach (IHpListener listeners in listener){
            listeners.OnHpChange(hp, maxHp, playerNumber);
        }
    }

}

