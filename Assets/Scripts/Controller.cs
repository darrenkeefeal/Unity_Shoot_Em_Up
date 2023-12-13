using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //Canvas UI
    public GameObject restartUI;
    public GameObject playerHPUI;

    public TMP_Text playerHP;

    //Canvas Object
    public GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        restartUI.SetActive(false);
        playerHPUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShip == null && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Space");
        }
    }

    public void PlayerIsDead()
    {
        playerHPUI.SetActive(false);
        restartUI.SetActive(true);
    }

    public void SetPlayerHP(float hp)
    {
        playerHP.text = hp.ToString();
    }
}
