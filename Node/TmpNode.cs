using Ntreev.Library.Psd;
using UnityEngine;

namespace PsdUIExporter 
{
    class TmpNode : AbstractNode 
    {
        public TmpComponent tmpComp = null;

        public TmpNode(OperableVO operVo, PsdLayer layer, INode parentRect) : base(operVo, layer, parentRect) 
        {
        }

        public override void AddComponent() 
        {
            tmpComp = new TmpComponent(layer.Records.TextInfo);
            tmpComp.AddComponent(gameObject);
            SetTransform();

            base.AddComponent();
        }

        private void SetTransform() 
        {
            Vector3 anc = gameObject.GetComponent<RectTransform>().anchoredPosition3D;
            float widthScale = 1;

            if (!IsOneline()) 
            {
                widthScale = 1.05f;
            }
            else 
            {
                // tmpComp.tmp.enableWordWrapping = false;  // 单行文本禁用自动换行
            }

            int fontSize = this.tmpComp.textInfo.fontSize;
            float width = rect.width * widthScale + 2f;
            float height = rect.height + 2f;
            
            gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(
                anc.x + (width - rect.width)/2, 
                anc.y - (height - rect.height)/2, 
                anc.z
            );
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }

        // public void CreatePrefab() 
        // {
        //     base.CreatePrefab();
        // }

        private bool IsOneline() 
        {
            string tx = this.tmpComp.textInfo.text;
            return !tx.Contains("\r");
        }
    }
} 