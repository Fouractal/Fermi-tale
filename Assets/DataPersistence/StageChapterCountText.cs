using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageChapterCountText : MonoBehaviour, IDataPersistence
{
    private int _stageIndex = 0;
    private int _chapterIndex = 0;
    public int _collectedSphereIndex = 0;
    [SerializeField] private TextMeshProUGUI _stageText;
    [SerializeField] private TextMeshProUGUI _chapText;
    [SerializeField] public TextMeshProUGUI _collectedSphereText;
    

    public void LoadData(GameData data)
    {
        this._stageIndex = data.stageIndex;
        this._chapterIndex = data.chapterIndex;
        
        _stageText.text = "Stage : " + _stageIndex.ToString();
        _chapText.text = "Chap : " + _chapterIndex.ToString();

        foreach (KeyValuePair<string,bool> pair in data.sphereCollected)
        {
            if (pair.Value)
            {
                _collectedSphereIndex++;
            }
        }
            
        _collectedSphereText.text = "Collected Sphere : " + _collectedSphereIndex.ToString();
    }

    public void SaveData(ref GameData data)
    {
        data.stageIndex = this._stageIndex;
        data.chapterIndex = this._chapterIndex;
        data.collectedIndex = this._collectedSphereIndex;
    }

    public void AddStageIndex()
    {
        _stageIndex++;
        _stageText.text = "Stage : " + _stageIndex.ToString();
    }

    public void MinStageIndex()
    {
        _stageIndex--;
        _stageText.text = "Stage : " + _stageIndex.ToString();
    }

    public void AddChapIndex()
    {
        _chapterIndex++;
        _chapText.text = "Chap : " + _chapterIndex.ToString();
    } 
    public void MinChapIndex()
    {
        _chapterIndex--;
        _chapText.text = "Chap : " + _chapterIndex.ToString();
    }
    public void AddCollectedIndex()
    {
        _collectedSphereIndex++;
        _collectedSphereText.text = "Collected Sphere : " + _collectedSphereIndex.ToString();
    } 
}
