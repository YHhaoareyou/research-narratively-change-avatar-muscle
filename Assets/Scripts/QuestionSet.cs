using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSet : MonoBehaviour
{
    private static readonly string[] questions0 =
    {
        "[操作練習用問題] 1 + 1 = ?",
        "[操作練習用問題] 3 + 2 = ?"
    };

    private static readonly string[] questions1 =
    {
        "VRの経験頻度はどの程度ですか？",
        "筋トレをどのくらいの頻度でしていますか？",
        "筋トレに限らず、普段はどのくらいの頻度で運動していますか？",
    };
    
    private static readonly string[] questions2 =
    {
        "仮想身体が自分の身体のように感じられた。",
        "仮想の身体部位が自分の身体部位のように感じられた。",
        "仮想身体は人間らしさがあると感じた。",
        "仮想身体が自分に属するものと感じた。",
        "仮想身体の動作が、まるで自分自身の動作のように感じた。",
        "仮想身体の動作を、自分でコントロールしている気がした。",
        "仮想身体の動作を、自分で引き起こしている気がした。",
        "仮想身体の動作が、自分自身の動作と一致していた。",
        "自分自身の身体の形や見かけが変化した気がした。",
        "自分自身の体重に変化があった気がした。",
        "自分自身の身長に変化があった気がした。",
        "自分自身の体の横幅に変化があった気がした。"
    };

    public static string[][] sets = { questions0, questions1, questions2 };
}