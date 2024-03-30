using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DebugPlayerData : MonoBehaviour, IDataPersistence
{
	// Player Data
	private string _sceneName;
	private int _chapterIndex;
	private List<ItemData> _itemDataList;
	private bool _isBGMOn;
	private bool _isSoundEffectOn;
	
	// Debug UI
	[SerializeField] private TextMeshProUGUI sceneNameText;
	[SerializeField] private TextMeshProUGUI chapterNumText;
	[SerializeField] private TextMeshProUGUI itemDataText;
	[SerializeField] private TextMeshProUGUI BGMText;
	[SerializeField] private TextMeshProUGUI SoundEffectText;
	
	
	public void SaveData(ref PlayerData data)
	{
		
	}

	public void LoadData(PlayerData data)
	{
		this._sceneName = data.sceneName;
		this._chapterIndex = data.chapterIndex;
		this._itemDataList = data.itemDataList;
		this._isBGMOn = data.isBGMOn;
		this._isSoundEffectOn = data.isSoundEffectOn;

		sceneNameText.text = "SceneName : " + _sceneName;
		chapterNumText.text = "Chapter Index : " + _chapterIndex.ToString();
		BGMText.text = $"BGM ON ? {_isBGMOn}";
		SoundEffectText.text = $"Sound Effect ON ? {_isSoundEffectOn}";
		
		// TODO : itemDataList debug 추가 
	}
}
