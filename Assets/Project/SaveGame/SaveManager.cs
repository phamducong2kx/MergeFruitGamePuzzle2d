using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveManager
{
    //key 
    public const string HighestPoint = "HighestPoint";
    public static int bestscore = 0;
    //load dữ liueej
    public static int LoadPoint()
    {

        if (PlayerPrefs.HasKey(HighestPoint))
        {
            bestscore = PlayerPrefs.GetInt(HighestPoint);

        }
        else
        {
            PlayerPrefs.SetInt(HighestPoint, 0);
            PlayerPrefs.Save();

        }
        return bestscore;
    }

    //Luuw điểm
    public static void SavePoint(int point)
    {

        bestscore = point;
        PlayerPrefs.SetInt(HighestPoint, bestscore);
        PlayerPrefs.Save();


    }

    //addpoint
    public static void AddPoint(int currentPoint)
    {

        if (bestscore >= currentPoint) return;
        else
        {
            SavePoint(currentPoint);
        }

    }
}
