using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //运动组件
    Rigidbody2D rigibody2D;
    //x y 输入
    Vector2 moveInput;
    //动画组件
    Animator animator;
    //图片组件
    SpriteRenderer renderer;

        //速度
    public float moveSpeed;

    public bool facingRightFlag=true;

    private void Awake(){
        //获取2
        rigibody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        renderer=GetComponent<SpriteRenderer>();
    }

    private void OnFire(){
        animator.SetTrigger("swordAttack");
    }

    private void OnMove(InputValue value){
        //获取输入
        moveInput=value.Get<Vector2>();
        if(moveInput==Vector2.zero){
            animator.SetBool("isWalking",false);
        }else{
            if(moveInput.x>0){
                renderer.flipX=false;
                facingRightFlag=true;
                gameObject.BroadcastMessage("IsFacingRight",true);
            }else{
                renderer.flipX=true;
                facingRightFlag=false;
                gameObject.BroadcastMessage("IsFacingRight",false);

            }
            animator.SetBool("isWalking",true);
        }
    }

    private void FixedUpdate(){
        //增加力量    
        rigibody2D.AddForce(moveInput*moveSpeed);
    }


    public void onDamage()
    {
        animator.SetTrigger("isDamage");
    }

    public void onDie()
    {
        animator.SetTrigger("isDie");
    }

    public void onDestory()
    {
        Destroy(gameObject);
    }


}
