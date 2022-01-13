#if UNITY_IOS
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

public static class AttService {
	private static TaskCompletionSource<bool> AttTcs; // boolを返すタスク
	private static SynchronizationContext Context; // Unityのスレッドの同期環境を保持

	/// <summary>クラス初期化</summary>
	static AttService () {
		Context = SynchronizationContext.Current;
	}

	/// <summary>ATT 許可状態取得 プラグイン</summary>
	[DllImport ("__Internal")]
	private static extern int GetTrackingAuthorizationStatus ();

	/// <summary>コールバック型</summary>
	private delegate void OnCompleteStatusCallback (int status);

	/// <summary>ATT 許可要求 プラグイン</summary>
	/// <param name="callback">コールバック関数</param>
	[DllImport ("__Internal")]
	private static extern void RequestTrackingAuthorization (OnCompleteStatusCallback callback);

	/// <summary>ATT の同意状態を取得する</summary>
	/// <return>true: Authorized or No Needs, false: Denied or Restricted, null: Not Determined</return>
	public static bool? GetIOSTrackingAuthorizationStatus () {
#if UNITY_EDITOR
		return true;
#else
        switch (GetTrackingAuthorizationStatus ()) {
            case -1: // No Needs
            case 3: // Authorized
                return true;
            case 0: // Not Determined
                return null;
            default:
                return false;
        }
#endif
	}

	/// <summary>ATT 許可を要求する</summary>
	/// <return>(Authorized or No Needs)なら真を結果とする非同期タスク</return>
	public static Task<bool> RequestTrackingAuthorization () {
#if UNITY_EDITOR
		return Task.FromResult (true);
#else
        AttTcs = new TaskCompletionSource<bool> ();
        RequestTrackingAuthorization (OnRequestTrackingAuthorizationComplete);
        return AttTcs.Task;
#endif
	}

	/// <summary>コールバックハンドラ</summary>
	[AOT.MonoPInvokeCallback (typeof (OnCompleteStatusCallback))]
	private static void OnRequestTrackingAuthorizationComplete (int status) {
		if (AttTcs != null) {
			Context.Post (_ => {
				switch (status) {
					case -1: // No Needs
					case 3: // Authorized
						AttTcs.TrySetResult (true);
						break;
					default:
						AttTcs.TrySetResult (false);
						break;
				}
			}, null);
		}
	}

}
#endif