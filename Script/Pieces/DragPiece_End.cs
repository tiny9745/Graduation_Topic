using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


public class DragPiece_End : MonoBehaviour, IDropHandler
{
    private List<HashSet<int>> validSequences; // 有效的組合數列
    static public List<int> currentCombination = new List<int>(); // 當前的組合
    public GameObject[] images_puzzle = new GameObject[4]; // 圖片陣列
    public Image[]images_puzzle_col = new Image[4]; // 圖片顏色陣列
    public Button composite_col;
    private Color newColor = new Color(1, 1, 1, 0.5f); // 按鈕透明度顏色
    public UnityEngine.UI.Image button_image; // 按鈕圖像
    private int puzzle_count = 0; // 碎片數量計數
    static public int puzzle_color = 2; // 碎片顏色（默認為 2）
    public Animator animation_col; // 動畫控制器

    static public int end_count = -1;

    void Start()
    {
        // 初始化有效的組合數列
        validSequences = new List<HashSet<int>>()
        {
            new HashSet<int> { 11, 15 },
            // new HashSet<int> { 11, 16, 17 },
            // new HashSet<int> { 13, 16, 18 },
            new HashSet<int> { 11, 14, 16 },
            // new HashSet<int> { 11, 12, 17, 19 },
            new HashSet<int> { 22, 26 },
            new HashSet<int> { 22, 24 },
            // new HashSet<int> { 21, 22, 26 },
            // new HashSet<int> { 22, 23, 25, 26 },
            // new HashSet<int> { 22, 24, 25, 26 },
            new HashSet<int> { 42, 44 },
            new HashSet<int> { 43, 44 },
            // new HashSet<int> { 42, 44, 45 },
            // new HashSet<int> { 41, 42, 44 },
            // new HashSet<int> { 42, 44, 46 },
            new HashSet<int> { 1, 3 },
            new HashSet<int> { 2, 6 },
            // new HashSet<int> { 2, 4, 6 },
            // new HashSet<int> { 1, 4, 5, 6 },
            // new HashSet<int> { 1, 2, 5, 6 },
            // new HashSet<int> { 31, 33 },
            // new HashSet<int> { 32, 36, 37 },
            // new HashSet<int> { 35, 36, 37 },
            // new HashSet<int> { 35, 37, 38 },
            // new HashSet<int> { 32, 34, 35, 39 }
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ResetCombination();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            if (int.TryParse(droppedObject.name, out int itemNumber) && itemNumber > 0)
            {
                // 獲取拖放物件的相關數據
                string key_color = Ptest.show[itemNumber - 1].PieceName.Substring(0, 3);
                string key_name = Ptest.show[itemNumber - 1].PieceName;
                currentCombination.Add(Ptest.show[itemNumber - 1].PieceID);
                Debug.Log("Ptest.show[itemNumber - 1].PieceID"+Ptest.show[itemNumber - 1].PieceID);

                // 清除並重新整理顯示的碎片
                Ptest.show.Clear();
                PieceManager.Instance.Clear();

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
                    }
                }

                // 檢查組合並處理結果
                int checkResult = CheckCombination(currentCombination);
                animation_col.SetInteger("fragment_control", checkResult);

                if (checkResult == -2)
                {
                    ResetCombination();
                }
                else if (checkResult == 2)
                {
                    newColor.a = 1;
                    SetPuzzleColor(key_color);
                    composite_col.enabled = true;
                }

                if (puzzle_count != 0)
                {
                    images_puzzle[puzzle_count - 1].SetActive(true);
                    if(key_color == "Blu") images_puzzle_col[puzzle_count - 1].color = new Color(0, 0, 255f/255f, 0.6f);
                    if(key_color == "Red") images_puzzle_col[puzzle_count - 1].color = new Color(255f/255f, 0, 0, 0.6f);
                    if(key_color == "Grn") images_puzzle_col[puzzle_count - 1].color = new Color(0, 255f/255f, 0, 0.6f);
                    if(key_color == "Prp") images_puzzle_col[puzzle_count - 1].color = new Color(255f/255f, 0f, 255f/255f, 0.6f);
                    if(key_color == "Yel") images_puzzle_col[puzzle_count - 1].color = new Color(255f/255f, 255f/255f, 0, 0.6f);
                    if (checkResult != 2) newColor.a = 0.5f;
                }
            }
        }
        button_image.color = newColor;
    }

    private int CheckCombination(List<int> combination)
    {
        HashSet<int> combinationSet = new HashSet<int>(combination);

        for (int i = 0; i < validSequences.Count; i++)
        {
            HashSet<int> sequence = validSequences[i];

            // 將數列標準化並排序
            List<int> combinationList = new List<int>(combinationSet);
            List<int> sequenceList = new List<int>(sequence);

            combinationList.Sort();
            sequenceList.Sort();

            if (Ptest.show.Count == 0)
            {
                return -2;
            }

            if (combinationList.SequenceEqual(sequenceList))
            {
                end_count = i;
                puzzle_count++;
                return 2;
            }

            if (IsSubset(combinationList, sequenceList))
            {
                puzzle_count++;
                return 1;
            }
        }
        return -2;
    }


    private void ResetCombination()
    {
        // 重置當前組合
        foreach (var piece in Ptest.pickedPieces)
        {
            if (currentCombination.Contains(piece.PieceID))
            {
                piece.survival_state = "Alive";
            }
            Ptest.show.Add(piece);
            PieceManager.Instance.Add(piece);
        }
        currentCombination.Clear();
        foreach (var image in images_puzzle)
        {
            image.SetActive(false);
        }
        puzzle_count = 0;
        newColor.a = 0.5f;
    }


    public void Combination_End()
    {
        foreach (var piece in Ptest.pickedPieces)
        {
            if (currentCombination.Contains(piece.PieceID))//確定為List中數值
            {
                PieceManager.Instance.Remove(piece);
                piece.survival_state = "Dead";
            }
            Ptest.show.Clear();
            PieceManager.Instance.Clear();
        }
        currentCombination.Clear();
        foreach (var image in images_puzzle)
        {
            image.SetActive(false);
        }
        puzzle_count = 0;
        newColor.a = 0.5f;
    }

    private void SetPuzzleColor(string key_color)
    {
        switch (key_color)
        {
            case "Blu": puzzle_color = 0; break;
            case "Red": puzzle_color = 1; break;
            case "Grn": puzzle_color = 2; break;
            case "Prp": puzzle_color = 3; break;
            case "Yel": puzzle_color = 4; break;
        }
    }

    private bool IsSubset(List<int> subset, List<int> superset)
    {
        return new HashSet<int>(subset).IsSubsetOf(superset);
    }
}
