using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private bool barriered = false;

    public bool takeDamage()
    {
        if(getBarriered())
        {
            setBarriered(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            return false;
        }

        return true;
    }

    public void setBarriered(bool val)
    {
        barriered = val;
    }

    public bool getBarriered()
    { return barriered; }
}
