#import <Foundation/Foundation.h>
#import <AppTrackingTransparency/ATTrackingManager.h>

extern "C" {

    /// <summary>ATT 許可状態取得</summary>
    /// <return>
    /// ATTracking Manager.Authorization Status
    ///  0: Not Determined, 1: Restricted, 2: Denied, 3: Authorized (, -1: No Needs)
    ///  https://developer.apple.com/documentation/apptrackingtransparency/attrackingmanager/authorizationstatus
    /// </return>
    int GetTrackingAuthorizationStatus() {
        if (@available(iOS 14, *)) {
            return (int)ATTrackingManager.trackingAuthorizationStatus;
        } else {
            return -1;
        }
    }

    /// <summary>コールバック型</summary>
    /// <param name="status">ATTracking Manager.Authorization Status</param>
    typedef void (*Callback)(int status);

    /// <summary>ATT 許可要求</summary>
    /// <param name="callback">コールバック関数</param>
    void RequestTrackingAuthorization(Callback callback) {
        if (@available(iOS 14, *)) {
            [ATTrackingManager requestTrackingAuthorizationWithCompletionHandler:^(ATTrackingManagerAuthorizationStatus status) {
                if (callback != nil) {
                    callback((int)status);
                }
            }];
        } else {
            callback(-1);
        }
    }

}
