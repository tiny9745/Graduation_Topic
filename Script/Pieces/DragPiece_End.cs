using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.Mathematics;

public class DragPiece_End : MonoBehaviour, IDropHandler
{
    private List<HashSet<int>> validSequences;
    List<int> currentCombination = new List<int> { };

    void Start()
    {
        // 初始化測試用數列
        validSequences = new List<HashSet<int>>()
        {
            new HashSet<int> { 11, 16, 17 },
            new HashSet<int> { 11, 12, 17, 19 },
            new HashSet<int> { 13, 16, 18 },
            new HashSet<int> { 11, 14, 16 },
            new HashSet<int> { 11, 15 }
        };
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            // 嘗試將 droppedObject.name 轉換為數字
            if (int.TryParse(droppedObject.name, out int itemNumber) && itemNumber > 0)
            {
                string key_color = Ptest.show[itemNumber - 1].PieceName.Substring(0, 3);
                string key_name = Ptest.show[itemNumber - 1].PieceName;
                
                currentCombination.Add(Ptest.show[itemNumber - 1].PieceID);

                Ptest.show.Clear();
                PieceManager.Instance.Clear();

                // currentCombination.Clear(); // 清空之前的組合

                for (int i = Ptest.pickedPieces.Count - 1; i >= 0; i--)
                {
                    if(key_name == Ptest.pickedPieces[i].PieceName)
                    {
                        Ptest.pickedPieces[i].survival_state = "Drag";
                    }
                    else if (key_color == Ptest.pickedPieces[i].PieceName.Substring(0, 3) && Ptest.pickedPieces[i].survival_state == "Alive")
                    {
                        Ptest.show.Add(Ptest.pickedPieces[i]);
                        PieceManager.Instance.Add(Ptest.pickedPieces[i]);

                        // 添加到組合列表
                        Debug.Log("PieceName matches color: " + Ptest.pickedPieces[i].PieceName + ", key_color: " + key_color);
                    }
                }

                // 檢查組合
                bool result = CheckCombination(currentCombination);
                Debug.Log("CheckCombination result: " + result);
                ShowCombination(currentCombination); // 顯示當前組合
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

    // 顯示目前組合
    private void ShowCombination(List<int> combination)
    {
        string combinationString = string.Join(", ", combination);
        Debug.Log("Current Combination: [" + combinationString + "]");
    }
}
