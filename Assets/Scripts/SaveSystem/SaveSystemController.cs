using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public class SaveSystemController : MonoBehaviour
    {
        [field: SerializeField] public bool IsUseSystem { get; private set; }
        public JsonDataContext JsonDataContext { get; private set; }
        public bool IsLoad { get; private set; }

        [Inject]
        private void Construct(JsonDataContext jsonDataContext) => JsonDataContext = jsonDataContext;

        private async void Save()
        {
            if(IsUseSystem == false) return;
            await JsonDataContext.Save();
        }

        private async void Load()
        {
            if(IsUseSystem == false) return;
            await JsonDataContext.Load();
            IsLoad = true;
        }

        private void Awake()
        {
            Load();
        }

        private void OnDisable()
        {
            Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}