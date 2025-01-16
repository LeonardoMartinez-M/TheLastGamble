using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJack : MonoBehaviour
{
    //creates the cards and their values for visual finding and the value for the buffs
    public string[12] cardsNum;
    public int[12] cardsVal;
    //The Hand of the player
    private int Hand = new int Hand; 
    // creates the value for the Ace
    public int findValue(int hand)
    {
        if (hand <= 10)
        {
            return 11;
        }
        else
        {
            return 1;
        }
    }
    public void MakeCards(int[] Value, string[] Name)
    {
        //makes the cards traceable to the visual assets
       Name[0] = "ACE";
        Name[1] = "TWO";
        Name[2] = "THREE";
        Name[3] = "FOUR";
        Name[4] = "FIVE";
        Name[5] = "SIX";
        Name[6] = "SEVEN";
        Name[7] = "EIGHT";
        Name[8] = "NINE";
        Name[9] = "TEN";
        Name[10] = "KING";
        Name[11] = "QUEEN";
        Name[12] = "JACK";
          //Makes the values Visisble for the logic
          Value[0] = findValue(Hand);
          Value[1] = 2;
          Value[2] = 3;
          Value[3] = 4;
          Value[4] = 5;
          Value[5] = 6;
          Value[6] = 7;
          Value[7] = 8;
          Value[8] = 9;
          Value[9] = 10;
          Value[10] = 10;
          Value[11] = 10;
          Value[12] = 10;
          return this;

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        MakeCards(cardsVal[], cardsNum[]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
