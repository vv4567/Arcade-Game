using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogTypes { Intro, Intro_TooLong, Tutorial, Tutorial_Interrupted, Tutorial_Completed, MainQuest, FiveMinWarning, OneMinWarning, BadEnding, NotEnoughTicket, EnoughTicket, MAX_DIALOG_TYPE };

public class MrCruz : MonoBehaviour
{
    protected AudioSource audioSource;

    public AudioClip[] Dialogs;

    private DialogTypes currentDialog;

    private void OnEnable()
    {
        currentDialog = DialogTypes.MAX_DIALOG_TYPE;
    }

    private void Start()
    {
        StartCoroutine(IntroCo());
    }

    public void StopDialogs()
    {
        StopAllCoroutines();

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void UpdateDialog()
    {
        if (audioSource == null) { Debug.LogWarning(this.name + " cannot find AudioSource.");  return; }

        switch (currentDialog)
        {

            case DialogTypes.Intro:
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                    PlayVoiceOver(DialogTypes.Tutorial_Interrupted);
                }

                StopCoroutine(IntroTooLongCo());
                break;

            case DialogTypes.Intro_TooLong:
                break;

            case DialogTypes.Tutorial:
                break;
        }


    }

    IEnumerator IntroCo()
    {
        yield return new WaitForSeconds(3);

        PlayVoiceOver(DialogTypes.Intro);
        currentDialog = DialogTypes.Intro;

        StartCoroutine(IntroTooLongCo());
    }

    IEnumerator IntroTooLongCo()
    {
        yield return new WaitForSeconds(5);
        PlayVoiceOver(DialogTypes.Intro_TooLong);
        currentDialog = DialogTypes.Intro_TooLong;
    }

    public void PlayVoiceOver(DialogTypes dialogType)
    {
        if (audioSource == null || Dialogs == null || Dialogs.Length < (int)DialogTypes.MAX_DIALOG_TYPE) { return; }

        if (Dialogs[(int)dialogType] != null)
        {
            audioSource.PlayOneShot(Dialogs[(int)dialogType]);
        }
    }
}
