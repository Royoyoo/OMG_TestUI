using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class PicturePreview : MonoBehaviour
    {
        [SerializeField] private RawImage previewImage;


        public void Initialize(Texture picture)
        {
            previewImage.texture = picture;
        }
    }
}
