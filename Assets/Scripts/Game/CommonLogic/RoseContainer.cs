using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseContainer : MonoBehaviour
{
    private static List<Rose> RoseList { get; set; }
    public int size;

    private void Awake()
    {
        RoseList = new List<Rose>(new Rose[size]);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        ShowRose(0);
    }

    public static void Register(Rose rose)
    {
        RoseList[rose.ownIndex] = rose;
    }

    public static void ShowRose(int targetIndex)
    {
        if (RoseList.Count <= targetIndex) return;
        RoseList[targetIndex].gameObject.SetActive(true);
    }
}