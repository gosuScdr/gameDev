using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit: MonoBehaviour
{
public string unitName; 
public int unitLevel;
public int damage;
public int maxHp;
public int currentHp;
public Animator ownAnimator;

public bool TakeDamage(int dmg){
    currentHp -=dmg;

if(currentHp<=0)
{
return true;
}
else return false;
}

void stopAnimation(){
    ownAnimator.SetTrigger("move");
}
}
