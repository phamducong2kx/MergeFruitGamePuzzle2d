using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingState : IGameState
{
    public void EnterState()
    {
        //load dữ liệu , vì ko làm addressable và firebase remote nên chỉ để tượng trưng
    }

    public void ExistSate()
    {
        UIManager.Instance.loadingUi.gameObject.SetActive(false);
    }
}
