using System.Collections;
using UnityEngine;

public class DicePair : MonoBehaviour {

    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    public GameObject Dice1, Dice2;
    public int diceResult1,diceResult2;


    void OnMouseDown(){
        if (!GameControl.gameOver && coroutineAllowed){
            Dice1.GetComponent<Dice>().ThrowTheDice();
            Dice2.GetComponent<Dice>().ThrowTheDice();
            
        }


    }

}
