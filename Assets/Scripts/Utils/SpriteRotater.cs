using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public class RotateSpecificSprites : MonoBehaviour
    {
        [SerializeField] private List<SpecificSprite> _specificSprites = new List<SpecificSprite>();

        [System.Serializable]
        private struct SpecificSprite
        {
            public Sprite sprite;
            public float spriteAngle; //Нужный угол поворота
        }

        public void RotateSprites(SpriteRenderer[] renderers)
        {
            foreach (var renderer in renderers)
            {
                var result = _specificSprites.FirstOrDefault(x => x.sprite == renderer.sprite);

                if (result.sprite != null)
                {
                    renderer.transform.rotation = Quaternion.Euler(renderer.transform.rotation.x,
                        renderer.transform.rotation.y, result.spriteAngle);
                }
            }
        }
    }
}