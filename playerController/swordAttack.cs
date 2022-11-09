using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
Vector2 rightAttackOffset;
Collider2D swordCollider;

    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
        swordCollider.enabled = false;
    }

    
  public  void attackRight()
    {
        swordCollider.enabled = true;
   transform.position = rightAttackOffset;
      StartCoroutine(passiveMe(0.09f));
 
 IEnumerator passiveMe(float secs)
 {
     yield return new WaitForSeconds(secs);
     
     swordCollider.enabled = false;

 }
    }

  public  void attackLeft(){
        swordCollider.enabled = true;

        transform.position = new Vector2(rightAttackOffset.x*-1,rightAttackOffset.y);
   StartCoroutine(passiveMe(0.09f));
 
 IEnumerator passiveMe(float secs)
 {
     yield return new WaitForSeconds(secs);
     swordCollider.enabled = false;

 }


    }

   public void stopAttack(){
        swordCollider.enabled = false;
    }

     private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Enemy"){
        Debug.Log("hit enemy");
    }    
    }

    
}
