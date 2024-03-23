using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CHARACTERS
{
    public class CharacterSpriteLayer
    {
        private CharacterManager characterManager => CharacterManager.instance;
        public int layer { get; private set; } = 0;
        public Image renderer { get; private set; } = null;
        public CanvasGroup rendererCG => renderer.GetComponent<CanvasGroup>();

        private List<CanvasGroup> olderRenderers = new List<CanvasGroup>();

    }
}