using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using DorukEvents;


public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject WeaponPanel;
    [SerializeField] Image weaponImage;
    [SerializeField] Text bulletCount;
    private void OnEnable()
    {
        EventManager.GameStartButton += SetPlayButton;
        EventManager.GameSuccess += SetSuccessPanel;
        EventManager.GameFail += SetFailPanel;
        EventManager.GameWeaponSprite += SetWeapon;
        EventManager.GameBulletCount += SetBulletCount;
    }

    private void OnDisable()
    {
        EventManager.GameStartButton -= SetPlayButton;
        EventManager.GameSuccess -= SetSuccessPanel;
        EventManager.GameFail -= SetFailPanel;
        EventManager.GameWeaponSprite -= SetWeapon;
        EventManager.GameBulletCount -= SetBulletCount;


    }

    public void SetPlayButton(bool value)
    {
        playButton.SetActive(value);
    }

    public void GameStartButton()
    {
        SetPlayButton(false);
        WeaponPanel.SetActive(true);
        EventManager.GamePlayStart();
    }
    public void SetFailPanel(bool value)
    {
        failPanel.SetActive(value);
    }

    public void SetSuccessPanel(bool value)
    {
        successPanel.SetActive(value);
    }

    public void SetLevelCount(int value)
    {
      //  levelCountText.text = "LEVEL\n" + value.ToString();
    }

    public void SetWeapon(Sprite sprite)
    {
        weaponImage.sprite = sprite;
    }

    public void SetBulletCount(int value)
    {
        bulletCount.text = value.ToString();
    }
     
}
