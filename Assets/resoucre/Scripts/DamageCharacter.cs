using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCharacter : MonoBehaviour,IDamage

{

    Rigidbody2D rigidbody2;
    Collider2D physicsCollider;

    Animator animator;

    public int health;

    public bool isDead;
   
    private void Awake(){
        //获取2
        rigidbody2=GetComponent<Rigidbody2D>();
        physicsCollider=GetComponent<Collider2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack(int damage,Vector2 knockback){
        rigidbody2.AddForce(knockback);
        health=health-damage;
        if(health<=0){
            gameObject.BroadcastMessage("onDie");
            isDead=true;
            rigidbody2.simulated=false;
        }else{
            gameObject.BroadcastMessage("onDamage");
        }
    }


    public void OnObjectDestory(){
       gameObject.BroadcastMessage("onDestory");
    }

}
