using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSet : MonoBehaviour
{
    private static readonly string[] questions0 =
    {
        "[������K�p���] 1 + 1 = ?",
        "[������K�p���] 3 + 2 = ?"
    };

    private static readonly string[] questions1 =
    {
        "VR�̌o���p�x�͂ǂ̒��x�ł����H",
        "�؃g�����ǂ̂��炢�̕p�x�ł��Ă��܂����H",
        "�؃g���Ɍ��炸�A���i�͂ǂ̂��炢�̕p�x�ŉ^�����Ă��܂����H",
    };
    
    private static readonly string[] questions2 =
    {
        "���z�g�̂������̐g�̂̂悤�Ɋ�����ꂽ�B",
        "���z�̐g�̕��ʂ������̐g�̕��ʂ̂悤�Ɋ�����ꂽ�B",
        "���z�g�̂͐l�Ԃ炵��������Ɗ������B",
        "���z�g�̂������ɑ�������̂Ɗ������B",
        "���z�g�̂̓��삪�A�܂�Ŏ������g�̓���̂悤�Ɋ������B",
        "���z�g�̂̓�����A�����ŃR���g���[�����Ă���C�������B",
        "���z�g�̂̓�����A�����ň����N�����Ă���C�������B",
        "���z�g�̂̓��삪�A�������g�̓���ƈ�v���Ă����B",
        "�������g�̐g�̂̌`�〈�������ω������C�������B",
        "�������g�̑̏d�ɕω����������C�������B",
        "�������g�̐g���ɕω����������C�������B",
        "�������g�̑̂̉����ɕω����������C�������B"
    };

    public static string[][] sets = { questions0, questions1, questions2 };
}