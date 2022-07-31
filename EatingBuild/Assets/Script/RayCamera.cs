using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class RayCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private EatObjectScript eatObject;

    // 今回のUpdateで検出された遮蔽物のGameObject。
    public GameObject[] prevRaycast;
    // 次のUpdateで該当しない場合は、遮蔽物ではなくなったので 不透明にする
    public List<GameObject> raycastHitsList_ = new List<GameObject>();



    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
        Ray _ray = new Ray(this.transform.position, _direction);
        // Rayが衝突した全てのコライダーの情報を得る
        RaycastHit[] rayCastHits = Physics.RaycastAll(_ray);

        prevRaycast = raycastHitsList_.ToArray();//List<RaycastHitList_> の要素をprevRaycast配列にコピーします。
        raycastHitsList_.Clear();//リストをクリアにする

        foreach (RaycastHit hit in rayCastHits)
        {
            SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////objしたオブジェクトのSampleMaterialコンポーネントを取得

            if (
            hit.collider.tag == "10p" && gameManager.point < eatObject.obj10p || hit.collider.tag == "12p" && gameManager.point < eatObject.obj12p ||
            hit.collider.tag == "15p" && gameManager.point < eatObject.obj15p || hit.collider.tag == "20p" && gameManager.point < eatObject.obj20p ||
            hit.collider.tag == "30p" || hit.collider.tag == "50p")
            {
                sampleMaterial.ClearMaterialInvoke();
                raycastHitsList_.Add(hit.collider.gameObject);//hitしたgameobjectを追加する
            }
        }

        //.Except = 既定の等値比較子を使用して値を比較することにより、2 つのシーケンスの差集合を生成します。
        foreach (GameObject _gameObject in prevRaycast.Except<GameObject>(raycastHitsList_))
        {
            SampleMaterial noSampleMaterial = _gameObject.GetComponent<SampleMaterial>();
            // 遮蔽物でなくなったGameObjectを不透明に戻す
            if (_gameObject != null)
            {
                noSampleMaterial.NotClearMaterialInvoke();
            }

        }
    }
}