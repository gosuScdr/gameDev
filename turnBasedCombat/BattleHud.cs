using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleHud : MonoBehaviour
{

public TextMeshProUGUI levelText;
public TextMeshProUGUI unitText;
public Slider HpBar;
    
public void SetHUD(Unit unit){
levelText.text = "Lv " + unit.unitLevel;
unitText.text = unit.unitName;
HpBar.maxValue = unit.maxHp;
HpBar.value = unit.currentHp; 


}

public void SetHp(int hp){
    HpBar.value = hp;
}
}
