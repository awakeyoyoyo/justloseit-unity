using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    //物理组件 移动
    BoxCollider2D collider2;
    //改变刀刚体的位置
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        collider2=GetComponentInParent<BoxCollider2D>();
        //相对于父节点的位置
        position=transform.localPosition;
    }

    void IsFacingRight(bool isFacingRight){
        if(isFacingRight){
            transform.localPosition=position;
            Debug.Log(collider2.size.x);

        }else{
            Debug.Log(collider2.size.x);
            transform.localPosition=new Vector3(-position.x-collider2.size.x,position.y,position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
