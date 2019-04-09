using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public void ShowAd() {
        Advertisement.Show("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
    }

    private void HandleAdResult(ShowResult result) {
        switch(result) {
            case ShowResult.Finished:
                Debug.Log("Add reward here");
                break;
            case ShowResult.Skipped:
                Debug.Log("Player didn't finish the Ad");
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the Ad Maybe not connected to internet.");
                break;
        }
    }
}
