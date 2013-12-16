using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Shot :  FSprite
{

  private float speedX = 300.0f;
  private float speedY = 0.0f;
  private float damage;

  public Shot(float x, float y, bool isEnemy, float dmg, string sprite) : base(sprite)
  {
    this.x = x;
    this.y = y;
    this.damage = dmg;
    this.scale = 0.50f;
    int direction = isEnemy ? -1 : 1;
    this.speedX = speedX*direction;
    this.speedY = 0;
    ListenForUpdate (HandleUpdate);
  }

  // overloaded constructor, for angled shots
  public Shot(float x, float y, bool isEnemy, float dmg, float angle, string sprite) : this(x, y, isEnemy, dmg, sprite)
  {
    this.speedX = Mathf.Cos(angle) * speedX;
    this.speedY = Mathf.Sin(angle) * speedX;
  }

  public void HandleUpdate()
  {
    this.x += speedX * Time.deltaTime;
    this.y += speedY * Time.deltaTime;
  }

  public float getDamage()
  {
    return this.damage;
  }
}
