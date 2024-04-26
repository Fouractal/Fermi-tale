using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.LV
{
    public class QuestUI : MonoBehaviour
    {
        private Image _image;

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
        }
        
        public static QuestUI ShowQuestUI(Vector3 pos, Quest quest)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/LV/QuestUI");
            QuestUI ui = Instantiate(prefab, pos, Quaternion.identity).GetComponent<QuestUI>();
            
            switch (quest)
            {
                case Quest.Cleaning:
                    ui._image.color = Color.gray;
                    break;
                case Quest.Fertilizing:
                    ui._image.color = Color.green;
                    break;
                case Quest.Watering:
                    ui._image.color = Color.blue;
                    break;
                case Quest.RemoveBugs:
                    ui._image.color = Color.red;
                    break;
            }

            ui.transform.DOScale(Vector3.one, 1f).From(Vector3.zero);
            return ui;
        }

        public void HideQuestUI()
        {
            Destroy(gameObject);
        }
    }    
}

