using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class WeaponHolder : MonoBehaviour
{
    [SerializeField] public LevelDesignSO levelDesignSO;
    [SerializeField] public int weaponsOrder = 0;

    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _shotgun;
    [SerializeField] private GameObject _rifle;
    [SerializeField] public WeaponType weaponType;

    private void Start()
    {
        SelectWeapon();
    }
    private void OnEnable()
    {
        EventManager.GameSelectWeapon += SelectWeapon;
    }
    private void OnDisable()
    {
        EventManager.GameSelectWeapon -= SelectWeapon;
    }

    public void SelectWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (levelDesignSO.weapons[weaponsOrder] == WeaponType.Pistol)
        {
            _pistol.SetActive(true);
            WeaponUI(levelDesignSO.pistolSprite, levelDesignSO.pistolBulletCount);
            weaponType = WeaponType.Pistol;
            
        }
        else if (levelDesignSO.weapons[weaponsOrder] == WeaponType.Shotgun)
        {
            _shotgun.SetActive(true);
            WeaponUI(levelDesignSO.shotgunsprite, levelDesignSO.shotgunBulletCount);
            weaponType = WeaponType.Shotgun;

        }
        else if (levelDesignSO.weapons[weaponsOrder] == WeaponType.Rifle)
        {
            _rifle.SetActive(true);
            WeaponUI(levelDesignSO.rifleSprite, levelDesignSO.rifleBulletCount);
            weaponType = WeaponType.Rifle;
        }
    }

    void WeaponUI( Sprite sprite, int value)
    {
        EventManager.GamePlayWeaponSprite(sprite);
        EventManager.GamePlayBulletCount(value);
    }
}
