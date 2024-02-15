using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "Configs/SpriteConfig", fileName = "SpriteConfig", order = 52)]
    public class ImageConfig : ScriptableObject
    {
        [SerializeField] private List<Sprite> _sprites;

        public List<Sprite> Sprites => _sprites;
    }
}