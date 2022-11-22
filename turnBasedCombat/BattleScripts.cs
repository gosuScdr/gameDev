using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState {START, PLAYERTURN, ENEMYTURN , WON , LOST}

public class BattleScripts : MonoBehaviour
{
public GameObject PlayerPrefab;
public GameObject EnemyPrefab;
public Transform playerBattleStation;
public Transform enemyBattleStation;
public TextMeshProUGUI dialogueText;
public BattleHud playerHud;
public BattleHud enemyHud;
public Animator playerAnimator;
public Animator enemyAnimator;

Unit playerUnit;
Unit enemyUnit;

public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    IEnumerator SetupBattle()
    {
    //   GameObject playerGo =  Instantiate(PlayerPrefab,playerBattleStation);
      playerUnit = PlayerPrefab.GetComponent<Unit>();
   playerHud.SetHUD(playerUnit);

    //   GameObject enemyGo =  Instantiate(EnemyPrefab,enemyBattleStation);
      enemyUnit = EnemyPrefab.GetComponent<Unit>();
     enemyHud.SetHUD(enemyUnit);
    dialogueText.text = "A wild " + enemyUnit.unitName + " approaches....";
    yield return new WaitForSeconds(2f);
    state = BattleState.PLAYERTURN;
    playerTurn();
    }

    void playerTurn(){
        dialogueText.text = "Choose an action";
    }

IEnumerator PlayerAttack(){

   bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
   enemyHud.SetHp(enemyUnit.currentHp);
   dialogueText.text = "This attack is successfull"; 
 playerAnimator.SetTrigger("move");
 

    yield return new WaitForSeconds(2f);


    if(isDead){
        state = BattleState.WON;
        EndBattle();
    }
    else{
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
}

IEnumerator EnemyTurn(){
    dialogueText.text = enemyUnit.unitName + " attacks!";
    enemyAnimator.SetTrigger("move");
    yield return new WaitForSeconds(1f);
    bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
    playerHud.SetHp(playerUnit.currentHp);
    yield return new WaitForSeconds(1f);
    

if(isDead){
    state = BattleState.LOST;
EndBattle();
}
else{
    state = BattleState.PLAYERTURN;
    playerTurn();
}

}

void EndBattle(){
    if(state == BattleState.WON){
        dialogueText.text = "You won the battle";
    }
    else if(state == BattleState.LOST){
        dialogueText.text = "You were defeated";
    }
}

    public void OnAttackButton(){
        if(state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());
    }

   
}
