using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(menuName = "Boom/Level/LevelDesign")]
public class LevelDesignSO : ScriptableObject
{
     public int pistolBulletCount;
     public int shotgunBulletCount;
     public int rifleBulletCount;

     public Sprite pistolSprite;
     public Sprite shotgunsprite;
     public Sprite rifleSprite;

     public List<WeaponType> weapons;
}
