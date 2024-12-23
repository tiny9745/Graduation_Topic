using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;

public class DragPiece_End : MonoBehaviour, IDropHandler
{
    private List<HashSet<int>> validSequences;
    List<int> currentCombination = new List<int> { };
    public GameObject[] images_puzzle = new GameObject[4];
    public Button composite_col; Color newColor = new Color(1, 1, 1, 0.5f);
    public UnityEngine.UI.Image button_image;
    int puzzle_count = 0;
    static public int puzzle_color = 2;
    public Animator animation_col;

    void Start()
    {
        // 碎片組合數列
        validSequences = new List<HashSet<int>>()
        {
            new HashSet<int> { 11, 16, 17 },
            new HashSet<int> { 11, 12, 17, 19 },
            new HashSet<int> { 13, 16, 18 },
            new HashSet<int> { 11, 14, 16 },
            new HashSet<int> { 11, 15 },

            new HashSet<int> { 21, 22, 26 },
            new HashSet<int> { 22, 26 },
            new HashSet<int> { 22, 24 },
            new HashSet<int> { 22, 23, 25, 26 },
            new HashSet<int> { 22, 24, 25, 26 },

            new HashSet<int> { 42, 44 },
            new HashSet<int> { 42, 44, 45 },
            new HashSet<int> { 41, 42, 44 },
            new HashSet<int> { 43, 44 },
            new HashSet<int> { 42, 44, 46 },

            new HashSet<int> { 1, 4 ,5, 6 },
            new HashSet<int> { 2, 4, 6 },
            new HashSet<int> { 1, 3 },
            new HashSet<int> { 2, 6 },
            new HashSet<int> { 1, 2, 5, 6 },

            new HashSet<int> { 32, 36 ,37 },
            new HashSet<int> { 35, 36, 37 },
            new HashSet<int> { 32, 34, 35, 39 },
            new HashSet<int> { 35, 37, 38 },
            new HashSet<int> { 31, 33 }
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
                    if (key_name == Ptest.pickedPieces[i].PieceName)
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

                // 檢查組合是否可能完成某數列
                int checkResult = CheckCombination(currentCombination);
                animation_col.SetInteger("fragment_control", checkResult);
                if (checkResult == -2)
                {
                    for (int j = 0; j < Ptest.pickedPieces.Count; j++)
                    {
                        for (int i = 0; i < currentCombination.Count; i++)
                        {
                            if (currentCombination[i] == Ptest.pickedPieces[j].PieceID)
                            {
                                Ptest.pickedPieces[j].survival_state = "Alive";
                                Debug.Log("No.:" + i + ",PieceName:" + Ptest.pickedPieces[j].PieceName + ",survival_state:" + Ptest.pickedPieces[j].survival_state);
                            }
                        }
                        Ptest.show.Add(Ptest.pickedPieces[j]);
                        PieceManager.Instance.Add(Ptest.pickedPieces[j]);
                    }
                    currentCombination.Clear();
                    for (int i = 0; i < images_puzzle.Length; i++)
                    {
                        images_puzzle[i].SetActive(false);
                    }
                    puzzle_count = 0;
                    newColor.a = 0.5f;
                }
                else if (checkResult == 2)
                {
                    newColor.a = 1;
                    if (key_color == "Blu") puzzle_color = 0;
                    else if (key_color == "Red") puzzle_color = 1;
                    else if (key_color == "Grn") puzzle_color = 2;
                    else if (key_color == "Prp") puzzle_color = 3;
                    else if (key_color == "Yel") puzzle_color = 4;
                    composite_col.enabled = true;
                }
                else if (puzzle_count == 1)
                {
                    images_puzzle[puzzle_count - 1].SetActive(true);
                    Debug.Log("puzzle_count: " + puzzle_count);
                    newColor.a = 0.5f;
                }
                ShowCombination(currentCombination); // 顯示當前組合
            }
        }
        button_image.color = newColor;
    }

    // 定義 Trie 節點結構
    public class TrieNode
    {
        public Dictionary<int, TrieNode> children = new Dictionary<int, TrieNode>();
        public bool isCompleteSequence = false; // 是否為數列的結尾
    }

    // 檢查當前組合是否可能完成某數列
    private int CheckCombination(List<int> combination)
    {
        HashSet<int> combinationSet = new HashSet<int>(combination);

        foreach (HashSet<int> sequence in validSequences)
        {
            if (combinationSet.IsSubsetOf(sequence))
            {
                if (Ptest.show.Count == 0)
                {
                    return -2;
                }
                else
                {
                    puzzle_count++;
                    return 1; // 若組合為某數列的子集合，則可能完成
                }
            }
            if (combinationSet.SetEquals(sequence))
            {
                return 2; // 若完全匹配，返回 true
            }
        }
        return -2; // 若無法匹配任何數列，返回 false
    }

    // 顯示目前組合
    private void ShowCombination(List<int> combination)
    {
        string combinationString = string.Join(", ", combination);
        Debug.Log("Current Combination: [" + combinationString + "]");
    }
}
