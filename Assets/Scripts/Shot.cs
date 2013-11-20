using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Shot :  FSprite
{
  private float speedX = 0.0f;
  private float speedY = 0.0f;
  private float damage = 0.0f;

  public Shot(float x, float y, bool isEnemy, float dmg) : base("Banana")
  {
    this.x = x;
    this.y = y;
    this.damage = dmg;
    this.scale = 0.25f;
    int direction = isEnemy ? -1 : 1;
    this.speedX = 5*direction;
    this.speedY = 0;
    ListenForUpdate (HandleUpdate);
  }

  // overloaded constructor, for angled shots
  public Shot(float x, float y, bool isEnemy, float dmg, float angle) : this(x, y, isEnemy, dmg)
  {
    this.speedX = Mathf.Cos(angle) * speedX;
    this.speedY = Mathf.Sin(angle) * speedX;
  }

  public void HandleUpdate()
  {
    this.x += speedX;
    this.y += speedY;
  }

  public float getDamage()
  {
    return this.damage;
  }
}
