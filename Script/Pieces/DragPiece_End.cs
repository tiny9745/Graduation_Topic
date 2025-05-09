using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Unity.Mathematics;

public class DragPiece_End : MonoBehaviour, IDropHandler
{
    public Ptest piece;
    public UI _ui;
    public Tips tips;
    static public List<int> currentCombination = new List<int>(); // 當前的組合
    public GameObject[] images_puzzle = new GameObject[4];
    public Image[] images_puzzle_col = new Image[4];
    public Image[] images_effect_col = new Image[4];
    public Image[] images_effect_change = new Image[4];
    public Button composite_col;
    private Color newColor = new Color(1, 1, 1, 0.0f);
    public Image button_image;
    private int puzzle_count = 0;
    static public int puzzle_color = -1, end_count = -1;
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    public Animator puzzle_flash_animator;

    void Start()
    {
        Skill_public_funtion.validSequences = Skill_public_funtion.validSequences_re
            .Select(hashset => new HashSet<int>(hashset)).ToList();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var droppedObject = eventData.pointerDrag;
        if (droppedObject == null) return;
        if (!int.TryParse(droppedObject.name, out int itemNumber) || itemNumber <= 0) return;

        var pieceData = Ptest.show[itemNumber - 1];
        string keyName = pieceData.PieceName;
        string keyColor = keyName.Substring(0, 3);
        currentCombination.Add(pieceData.PieceID);

        Ptest.show.Clear();
        PieceManager.Instance.Clear();

        int result = CheckCombination(currentCombination);

        if (result == -2)
        {
            audioSource.PlayOneShot(audioClip[0]);
            piece.page = 0;
            ResetCombination();
            tips.SetColor("defult");
            button_image.color = new Color(1, 1, 1, 0);
            return;
        }

        bool isFull = (result == 2);
        bool isPartial = (result == 1);

        if (isFull)
        {
            audioSource.PlayOneShot(audioClip[2]);
            _ui.putting_diary(false);
            newColor.a = 1;
            button_image.color = newColor;
            SetPuzzleColor(keyColor);
            composite_col.enabled = true;
            puzzle_flash_animator.SetBool("puzzle_flash", true);

            for (int i = 0; i < 4; i++)
            {
                images_effect_col[i].gameObject.SetActive(false);
                images_effect_change[i].gameObject.SetActive(true);
            }
        }
        else if (isPartial)
        {
            audioSource.PlayOneShot(audioClip[1]);
            newColor.a = 0;
            button_image.color = newColor;

            for (int i = 0; i < 4; i++)
            {
                images_effect_col[i].gameObject.SetActive(true);
                images_effect_change[i].gameObject.SetActive(false);
            }
        }

        if (isPartial)
        {
            foreach (var pd in Ptest.pickedPieces)
            {
                if (pd.PieceName == keyName)
                {
                    pd.survival_state = "Drag";
                }
                else if (pd.survival_state == "Alive")
                {
                    var test = new List<int>(currentCombination) { pd.PieceID };
                    bool can = Skill_public_funtion.validSequences
                        .Any(seq => new HashSet<int>(test).IsSubsetOf(seq));

                    if (can)
                    {
                        Ptest.show.Add(pd);
                        PieceManager.Instance.Add(pd);
                    }
                }
            }
        }

        if (puzzle_count > 0)
        {
            int idx = puzzle_count - 1;
            images_puzzle[idx].SetActive(true);
            Color col = keyColor switch
            {
                "Blu" => new Color(170 / 255f, 219 / 255f, 255 / 255f, 1),
                "Red" => new Color(225 / 255f, 190 / 255f, 190 / 255f, 1),
                "Grn" => new Color(170 / 255f, 255 / 255f, 160 / 255f, 1),
                "Prp" => new Color(230 / 255f, 195 / 255f, 255 / 255f, 1),
                "Yel" => new Color(225 / 255f, 225 / 255f, 195 / 255f, 1),
                _ => Color.white
            };
            images_puzzle_col[idx].color = col;
            tips.SetColor(keyColor);
        }
    }

    private int CheckCombination(List<int> combination)
    {
        HashSet<int> currentSet = new HashSet<int>(combination);

        for (int i = 0; i < Skill_public_funtion.validSequences.Count; i++)
        {
            HashSet<int> validSet = Skill_public_funtion.validSequences[i];

            if (currentSet.IsSubsetOf(validSet))
            {
                if (currentSet.SetEquals(validSet))
                {
                    int j = ((i + 1) % 5 == 0) ? 5 : (i + 1) % 5;
                    j += (int)(math.floor(i / 5) * 10);
                    end_count = j;
                    puzzle_count++;
                    Skill_public_funtion.mood_number = (int)math.floor(i / 5);
                    return 2;
                }
                else
                {
                    puzzle_count++;
                    return 1;
                }
            }
        }

        return -2;
    }

    public void ResetCombination()
    {
        _ui.putting_diary(true);
        Ptest.show.Clear();
        PieceManager.Instance.Clear();

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
        newColor.a = 0f;
    }

    public void Combination_End()
    {
        List<HashSet<int>> removedSequences = new List<HashSet<int>>();
        foreach (var sequence in Skill_public_funtion.validSequences)
        {
            if (new HashSet<int>(currentCombination).SetEquals(sequence))
            {
                removedSequences.Add(sequence);
            }
        }

        foreach (var sequence in removedSequences)
        {
            sequence.Clear();
            sequence.Add(999);
        }

        foreach (var piece in Ptest.pickedPieces)
        {
            if (currentCombination.Contains(piece.PieceID))
            {
                PieceManager.Instance.Remove(piece);
                piece.survival_state = "Alive";
            }
        }

        Ptest.show.Clear();
        PieceManager.Instance.Clear();
        currentCombination.Clear();

        foreach (var image in images_puzzle)
        {
            image.SetActive(false);
        }

        tips.SetColor("defult");
        puzzle_count = 0;
        newColor.a = 0f;
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
}
