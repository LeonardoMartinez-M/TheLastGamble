using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJack : MonoBehaviour
{
    public bool Active;
    //creates the cards and their values for visual finding and the value for the buffs
    public string[12] cardsNum;
    public int[12] cardsVal;
   
    //The Hand of the player
    public int Hand;
    public int HandNums[0][0];

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
        cout<<"Find Values Called">>
    }

    //makes the array's populate with the cards
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
          cout<<"Make Cards Called">>
          return this;

    }

    //Makes the hand
    public int MakeHand(HandNums cards, Hand total)
    {
        cout<<"Make Hand Called">>
        return cards.DrawHand(cardsVal[],cardsVal[], Hand), total;
    }

    private int DrawHand(int[] CardOne, int[] CardTwo, int total)
    {
        cout<<"DrawHand called">>
        int random = 0 + (rand() % 12);
        int random2 = 0 + (rand() % 12);
        int total =  CardOne[random].position+CardTwo[random2].position
        
        return CardOne[random].position,CardTwo[random2].position, total;
    }

    private ApplyEffect(int HandTotal)
    {
        cout<<"Apply Effect Called">>
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Active = false;
        MakeCards(cardsVal[], cardsNum[]);
        cout<<"Start Called">>
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Active == true)
        { 
            MakeHand(HandNums,Hand);
            ApplyEffect(Hand);
            ChangeVisuals(HandNums[0][0]);
            Active = false;
        }
        else
        {
            return null;
        }
        cout<<"Update Called">>
    }
}
