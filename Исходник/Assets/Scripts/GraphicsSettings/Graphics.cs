using System;
using UnityEngine;
using UnityEngine.UI;

public class Graphics : MonoBehaviour
{
    public int GraphLvl;
    public void SetGraphicsMode(int QualityIndex)
    {
        FindObjectOfType<SaveSetting>().SaveGraphic();
        GraphLvl = QualityIndex;
        Debug.Log(GraphLvl);
        QualitySettings.SetQualityLevel(QualityIndex);
    }
}
