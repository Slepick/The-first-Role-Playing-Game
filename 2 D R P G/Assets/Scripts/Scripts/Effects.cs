using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
public class Effects : MonoBehaviour
{

    Thread PoisonTr;
    Thread StunnedTr;
    Thread IllTr;
    RPG.RPG_Character person;
    // Use this for initialization
    void Start()
    {
        PoisonTr = new Thread(Poisoned);
        StunnedTr = new Thread(Stunned);
        IllTr = new Thread(Ill);
        person = this.gameObject.GetComponent<RPG.RPG_Character>();
    }

    // Update is called once per frame
    void Update()
    {




        if (person.Cond == RPG.condition.Poisoned)
        {
            if (PoisonTr.ThreadState != ThreadState.Running && PoisonTr.ThreadState != ThreadState.WaitSleepJoin)
            {
                PoisonTr = new Thread(Poisoned);
                PoisonTr.Start(person);
            }
        }
        if (person.Cond == RPG.condition.Paralyzed)
        {
            if (StunnedTr.ThreadState != ThreadState.Running && StunnedTr.ThreadState != ThreadState.WaitSleepJoin)
                StunnedTr = new Thread(Stunned);
            try
            {
                gameObject.GetComponent<PlayerMovement>().enabled = false;

                gameObject.GetComponent<Animator>().enabled = false;
            }
            catch (Exception e)
            {
                if (gameObject.GetComponent<AgressiveSlime2>() != null)
                    gameObject.GetComponent<AgressiveSlime2>().enabled = false;
                if (gameObject.GetComponent<SlimeController>() != null)
                    gameObject.GetComponent<SlimeController>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = (false);

                gameObject.GetComponent<HurtPlayer>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            StunnedTr.Start(person);
        }

        if (person.Cond == RPG.condition.Sick)
        {
            if (IllTr.ThreadState != ThreadState.Running && IllTr.ThreadState != ThreadState.WaitSleepJoin)
                IllTr = new Thread(Ill);
            gameObject.GetComponent<PlayerMovement>().Speed = 2;
            IllTr.Start(person);
        }
        if (person.Cond != RPG.condition.Paralyzed)
        {
            try
            {
                gameObject.GetComponent<PlayerMovement>().enabled = true;
                gameObject.GetComponent<Animator>().enabled = true;
            }
            catch (Exception e)
            {
                if (gameObject.GetComponent<AgressiveSlime2>() != null)
                    gameObject.GetComponent<AgressiveSlime2>().enabled = true;
                if (gameObject.GetComponent<SlimeController>() != null)
                    gameObject.GetComponent<SlimeController>().enabled = true;
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<HurtPlayer>().enabled = true;
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (person.Cond != RPG.condition.Sick)
        {
            if (gameObject.GetComponent<PlayerMovement>() != null)
            {
                gameObject.GetComponent<PlayerMovement>().Speed = 4;
                gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }

    }

    public void Poisoned(object person)
    {
        for (int i = 0; i < 15; i++)
        {
            if ((person as RPG.RPG_Character).Cond != RPG.condition.Poisoned)
                break;
            (person as RPG.RPG_Character).CurrentHP -= 4;
            Thread.Sleep(1000);

        }
        (person as RPG.RPG_Character).ChangeStatusToNormal();

    }
    public void Stunned(object person)
    {
        Thread.Sleep(3000);
        (person as RPG.RPG_Character).ChangeStatusToNormal();
    }
    public void Ill(object person)
    {
        Thread.Sleep(30000);
        (person as RPG.RPG_Character).ChangeStatusToNormal();
    }
}
