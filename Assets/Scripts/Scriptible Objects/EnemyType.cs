using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemy Scriptible Obj")]
public class EnemyType : ScriptableObject
{
   public int enemyHealth;
   public int enemyDamage;

}