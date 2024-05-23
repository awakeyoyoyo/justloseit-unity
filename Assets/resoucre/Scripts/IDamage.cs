using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
   public void OnAttack(int damage,Vector2 knockback);
}
