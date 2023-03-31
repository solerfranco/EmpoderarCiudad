using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
    private class GraphicsIndex
    {
        public int index;
        public string name;

        public GraphicsIndex(int index, string name)
        {
            this.index = index;
            this.name = name;
        }
    }

    private GraphicsIndex[] graphics =
    {
        new GraphicsIndex(0, "Muy Baja"),
        new GraphicsIndex(1, "Baja"),
        new GraphicsIndex(2, "Media"),
        new GraphicsIndex(3, "Alta"),
        new GraphicsIndex(4, "Muy Alta"),
        new GraphicsIndex(5, "Ultra"),
    };

    public GameObject previousButton;
    public GameObject nextButton;
    public TextMeshProUGUI textValue;

    private int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
            previousButton.SetActive(index > 0);
            nextButton.SetActive(index < graphics.Length - 1);
            ChangeGraphics();
            textValue.text = graphics[index].name;
        }
    }
    private int index;

    private void ChangeGraphics()
    {
        QualitySettings.SetQualityLevel(Index);
    }

    public void IncrementIndex() { Index++; }

    public void DecrementIndex() { Index--; }

    private void Awake()
    {
        Index = QualitySettings.GetQualityLevel();
    }
}
