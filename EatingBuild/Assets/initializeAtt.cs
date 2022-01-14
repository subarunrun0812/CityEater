using UnityEngine;
public class initializeAtt : MonoBehaviour
{
    /// <summary>
    /// 開始処理
    /// </summary>
    public async void Start()
    {
#if UNITY_IOS
        var status = AttService.GetIOSTrackingAuthorizationStatus();
        if (!status.HasValue)
        {
            status = await AttService.RequestTrackingAuthorization() as bool?;
        }
#endif
    }
}
