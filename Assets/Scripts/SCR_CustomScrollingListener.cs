using Fungus;
using UnityEngine;

public class SCR_CustomScrollingListener : MonoBehaviour, IWriterListener
{
    // Reference to your scrolling manager script (responsible for moving the text)
    public SCR_Textscrolling scrollingManager;

    // This method is called for each glyph (character) displayed by the Writer
    public void OnGlyph()
    {
        // No scrolling action needed for individual glyphs, so this is left empty
    }

    // This method is triggered when the Writer starts writing text
    public void OnStart(AudioClip audioClip)
    {
        Debug.Log("OnStart called in SCR_CustomScrollingListener!"); // Log for debugging
        if (scrollingManager != null)
        {
            scrollingManager.StartScrolling(); // Trigger scrolling behavior
        }
    }

    // This method is called when the Writer pauses its text display (e.g., for punctuation)
    public void OnPause()
    {
        // No specific action needed for pause
    }

    // This method is triggered when the Writer resumes text display after a pause
    public void OnResume()
    {
        // No special behavior needed on resume, so this is left empty
    }

    // This method is called when the Writer finishes writing all the text
    public void OnEnd(bool stopAudio)
    {
        // Scrolling can optionally be stopped here if required
    }

    // This method is triggered when voiceover audio starts playing (if used in Fungus)
    public void OnVoiceover(AudioClip voiceoverClip)
    {
        // Not used in this implementation, but available for future needs
    }

    // This method is triggered when all the words in the dialog are written
    public void OnAllWordsWritten()
    {
        // No specific action is taken here, but this could be used for custom logic
    }

    // This method is called when the player provides input (e.g., clicking to continue)
    public void OnInput()
    {
        // Not used here, but available if scrolling needs to react to player input
    }
}