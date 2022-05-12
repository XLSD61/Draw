using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Enums;



    public class EventManager
    {
        //Game
        public delegate void onGamePlaySuccess(bool value);
        public static event onGamePlaySuccess GameSuccess;

        public static void GamePlaySuccess(bool value)
        {
            GameSuccess?.Invoke(value);
        }


        public delegate void onGamePlayFail(bool value);
        public static event onGamePlayFail GameFail;

        public static void GamePlayFail(bool value)
        {
            GameFail?.Invoke(value);
        }

        public delegate void onGameStartButton(bool value);
        public static event onGameStartButton GameStartButton;

        public static void GamePlayStartButton(bool value)
        {
            GameStartButton?.Invoke(value);
        }

    public delegate void onGameStart();
    public static event onGameStart GameStart;

    public static void GamePlayStart()
    {
        GameStart?.Invoke();
    }

    //Camera

    public delegate void onGameCameraTarget(Transform player);
    public static event onGameCameraTarget CameraTarget;

    public static void GamePlayCameraTarget(Transform player)
    {
        CameraTarget?.Invoke(player);
    }

    //Save

    public delegate void onGameSaveLevelPlus();
    public static event onGameSaveLevelPlus GameSaveLevelPlus;

    public static void GamePlaySaveLevelPlus()
    {
        GameSaveLevelPlus?.Invoke();
    }

    public delegate void onGameLevelData(int levelMod);
    public static event onGameLevelData GameLevelData;

    public static void GamePlayLevelData(int levelMod)
    {
        GameLevelData?.Invoke(levelMod);
    }

    // Count
    public delegate void onGameLevelCount(int value);
    public static event onGameLevelCount GameLevelCount;

    public static void GamePlayLevelCount(int value)
    {
        GameLevelCount?.Invoke(value);
    }


    //Weapon
    public delegate void onGameBulletCount(int value);
    public static event onGameBulletCount GameBulletCount;

    public static void GamePlayBulletCount(int value)
    {
        GameBulletCount?.Invoke(value);
    }

    public delegate void onGameWeaponSprite(Sprite sprite);
    public static event onGameWeaponSprite GameWeaponSprite;

    public static void GamePlayWeaponSprite(Sprite sprite)
    {
        GameWeaponSprite?.Invoke(sprite);
    }

    public delegate void onGameSelectWeapon();
    public static event onGameSelectWeapon GameSelectWeapon;

    public static void GamePlaySelectWeapon()
    {
        GameSelectWeapon?.Invoke();
    }

    //Enemy
    public delegate void onGameEnemyDead(int id);
    public static event onGameEnemyDead GameEnemyDead;

    public static void GamePLayEnemyDead(int id)
    {
        GameEnemyDead?.Invoke(id);
    }

}



