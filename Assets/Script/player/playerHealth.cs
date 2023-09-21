using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    private bool canTakeDamage = true;
    private bool takingDamage = false;
    private bool barriered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        checkTakingDamage();
        death();
    }

    public bool takeDamage()
    {
        if(canTakeDamage && !barriered)
        {
            lives -= 1;
            takingDamage = true;
            StartCoroutine(damageReset());
            return true;
        }

        if(getBarriered())
        {
            setBarriered(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        print(getBarriered());
        return false;
    }

    public void setBarriered(bool val)
    {
        barriered = val;
    }

    public bool getBarriered()
    { return barriered; }

    public bool getCanTakeDamage() { return canTakeDamage; }

    private void checkTakingDamage()
    {
        if (takingDamage)
        {
            canTakeDamage = false;
        }
    }

    private IEnumerator damageReset()
    {
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
        takingDamage = false;
    }

    private void death()
    {
        if (lives == 0)
        {
            GameObject.Find("gameManager").GetComponent<gameManager>().gameOver = true;
        }
    }
}
