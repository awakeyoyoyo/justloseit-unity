using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSowrd2 : MonoBehaviour
{
  //物理组件 移动
    public BoxCollider2D collider2;
    //改变刀刚体的位置
    Vector3 position;
    //攻击力
    private int attackPower;
    //弹开的力度
    public int konckbackForce;
    void Awake()
    {
        collider2=GetComponent<BoxCollider2D>();
        //相对于父节点的位置
        position=transform.localPosition;
    }

    void IsFacingRight(bool isFacingRight){
        if(isFacingRight){
            transform.localPosition=position;

        }else{
            transform.localPosition=new Vector3(-position.x,position.y,position.z);
        }
    }

    //撞刀上了
    private void OnTriggerEnter2D(Collider2D collider2D){
        IDamage idamage=collider2D.GetComponent<IDamage>();
        if(idamage!=null){
            //主角位置
            Vector3 parentVector3=transform.parent.position;
            //被攻击物体坐标-主角坐标 计算力的方向
            Vector2 direction=collider2.transform.position-parentVector3;
            attackPower=1;
            idamage.OnAttack(attackPower,direction.normalized*konckbackForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
