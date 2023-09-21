using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;
    
    private UI_Manager _UIManager;
//    _UIManager = GameObject.Find("level1").GetComponent<UI_Manager>();

    private bool canTakeDamage = true;
    private bool takingDamage = false;
    private bool barriered = false;

    // Start is called before the first frame update
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

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
            _UIManager.updateLives(lives);
            takingDamage = true;
            StartCoroutine(damageReset());
            return true;
        }

        if(getBarriered())
        {
            setBarriered(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

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
            Destroy(this.gameObject);
        }
    }
}
