using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGameStart : BaseDialog {

	public void onClickPlayGame()
    {
        Application.LoadLevel("PauseGame");
        //SceneManager.

    }
    public void onClickSeting()
    {
        DialogManager.Instance.ShowDialog <DialogGameSetting>("Prefabs/UI/Setting");
    }
}
