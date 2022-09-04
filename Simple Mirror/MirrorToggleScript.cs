
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class MirrorToggleScript : UdonSharpBehaviour
{
    public GameObject MirrorLocal; //Local Mirror Object
    public GameObject MirrorFull; //Full Mirror Object
    public GameObject SwitchSelector; //Switch Button Object

    bool mirrorOnStatus = false; //Status to prevent double instancing of Mirrors.
    bool saveMirrorState = true; //True, Mirror Defaults to Local. False, Mirror Defaults to Full.

    public void SwitchMirror()
    {
        //Swapping the Local state of each Mirror to inverse of itself.
        MirrorLocal.SetActive(!MirrorLocal.activeSelf);
        MirrorFull.SetActive(!MirrorFull.activeSelf);
        saveMirrorState = !saveMirrorState;
    }
    public void EnableMirror()
    {
        //By default the mirror will load into "Local Only", thus enabling Local & Switch, disabling Full.
        if (saveMirrorState)
        {
            MirrorLocal.SetActive(true);
            MirrorFull.SetActive(false);
            SwitchSelector.SetActive(true);
        }
        else
        {
            MirrorLocal.SetActive(false);
            MirrorFull.SetActive(true);
            SwitchSelector.SetActive(true);
        }
    }
    public void DisableMirror()
    {
        //Disables all actors/objects.
        MirrorLocal.SetActive(false);
        MirrorFull.SetActive(false);
        SwitchSelector.SetActive(false);
    }
    public void MirrorOnStatus()
    {
        //On Interaction with this function, it will check against the BOOL state "mirrorOnStatus" to determine outcome.
        // You could use a switch, but for simplicity we're using IF & ELSE.
        if (mirrorOnStatus)
        {
            DisableMirror();
            mirrorOnStatus = false;
        }
        else
        {
            EnableMirror();
            mirrorOnStatus = true;
        }
    }
}
