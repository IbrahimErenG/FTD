using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ozellikler : MonoBehaviour
{
    public int hp;
    public int atk;

    public void TD(int amount)
    {
        hp -= amount;
    }

    public void DD(GameObject target)
    {
        var atm = target.GetComponent<Ozellikler>();
        if(atm != null)
        {
            atm.TD(atk);
        }
    }
}
