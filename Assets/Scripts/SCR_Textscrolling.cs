using UnityEngine;
using UnityEngine.UI;

public class SCR_Textscrolling : MonoBehaviour
{
    public RectTransform contentTransform; // The ScrollingContent object (StoryText)
    public RectTransform maskTransform;   // The Mask object for clipping
    public float scrollSpeed = 50f;        // Speed of the auto-scroll

    private bool isScrolling = false;
    private float stopScrollOffset; // Dynamic stopping point based on mask and text position

    void Start()
    {
        Debug.Log($"Initial Position at Start: {contentTransform.localPosition.y}");

        // Position the text box so it starts below the mask
        contentTransform.localPosition = new Vector3(
            contentTransform.localPosition.x,
            -maskTransform.rect.height,
            contentTransform.localPosition.z
        );

        // Define stop boundary dynamically based on the text box’s initial position
        stopScrollOffset = contentTransform.localPosition.y + maskTransform.rect.height;
    }

    void Update()
    {
        if (isScrolling)
        {
            Debug.Log($"Scrolling is active! Current Position: {contentTransform.localPosition.y}");

            // Scroll the content upward
            contentTransform.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;

            // Stop scrolling when the text reaches the visible area
            if (contentTransform.localPosition.y >= stopScrollOffset)
            {
                Debug.Log("Text hit the stopping boundary. Freezing movement.");
                contentTransform.localPosition = new Vector3(
                    contentTransform.localPosition.x,
                    stopScrollOffset, // LOCK at the stopping boundary dynamically
                    contentTransform.localPosition.z
                );
                isScrolling = false; // Hard stop scrolling
            }
        }
    }

    public void StartScrolling()
    {
        Debug.Log("StartScrolling method triggered!");
        isScrolling = true;
    }

    public void ContinueScrolling()
    {
        Debug.Log("ContinueScrolling method triggered! Resuming movement.");
        isScrolling = true; // Allows player to manually resume scrolling when needed
    }

    private void ResetToStartPosition()
    {
        // Reset the text position below the mask
        contentTransform.localPosition = new Vector3(
            contentTransform.localPosition.x,
            -maskTransform.rect.height,
            contentTransform.localPosition.z
        );
        Debug.Log("Reset to below the mask for restart.");
    }
}