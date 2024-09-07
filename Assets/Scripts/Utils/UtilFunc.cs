using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    // [0,maxValue]의 int 중 amount개를 뽑아서 return 합니다.
    public static List<int> SelectRandomInt(int maxValue, int amount)
    {
        List<int> availableIntList = new List<int>();

        for (int i = 0; i <= maxValue; i++)
        {
            availableIntList.Add(i);
        }

        for (int i = 0; i < (maxValue + 1) - amount; i++)
        {
            int randomIndex = Random.Range(0, availableIntList.Count);
            availableIntList.RemoveAt(randomIndex);
        }

        return availableIntList;
    }

    // inputList 중 하나를 뽑아 Return 합니다.
    public static T SelectRandom<T>(List<T> inputList)
    {
        int randomIndex = Random.Range(0, inputList.Count);
        return inputList[randomIndex];
    }

    // inputList 중 amount 개의 데이터를 뽑고, Copy하여 return 합니다.
    public static List<T> SelectRandom<T>(List<T> inputList, int amount)
    {
        List<T> resultList = new List<T>(inputList);
            
        int inputListCount = inputList.Count;
        
        for (int i = 0; i < inputListCount - amount; i++)
        {
            int randomIndex = Random.Range(0, resultList.Count);
            resultList.RemoveAt(randomIndex);
        }
        
        return resultList;
    }

    // inputList 중 amount 개의 데이터만 남깁니다.
    public static void RemainRandom<T>(List<T> inputList, int amount)
    {
        int inputListCount = inputList.Count;
        
        for (int i = 0; i < inputListCount - amount; i++)
        {
            int randomIndex = Random.Range(0, inputList.Count);
            inputList.RemoveAt(randomIndex);
        }
    }
    
    // inputList를 무작위로 섞습니다.
    public static void ListRandomShuffle<T>(List<T> inputList)
    {
        List<T> newList = new List<T>();
        int inputListCount = inputList.Count;

        for(int i=0; i<inputListCount; i++)
        {
            int randomIndex = Random.Range(0, inputList.Count);
            newList.Add(inputList[randomIndex]);
            inputList.RemoveAt(randomIndex);
        }

        inputList.Clear();
        inputList.AddRange(newList);
    }

    public static List<T> Combination<T>(List<T> list, int count)
    {
        //중복하지 않게 count개 만큼 뽑아서 return

        List<int> availableIndexList = new List<int>();
        List<T> newList = new List<T>();

        for(int i=0; i<list.Count; i++)
        {
            availableIndexList.Add(i);
        }

        for(int i=0; i<count; i++)
        {
            int randomNum = Random.Range(0, availableIndexList.Count);
            int randomIndex = availableIndexList[randomNum];

            T value = list[randomIndex];

            newList.Add(value);
            availableIndexList.RemoveAt(randomNum);
        }

        return newList;
    }

    public static int ReturnMin(int a, int b)
    {
        int result = (a < b) ? a : b;
        return result;
    }

    public static int ReturnMax(int a, int b)
    {
        int result = (a > b) ? a : b;
        return result;
    }

    public static Vector3 ConvertCoordinateS2W(Vector2 screenVector)
    {
        float x = screenVector.x;
        float y = screenVector.y;

        float angle = -45f;
        float radians = angle * Mathf.Deg2Rad;

        float newX = x * Mathf.Cos(radians) - y * Mathf.Sin(radians);
        float newZ = x * Mathf.Sin(radians) + y * Mathf.Cos(radians);
        
        return new Vector3(newX, 0f, newZ);
    }
}
