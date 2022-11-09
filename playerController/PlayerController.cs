using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private Animator animator;
  [SerializeField] private ContactFilter2D movementFilter;
  [SerializeField] private float movementSpeed = 3f;
  [SerializeField] private float collisionOffset = 0.02f;
  public swordAttack SwordAttack;
  List <RaycastHit2D> castCollisions = new List<RaycastHit2D>();
  Vector2 Movement;
  bool flipX = false;
void Update(){
Movement.x = Input.GetAxisRaw("Horizontal");
Movement.y = Input.GetAxisRaw("Vertical");
animator.SetFloat("speed",Movement.sqrMagnitude);


if(Input.GetButtonDown("Fire3")){
  animator.SetTrigger("attack");
  attackFunc();
   StartCoroutine(passiveMe(0.09f));
 
 IEnumerator passiveMe(float secs)
 {
     yield return new WaitForSeconds(secs);
     
     animator.SetTrigger("attack");

 }

}
}

void FixedUpdate(){

if(Movement != Vector2.zero){
bool success = TryMove(Movement);

if(!success && Movement.x >0){
  success = TryMove(new Vector2(Movement.x,0));

if(!success  && Movement.y >0){
  success = TryMove(new Vector2(0,Movement.y));
}
}

animator.SetFloat("speed",Movement.sqrMagnitude);

}

}

private bool TryMove( Vector2 direction){

  int count =    rb.Cast(
    Movement,
    movementFilter,
  castCollisions,
  movementSpeed*Time.fixedDeltaTime + collisionOffset
  );

if(count == 0){

rb.MovePosition(rb.position + Movement*movementSpeed*Time.fixedDeltaTime);
if(Movement.x>0){
  transform.localScale = Vector3.one;
if(flipX){
  flipX = false;
}

}
else if(Movement.x<0){
  transform.localScale = new Vector3(-1,1,1);
if(flipX == false){
  flipX = true;
}

}


return true;
}
else{
return false;
}
}

public void OnFire(){
 animator.SetTrigger("attack");
}
void attackFunc(){
  if(flipX == false){
    SwordAttack.attackRight();
    Debug.Log("right attack");
  }
  else{
    SwordAttack.attackLeft();
    Debug.Log("left attack");
  }
}
}
