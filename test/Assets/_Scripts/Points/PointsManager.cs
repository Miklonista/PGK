using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int points;

    public TextMeshProUGUI interfacePoints;

    private void Start()
    {
        interfacePoints.text = points.ToString();
    }

    public void AddPoint()
    {
        points++;
        interfacePoints.text = points.ToString();
    }
}
