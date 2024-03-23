using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CHARACTERS
{
    public class Character_Sprite : Character
    {
        private const string SPRITE_RENDERED_PARENT_NAME = "Renderers";
        private CanvasGroup rootCG => root.GetComponent < CanvasGroup>();

        public List<CharacterSpriteLayer> layers = new List<CharacterSpriteLayer>();
        public Character_Sprite(string name, GameObject prefab, CharacterConfigData config) : base(name, prefab, config)
        {
            rootCG.alpha = 0;

            GetLayers();

            Show();
            Debug.Log($"Created Sprite Character: '{name}'");
        }

        private void GetLayers()
        {
            Transform rendererRoot = animator.transform.Find(SPRITE_RENDERED_PARENT_NAME);
            if (rendererRoot == null)
                return;

            for(int i = 0; i < rendererRoot.transform.childCount; i++) //for renderer (only 1 for my chars)
            {
                Transform child = rendererRoot.transform.GetChild(i);

                Image rendererImage = child.GetComponent<Image>();
                
                if(rendererImage != null) //means have layer
                {
                    CharacterSpriteLayer layer = new CharacterSpriteLayer(rendererImage, i);
                    layers.Add(layer);
                    child.name = $"Layer: {i}";
                }
            }
        }

        public override IEnumerator ShowingOrHiding(bool show)
        {
            float targetAlpha = show ? 1f : 0;
            CanvasGroup self = rootCG;

            while(self.alpha != targetAlpha)
            {
                self.alpha = Mathf.MoveTowards(self.alpha, targetAlpha, 3f * Time.deltaTime);
                yield return null; //have reached target alpha
            }

            coRevealing = null;
            coHiding = null;
        }
    }
}