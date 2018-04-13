using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int coints;
    public Text cointsText;

    public int currentHealth;

    void Update()
    {
        cointsText.text = ("Coins: " + coints + "/10");
    }

}
