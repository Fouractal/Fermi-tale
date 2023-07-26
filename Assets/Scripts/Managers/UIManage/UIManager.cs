using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Parent Transforms")]
     private Transform _backgroundCanvas;
     private Transform _sceneUIRoot;
     private Transform _popupRoot;
    
     [Header("UI Component")]
     private Camera _mainCamera;

     #region Parent Transforms
     public Transform BackgroundCanvas
     {
         get
         {
             if (_backgroundCanvas == null)
                 _backgroundCanvas = GameObject.Find("BackgroundCanvas").transform;
    
             return _backgroundCanvas;
         }
     }
    
     public Transform SceneUIRoot
     {
         get
         {
             if (_sceneUIRoot == null)
                 _sceneUIRoot = GameObject.Find("SceneUIRoot").transform;
    
             return _sceneUIRoot;
         }
     }
    
     public Transform PopupRoot
     {
         get
         {
             if (_popupRoot == null)
                 _popupRoot = GameObject.Find("PopupRoot").transform;
    
             return _popupRoot;
         }
     }
     #endregion

     #region Show
     
     public GameObject ShowSceneUI(string resourcePath, int orderInLayer = 0)
     {
         GameObject sceneUIPrefab = Resources.Load<GameObject>(resourcePath);
         GameObject sceneUIInstance = Instantiate(sceneUIPrefab, SceneUIRoot);

         SetCanvas(sceneUIPrefab);
         SetSortingLayer(sceneUIPrefab, "SceneUI");
         SetOrder(sceneUIPrefab, orderInLayer);
    
         return sceneUIInstance;
     }
     
     public GameObject ShowPopup(string resourcePath, int orderInLayer = 0)
     {
         GameObject popupPrefab = Resources.Load<GameObject>(resourcePath);
         GameObject popupInstance = Instantiate(popupPrefab, PopupRoot);

         SetCanvas(popupInstance);
         SetSortingLayer(popupInstance, "PopupUI");
         SetOrder(popupInstance, orderInLayer);
    
         return popupInstance;
     }
    
     
     #endregion
    
    
     #region Canvas Settings
    
     public void SetCanvas(GameObject targetObj)
     {
         Canvas canvas = targetObj.GetComponent<Canvas>();
         CanvasScaler canvasScaler = targetObj.GetComponent<CanvasScaler>();
         if (canvas == null)
         {
             Debug.LogWarning($"{targetObj.name} has no canvas");
             canvas = targetObj.AddComponent<Canvas>();
             canvasScaler = targetObj.AddComponent<CanvasScaler>();
             targetObj.AddComponent<GraphicRaycaster>();
         }
         
         canvas.renderMode = RenderMode.ScreenSpaceCamera;
         canvas.worldCamera = Camera.main;
         canvas.overrideSorting = true;
    
         canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
         canvasScaler.referenceResolution = new Vector2(1080, 2400);
     }
    
     public void SetSortingLayer(GameObject targetObj, string sortingLayerName)
     {
         Canvas canvas = targetObj.GetComponent<Canvas>();
    
         canvas.sortingLayerName = sortingLayerName;
     }
     
    
     public void SetOrder(GameObject targetObj, int order)
     {
         Canvas targetCanvas = targetObj.GetComponent<Canvas>();
         targetCanvas.sortingOrder = order;
         targetCanvas.planeDistance = 10 - order;
     }
    
     #endregion
}
