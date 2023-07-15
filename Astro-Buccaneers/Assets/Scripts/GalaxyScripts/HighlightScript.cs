using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyScripts 
{
    public class HighlightScript : MonoBehaviour
    {
        // Define the initial color and the hover color with 50% transparency
        public Color initialColor = new Color(1f, 0f, 0f, 0.5f); // Red with 50% transparency
        public Color hoverColor = new Color(1f, 1f, 1f, 0.5f); // White with 50% transparency

        // Cache the SpriteRenderer component
        private SpriteRenderer spriteRenderer;

        // Initialize the script
        private void Start()
        {
            // Get the SpriteRenderer component
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Set the initial color
            spriteRenderer.color = initialColor;
        }

        // Change the color on hover
        private void OnMouseEnter()
        {
            spriteRenderer.color = hoverColor;
        }

        // Change the color back on exit
        private void OnMouseExit()
        {
            spriteRenderer.color = initialColor;
        }
    }
}
