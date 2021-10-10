using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Demo");
        }
    }


}
