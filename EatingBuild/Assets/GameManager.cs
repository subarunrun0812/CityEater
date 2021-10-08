using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int point;//大きさを変える時などに使うポイント

    [SerializeField] private EatObjectScript playerEat;

    public void AddPoint(int number)//ポイントの追加
    {
        point = point + number;
    }

    void Update()
    {
        if (point > 10)
        {
            playerEat.PlayerScale();
        }
    }
}
