using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiBtn : MonoBehaviour
{
    bool m_bPause;

    void Update()
    {
        if (this.m_bPause == true)
            Time.timeScale = 0; //정지
        else
            Time.timeScale = 1; //정상속도로 플레이
    }
    public void Pause()
    {
        if (m_bPause == false)
        {
            this.m_bPause = true;
        }
        else
        {
            this.m_bPause = false;
        }
    }
}
