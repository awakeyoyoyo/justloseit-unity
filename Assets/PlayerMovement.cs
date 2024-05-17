using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //物理组件
    Rigidbody2D rigibody2D;
    //x y 输入
    Vector2 moveInput;
    //速度
    public float moveSpeed;

    Animator animator;

    SpriteRenderer renderer;

    private void Awake(){
        //获取2
        rigibody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        renderer=GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue value){
        //获取输入
        moveInput=value.Get<Vector2>();
        if(moveInput==Vector2.zero){
            animator.SetBool("isWalking",false);
        }else{
            if(moveInput.x>0){
                renderer.flipX=false;
            }else{
                renderer.flipX=true;
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
