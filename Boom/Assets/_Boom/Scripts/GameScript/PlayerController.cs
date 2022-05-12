using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using Lean.Touch;
using Enums;
using Constans;
public class PlayerController : MonoBehaviour
{
    [Header("---------- Compenents ----------- ")]
    [SerializeField] private PathFollower _pathFollower;
    [SerializeField] private Animator _anim;
    [SerializeField] private WeaponHolder _weaponHolder;
    [Header("---------- Prefabs ----------- ")]
    [SerializeField] private Transform _bulletPos;
    [SerializeField] private GameObject _bullet;
    [Header("---------- Value ----------- ")]
    [SerializeField] private float _speed;
    [SerializeField] private int bulletCount;
    [SerializeField] bool isStart = false;
    [SerializeField] private float _time;

    private void OnEnable()
    {
        EventManager.GameStart += PlayerStart;
        LeanTouch.OnFingerUp += HandleFingerUp;
        LeanTouch.OnFingerDown += HandleFingerDown;
    }

    private void OnDisable()
    {
        EventManager.GameStart -= PlayerStart;
        LeanTouch.OnFingerDown -= HandleFingerDown;
        LeanTouch.OnFingerUp -= HandleFingerUp;
    }

    private void HandleFingerDown(LeanFinger obj)
    {
        SetBullet();
    }

    private void HandleFingerUp(LeanFinger obj)
    {
        EventManager.GamePlaySelectWeapon();
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }


    public void PlayerStart()
    {
        _pathFollower.speed = _speed;
        _anim.SetTrigger("Run");
        isStart = true;
    }


    void SetBullet()
    {
        if (isStart)
        {
            if (_time >= 4)
            {
                if (_weaponHolder.weaponsOrder < _weaponHolder.levelDesignSO.weapons.Count - 1)
                {
                    _time = 0;
                    _weaponHolder.weaponsOrder++;
                    if (_weaponHolder.weaponType == WeaponType.Pistol)
                    {
                        for (int i = 0; i < _weaponHolder.levelDesignSO.pistolBulletCount; i++)
                        {
                            Instantiate(_bullet, _bulletPos.position, Quaternion.identity);
                        }
                    }

                    if (_weaponHolder.weaponType == WeaponType.Shotgun)
                    {
                        for (int i = 0; i < _weaponHolder.levelDesignSO.shotgunBulletCount; i++)
                        {
                            Instantiate(_bullet, _bulletPos.position, Quaternion.identity);
                        }
                    }

                    if (_weaponHolder.weaponType == WeaponType.Rifle)
                    {
                        for (int i = 0; i < _weaponHolder.levelDesignSO.rifleBulletCount; i++)
                        {
                            Instantiate(_bullet, _bulletPos.position, Quaternion.identity);
                        }
                    }
                }
            }

           
        }
           
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Enemy)
        {
            EventManager.GamePlayFail(true);
        }

        if (other.tag == Tags.Succsess)
        {
            EventManager.GamePlaySuccess(true);
        }
    }
}
