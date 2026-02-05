using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ntreev.Library.Psd;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace PsdUIExporter 
{
    class TmpComponent : IComponent 
    {
        public TextInfo textInfo = null;
        public Color color;
        public int fontSize = 16;
        public String fontName = null;

        public TextMeshProUGUI tmp = null;

        public TmpComponent(TextInfo textInfo) 
        {
            this.textInfo = textInfo;
            color = new Color(textInfo.color[0], textInfo.color[1], textInfo.color[2], textInfo.color[3]);
            fontSize = textInfo.fontSize;
            fontName = textInfo.fontName;
        }

        public override void AddComponent(GameObject go) 
        {
            tmp = go.AddComponent<TextMeshProUGUI>();
            tmp.fontSize = fontSize;
            tmp.color = this.color;
            tmp.text = this.textInfo.text.Replace("\r", "\n");
            tmp.overflowMode = TextOverflowModes.Overflow;
            tmp.alignment = TextAlignmentOptions.MidlineLeft;
            tmp.textWrappingMode = TextWrappingModes.NoWrap;
            tmp.raycastTarget = false;
        }
    }
} 