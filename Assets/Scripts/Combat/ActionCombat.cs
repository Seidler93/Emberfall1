using UnityEngine;
using System.Collections.Generic;

public class ActionCombat : MonoBehaviour
{
  public Animator weaponAnimator;
  public float lightAttackDamage = 15f;
  public float heavyAttackDamage = 25f;
  public float lightAttackStaminaCost = 10f;
  public float heavyAttackStaminaCost = 25f;
  public bool isAttacking { get; private set; }
  public bool dealDamage { get; private set; } = false;
  private List<Enemy> alreadyHitEnemies = new List<Enemy>();

  void Update()
  {
      if (isAttacking) return;

      if (Input.GetMouseButtonDown(0))
      {
          isAttacking = true;
          weaponAnimator.SetTrigger("LightAttack");
      }
      else if (Input.GetMouseButtonDown(1))
      {
          isAttacking = true;
          weaponAnimator.SetTrigger("HeavyAttack");
      }
  }

  public void EndAttack()
  {
      isAttacking = false;
  }

  public void StartDamageWindow()
  {
      // Debug.Log("Starting damage window");

      dealDamage = true;
      alreadyHitEnemies.Clear();
  }

  public void EndDamageWindow()
  {
      dealDamage = false;
  }

  public bool TryRegisterHit(Enemy enemy)
  {
      if (alreadyHitEnemies.Contains(enemy)) return false;

      alreadyHitEnemies.Add(enemy);
      return true;
  }

}



