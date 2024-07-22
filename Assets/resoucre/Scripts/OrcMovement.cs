using System;
using UnityEngine;
public class OrcMove : MonoBehaviour
{
   //物理组件 移动
    Rigidbody2D rigibody2D;

    //动画组件
    Animator animator;
    //图片组件
    SpriteRenderer spriteRenderer;

    // 寻路组件
    DetetionZone detetionZone;

    //速度
    public float speed;  

    //攻击力
    public int attackPower;
    //弹开-力
    public float konckbackForce;
    private void Awake(){
        //获取2
        rigibody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        detetionZone=GetComponent<DetetionZone>();
    }


    public void onDamage(){
        animator.SetTrigger("isDamage");
    }

    public void onDie(){
        animator.SetTrigger("isDead");
    }


    public void OnWalk(){
        animator.SetBool("isWalking",true);
    }

    public void OnWalkStop(){
        animator.SetBool("isWalking",false);
    }

    public void onDestory(){
        Destroy(gameObject);
    }

    private void FixedUpdate(){
        if(detetionZone.detectedObjs!=null){
            Vector2 direction=(detetionZone.detectedObjs.transform.position-transform.position);
            if(direction.magnitude<=detetionZone.viewRadius){
                rigibody2D.AddForce(direction.normalized*speed);
                if(direction.x>0){
                    spriteRenderer.flipX=false;
                }else{
                    spriteRenderer.flipX=true;
                }
                OnWalk();
            }
        }else{
            OnWalkStop();
        }
    }

private void OnCollisionEnter2D(Collision2D collision) {
    
    Console.WriteLine("enter2d");
    Collider2D collider2D = collision.collider;
    IDamage damage = collider2D.GetComponent<IDamage>();
    if (damage != null && collider2D.tag == "Player")
    {
        Vector2 dirction = collider2D.transform.position - transform.position;
        Vector2 force = dirction.normalized * konckbackForce;
        damage.OnAttack(attackPower, force);
    }
    
}

}
