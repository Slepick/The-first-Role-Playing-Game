using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    RPG.CharacterWieldingMagic player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<RPG.CharacterWieldingMagic>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.Cast(player.StudiedSpells[0], player.Target);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.Cast(player.StudiedSpells[1], player.Target);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.Cast(player.StudiedSpells[2], player.Target);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.Cast(player.StudiedSpells[3], player.Target);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.Cast(player.StudiedSpells[4], player.Target);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player.Cast(player.StudiedSpells[5], player.Target);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("Image").SetActive(false);
        }
    }
}
