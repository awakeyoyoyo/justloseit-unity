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
                gameObject.BroadcastMessage("IsFacingRight",true);
            }else{
                renderer.flipX=true;
                gameObject.BroadcastMessage("IsFacingRight",false);

            }
            animator.SetBool("isWalking",true);
        }
    }

    private void FixedUpdate(){
        //增加力量    
        rigibody2D.AddForce(moveInput*moveSpeed);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
