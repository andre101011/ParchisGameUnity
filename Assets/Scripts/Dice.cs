using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;


	private void Start (){
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    public void ThrowTheDice(){
            StartCoroutine("RollTheDice");
    }

    public IEnumerator RollTheDice(){

        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++){
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        
        if(gameObject.name=="Dice1"){
            GameControl.diceSideThrown1 = randomDiceSide + 1;
        }else{
            GameControl.diceSideThrown2 = randomDiceSide + 1;
        }

        
        if (whosTurn == 1){
            //DicePair.MovePlayers();
            GameControl.MovePlayer(1);
        }else if (whosTurn == -1){
            GameControl.MovePlayer(2);
        }
        
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
