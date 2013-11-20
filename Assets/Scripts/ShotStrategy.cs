using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public interface ShotStrategy
{
  void shoot(float x, float y, bool isEnemy);
}
