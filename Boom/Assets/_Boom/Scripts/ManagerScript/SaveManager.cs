using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DorukEvents;
public class SaveManager : MonoBehaviour
{
    [Header("Level Data")]
    [SerializeField] public SaveSO saveSO;
    public const string prefslevelkey = "saveID";
    private void Awake()
    {
        SetPlayerPrefs();
    }
    private void Start()
    {
        EventManager.GamePlayLevelCount(saveSO.saveLevelNo + 1);
        GetLevelData();
    }
    private void OnEnable()
    {
        EventManager.GameSaveLevelPlus += SetLevelPlus;
    }
    private void OnDisable()
    {
        EventManager.GameSaveLevelPlus -= SetLevelPlus;
    }

    void SetPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(prefslevelkey))
        {
            saveSO.saveLevelNo = PlayerPrefs.GetInt(prefslevelkey);
        }
        else
        {
            PlayerPrefs.SetInt(prefslevelkey, saveSO.saveLevelNo);
        }
    }
    public void SetLevelPlus()
    {
        saveSO.saveLevelNo++;
        EventManager.GamePlayLevelCount(saveSO.saveLevelNo + 1);
        PlayerPrefs.SetInt(prefslevelkey, saveSO.saveLevelNo);
        GetLevelData();
    }


    void GetLevelData()
    {
        EventManager.GamePlayLevelData(saveSO.saveLevelNo);
    }
}
