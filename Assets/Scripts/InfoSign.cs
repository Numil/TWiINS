﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Permet l'affichage d'aide lorsque le joueur s'approche d'un panneau
public class InfoSign : MonoBehaviour
{

    public Text textToShow;

    private void OnTriggerStay2D(Collider2D collision)
    {
        textToShow.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        textToShow.enabled = false;
    }
}
