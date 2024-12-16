using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;


public class DragPiece_End : MonoBehaviour, IDropHandler
{
    private List<HashSet<int>> validSequences;
    List<int> currentCombination = new List<int> { };
    void Start()
    {
        // 初始化數列，使用 HashSet 存儲數列以忽略順序
        validSequences = new List<HashSet<int>>()
        {
            new HashSet<int> { 11, 16, 17 },
            new HashSet<int> { 11, 12, 17, 19 },
            new HashSet<int> { 13, 16, 18 },
            new HashSet<int> { 11, 14, 16 },
            new HashSet<int> { 11, 15 }
        };

        // 測試組合
        // currentCombination.Add(16);
        // Debug.Log("List:" + CheckCombination(currentCombination));
        // ShowCombination(currentCombination);
    }
    // Update is called once per frame
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            if (int.TryParse(droppedObject.name, out int itemNumber))
            {
                // currentCombination.Add(Ptest.pickedPieces[itemNumber - 1].PieceID);
                // Debug.Log("PieceName:"+Ptest.pickedPieces[itemNumber - 1].PieceName+",PieceID:"+Ptest.pickedPieces[itemNumber - 1].PieceID);
                // Debug.Log("List:" + CheckCombination(currentCombination));
                // ShowCombination(currentCombination);
                // if (CheckCombination(currentCombination) == false)
                // {
                //     Debug.Log("nono");
                // }
                // else
                // {
                //     Debug.Log("yesyes");
                // }

                PieceManager.Instance.Remove(Ptest.pickedPieces[itemNumber - 1]);
                string key_color = Ptest.pickedPieces[itemNumber - 1].PieceName.Substring(0, 3);
                Ptest.pickedPieces[itemNumber - 1].survival_state = "Drag";
                Ptest.pickedPieces.RemoveAt(itemNumber - 1);
                for (int i = 0; i < Ptest.pickedPieces.Count; i++)
                {
                    if (key_color != Ptest.pickedPieces[i].PieceName.Substring(0, 3))
                    {
                        Ptest.pickedPieces[i].survival_state = "Remove";
                        PieceManager.Instance.Remove(Ptest.pickedPieces[i]);
                    }
                    else
                    {
                        Debug.Log("PieceName is not the same color as " + Ptest.pickedPieces[i].PieceName + ",key_color:" + key_color);
                    }
                }
            }
        }
    }

    // 定義 Trie 節點結構
    public class TrieNode
    {
        public Dictionary<int, TrieNode> children = new Dictionary<int, TrieNode>();
        public bool isCompleteSequence = false; // 是否為數列的結尾
    }
    // 檢查當前組合是否可能完成某數列
    private bool CheckCombination(List<int> combination)
    {
        // 將當前組合轉為排序集合
        HashSet<int> combinationSet = new HashSet<int>(combination);

        foreach (HashSet<int> sequence in validSequences)
        {
            if (combinationSet.IsSubsetOf(sequence))
            {
                return true; // 若組合為某數列的子集合，則可能完成
            }
        }

        return false; // 若無法匹配任何數列，返回 false
    }
    private void ShowCombination(List<int> combination)
    {
        // 使用 string.Join 將數列轉為文字
        string combinationString = string.Join(", ", combination);
        Debug.Log("Current Combination: [" + combinationString + "]");
    }
}
