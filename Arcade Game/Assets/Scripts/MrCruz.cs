using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogTypes { Intro, Intro_TooLong, Tutorial, Tutorial_Interrupted, Tutorial_Completed, MainQuest, FiveMinWarning, OneMinWarning, BadEnding, NotEnoughTicket, EnoughTicket, MAX_DIALOG_TYPE };

public class MrCruz : MonoBehaviour
{
    protected static AudioSource audioSource;

    public AudioClip[] Dialogs;

    public static AudioClip[] StaticDialogs;

    public static DialogTypes currentDialog;

    public static int WarningCount = 0;

    public static bool IsTalking
    {
        get
        {
            return audioSource.isPlaying;
        }
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        currentDialog = DialogTypes.MAX_DIALOG_TYPE;

        if (Dialogs != null && Dialogs.Length > 0)
        {
            StaticDialogs = new AudioClip[Dialogs.Length];

            for(int i = 0; i < Dialogs.Length; ++i)
            {
                StaticDialogs[i] = Dialogs[i];
            }
        }
    }

    private void Start()
    {
        PlayVoiceOver(DialogTypes.Intro, 3);
        currentDialog = DialogTypes.Intro;

        StartCoroutine(IntroTooLongCo());
    }

    IEnumerator IntroTooLongCo()
    {
        yield return new WaitForSeconds(22);

        if (currentDialog == DialogTypes.Intro)
        {
            PlayVoiceOver(DialogTypes.Intro_TooLong, 0);
            currentDialog = DialogTypes.Intro_TooLong;
        }
    }


    public void StopDialogs()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
            StopAllCoroutines();
        }
    }

    public static void UpdateDialog()
    {
        if (audioSource == null) { Debug.LogWarning("Game Manager cannot find AudioSource.");  return; }

        switch (currentDialog)
        {

            case DialogTypes.Intro:
                if (IsTalking)
                {
                    PlayVoiceOver(DialogTypes.Tutorial_Interrupted);
                }
                currentDialog = DialogTypes.Intro_TooLong;
                break;

            case DialogTypes.Intro_TooLong:
                PlayVoiceOver(DialogTypes.Tutorial);
                currentDialog = DialogTypes.Tutorial;
                break;

            case DialogTypes.Tutorial:
                if (IsTalking)
                {
                    PlayVoiceOver(DialogTypes.Tutorial_Interrupted);
                }
                else
                {
                    PlayVoiceOver(DialogTypes.Tutorial_Completed);
                }
                currentDialog = DialogTypes.Tutorial_Completed;
                break;

            case DialogTypes.Tutorial_Completed:
                PlayVoiceOver(DialogTypes.MainQuest);
                currentDialog = DialogTypes.MainQuest;
                break;
        }


    }

    public static void PlayVoiceOver(DialogTypes dialogType, float delay = 0)
    {
        if (audioSource == null || StaticDialogs == null || StaticDialogs.Length < (int)DialogTypes.MAX_DIALOG_TYPE) { return; }

        if (StaticDialogs[(int)dialogType] != null)
        {
            audioSource.clip = StaticDialogs[(int)dialogType];
            audioSource.PlayDelayed(delay);
        }
    }

    private void Update()
    {
        /*
        if (GameManager.TimeLeft <= 1 && currentDialog == DialogTypes.OneMinWarning)
        {
            PlayVoiceOver(DialogTypes.BadEnding);
            currentDialog = DialogTypes.BadEnding;
        }
        else if (GameManager.TimeLeft <= 60 && currentDialog == DialogTypes.FiveMinWarning)
        {
            PlayVoiceOver(DialogTypes.OneMinWarning);
            currentDialog = DialogTypes.OneMinWarning;
        }
        else if (GameManager.TimeLeft <= 300 && currentDialog == DialogTypes.MainQuest)
        {
            PlayVoiceOver(DialogTypes.FiveMinWarning);
            currentDialog = DialogTypes.FiveMinWarning;
        }
        */
    }
}
