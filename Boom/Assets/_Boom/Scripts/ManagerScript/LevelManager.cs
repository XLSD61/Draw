using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DorukEvents;

public class LevelManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] LevelSO LevelSO;

    GameObject level;

  //  [SerializeField] public int refEnemyCount;
    private void OnEnable()
    {
        EventManager.GameLevelData += SetLevelData;
    }

    private void OnDisable()
    {
        EventManager.GameLevelData -= SetLevelData;
    }
    private void Start()
    {
        SetLevel();
    }

    void SetLevel()
    {
        level = Instantiate(LevelSO.levels[LevelSO.saveLevelMod]);
    }
    void SetLevelData(int levelNoValue)
    {
        LevelSO.saveLevelMod = levelNoValue % LevelSO.levels.Length;
    }

    public void LevelSuccess()
    {
        Destroy(level);
        EventManager.GamePlaySaveLevelPlus();
        SetLevel();
        EventManager.GamePlaySuccess(false);
    }

    public void LevelRestart()
    {
        Destroy(level);
        SetLevel();
        EventManager.GamePlayFail(false);
    }
}
