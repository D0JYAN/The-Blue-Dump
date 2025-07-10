using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class DialogueStart : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private LocalizedString[] dialogueLines;

    private float typingTime = 0.05f;
    private float cooldownTime = 1.5f; // Tiempo para evitar reactivar el diálogo
    private float lastDialogueEndTime;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private bool lineaTerminada;


    void Update()
    {
        if (isPlayerInRange && TouchDetected() && Time.time - lastDialogueEndTime > cooldownTime)
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (lineaTerminada)
            {
                NextDialogueLine();
            }
        }
    }

    private bool TouchDetected()
    {
        return Input.GetMouseButtonDown(0) ||
               (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator ShowLine()
    {
        lineaTerminada = false;
        dialogueText.text = string.Empty;

        var localizedLine = dialogueLines[lineIndex];
        var loadingOperation = localizedLine.GetLocalizedStringAsync();

        yield return loadingOperation;

        string line = loadingOperation.Result;

        foreach (char ch in line)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }

        lineaTerminada = true;
    }

    private void EndDialogue()
    {
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        dialogueMark.SetActive(true);
        lastDialogueEndTime = Time.time; // Marca el tiempo en que terminó el diálogo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);

            if (didDialogueStart)
            {
                EndDialogue(); // Cierra el diálogo si el jugador se va
            }
        }
    }
}
