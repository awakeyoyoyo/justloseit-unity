using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

    private void Awake(){
        //获取2
        rigibody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        detetionZone=GetComponent<DetetionZone>();
    }


    public void OnWalk(){
        animator.SetBool("isWalking",true);
    }

    public void OnWalkStop(){
        animator.SetBool("isWalking",false);
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
}
