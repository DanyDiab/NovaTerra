using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    public Image HPBar;
    public int totalHp;
    public int currHp;
    public Player player;

    // Update is called once per frame
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        currHp = player.hp;
        totalHp = player.totalHp;
        drawPlayerHP();
    }

    void drawPlayerHP(){
        HPBar.fillAmount = (float) currHp/totalHp;
    }
}
