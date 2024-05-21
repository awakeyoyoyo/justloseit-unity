using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetetionZone : MonoBehaviour
{   
    //搜索半径
    public float viewRadius;
    //层级
    public LayerMask playerLayerMask;
    //查找到的刚体
    public Collider2D detectedObjs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider=Physics2D.OverlapCircle(transform.position,viewRadius,playerLayerMask);
    
        detectedObjs=collider;
    
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,viewRadius);
    }
}
