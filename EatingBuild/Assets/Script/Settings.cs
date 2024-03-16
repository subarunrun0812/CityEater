using UnityEngine;

public class Settings : MonoBehaviour
{

    private void Start()//フレームレートを３０で固定
    {
        Application.targetFrameRate = 30;
    }
}
