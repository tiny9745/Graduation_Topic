using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Unity.Mathematics;

public class DragPiece_End : MonoBehaviour, IDropHandler
{
    public Ptest piece; public UI _ui;
    static public List<int> currentCombination = new List<int>(); // 當前的組合
    public GameObject[] images_puzzle = new GameObject[4]; // 圖片陣列
    public Image[] images_puzzle_col = new Image[4]; // 圖片顏色陣列
    public Image[] images_effect_col = new Image[4]; // 碎片裝飾陣列
    public Image[] images_effect_change = new Image[4]; // 碎片更換陣列
    public Button composite_col;
    private Color newColor = new Color(1, 1, 1, 0.5f); // 按鈕透明度顏色
    public Image button_image; // 按鈕圖像
    private int puzzle_count = 0; // 碎片數量計數
    static public int puzzle_color = 2, end_count = -1; // 碎片顏色（默認為 2）
    public AudioSource audioSource; // 音效來源
    public AudioClip[] audioClip; // 音效片段

    void Start()
    {
        // 初始化有效的組合數列
        Skill_public_funtion.validSequences = Skill_public_funtion.validSequences_re.Select(hashset => new HashSet<int>(hashset)).ToList(); // 轉成 List<HashSet<int>>
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            if (int.TryParse(droppedObject.name, out int itemNumber) && itemNumber > 0)
            {
                if (static_parameters.teaching_stop == 8) static_parameters.teaching_stop = 9;
                // 獲取拖放物件的相關數據
                string key_color = Ptest.show[itemNumber - 1].PieceName.Substring(0, 3);
                string key_name = Ptest.show[itemNumber - 1].PieceName;
                currentCombination.Add(Ptest.show[itemNumber - 1].PieceID);

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
                // animation_col.SetInteger("fragment_control", checkResult);

                if (checkResult == -2)
                {
                    audioSource.PlayOneShot(audioClip[0]);
                    piece.page = 0;
                    ResetCombination();
                }
                else if (checkResult == 2)
                {
                    audioSource.PlayOneShot(audioClip[2]);
                    _ui.putting_diary(false);
                    newColor.a = 1;
                    SetPuzzleColor(key_color);
                    composite_col.enabled = true;
                    for (int i = 0; i < 4; i++)
                    {
                        images_effect_col[i].gameObject.SetActive(false);
                        images_effect_change[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    audioSource.PlayOneShot(audioClip[1]);
                }
                if (checkResult != 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        images_effect_col[i].gameObject.SetActive(true);
                        images_effect_change[i].gameObject.SetActive(false);
                    }
                }

                if (puzzle_count != 0)
                {
                    _ui.putting_diary(false);
                    images_puzzle[puzzle_count - 1].SetActive(true);
                    if (key_color == "Blu")
                    {
                        images_puzzle_col[puzzle_count - 1].color = new Color(170f / 255f, 219f / 255f, 255f / 255f, 1);
                    }
                    if (key_color == "Red")
                    {
                        images_puzzle_col[puzzle_count - 1].color = new Color(225f / 255f, 190f / 255f, 190f / 255f, 1);
                    }
                    if (key_color == "Grn")
                    {
                        images_puzzle_col[puzzle_count - 1].color = new Color(170f / 255f, 255f / 255f, 160f / 255f, 1);
                    }
                    if (key_color == "Prp")
                    {
                        images_puzzle_col[puzzle_count - 1].color = new Color(230f / 255f, 195f / 255f, 255f / 255f, 1);
                    }
                    if (key_color == "Yel")
                    {
                        images_puzzle_col[puzzle_count - 1].color = new Color(225f / 255f, 225f / 255f, 195f / 255f, 1);
                    }
                    if (checkResult != 2) newColor.a = 0.5f;
                }
            }
        }
        button_image.color = newColor;
    }

    private int CheckCombination(List<int> combination)
    {
        HashSet<int> combinationSet = new HashSet<int>(combination);
        if (Ptest.show.Count == 0)
        {
            return -2;
        }

        // 先檢查是否有完全匹配的組合
        for (int i = 0; i < Skill_public_funtion.validSequences.Count; i++)
        {
            HashSet<int> sequence = Skill_public_funtion.validSequences[i];

            List<int> combinationList = new List<int>(combinationSet);
            List<int> sequenceList = new List<int>(sequence);

            combinationList.Sort();
            sequenceList.Sort();

            if (combinationList.SequenceEqual(sequenceList))
            {
                int j = ((i + 1) % 5 == 0) ? 5 : (i + 1) % 5;
                j += (int)(math.floor(i / 5) * 10);
                end_count = j;
                puzzle_count++;
                Skill_public_funtion.mood_number = (int)math.floor(i / 5);
                return 2;
            }
        }

        // 若沒有完全匹配的組合，再檢查是否為子集
        for (int i = 0; i < Skill_public_funtion.validSequences.Count; i++)
        {
            HashSet<int> sequence = Skill_public_funtion.validSequences[i];

            List<int> combinationList = new List<int>(combinationSet);
            List<int> sequenceList = new List<int>(sequence);

            combinationList.Sort();
            sequenceList.Sort();

            if (IsSubset(combinationList, sequenceList))
            {
                puzzle_count++;
                return 1;
            }
        }
        return -2;
    }

    public void ResetCombination()
    {
        _ui.putting_diary(true);
        Ptest.show.Clear();
        PieceManager.Instance.Clear();
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
        // 儲存要移除的組合
        List<HashSet<int>> removedSequences = new List<HashSet<int>>();
        foreach (var sequence in Skill_public_funtion.validSequences)
        {
            // 檢查 currentCombination 是否等於 validSequences 的某一項
            if (new HashSet<int>(currentCombination).SetEquals(sequence))
            {
                removedSequences.Add(sequence);
            }
        }

        // 從 validSequences 中移除符合條件的組合
        foreach (var sequence in removedSequences)
        {
            sequence.Clear(); // 清空原有內容
            sequence.Add(999); // 添加 999
        }

        // 清空 currentCombination 並重置碎片顯示
        foreach (var piece in Ptest.pickedPieces)
        {
            if (currentCombination.Contains(piece.PieceID)) // 確定為 List 中數值
            {
                PieceManager.Instance.Remove(piece);
                piece.survival_state = "Alive";
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
