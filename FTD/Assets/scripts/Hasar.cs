using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hasar : MonoBehaviour
{
    public Ozellikler playerAtm;
    public Ozellikler enemyAtm;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAtm.DD(enemyAtm.gameObject);
        }
    }
}
