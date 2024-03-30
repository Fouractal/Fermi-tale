using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sphere : MonoBehaviour //, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private MeshRenderer _meshRenderer;
    private bool _collected = false;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void LoadData(GameData data)
    {
        data.sphereCollected.TryGetValue(id, out _collected);
        if (_collected)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.sphereCollected.ContainsKey(id))
        {
            data.sphereCollected.Remove(id);
        }
        data.sphereCollected.Add(id,_collected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_collected)
        {
            // FindObjectsOfType<PlayerDataManager>()[0].AddCollectedIndex();
            // PlayerDataManager 스크립트 변경으로 인한 AddCollectedIndex() 삭제
            gameObject.SetActive(false);
            _collected = true;
        }
    }
}
