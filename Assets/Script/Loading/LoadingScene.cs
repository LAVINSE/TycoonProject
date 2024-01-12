using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    #region 변수
    [SerializeField] private TMP_Text loadingText;
    [SerializeField] private Image loadingImg;
    [SerializeField] private float rotateSpeed;

    private static string nextScene;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    /** 씬을 로드한다 */
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    /** 로딩중일때 Bar를 채운다 */
    private IEnumerator LoadSceneProcess()
    {
        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(nextScene);
        asyncOper.allowSceneActivation = false;

        float loadingPercent = 0f;

        float unsacledTimer1 = 0.0f;
        float unsacledTimer2 = 0.0f;

        while (!asyncOper.isDone)
        {
            yield return null;

            // 이미지 회전
            loadingImg.transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.unscaledDeltaTime));

            // 씬 로딩이 완료가 안됐을 경우
            if (asyncOper.progress < 0.9f)
            {
                unsacledTimer1 += Time.unscaledDeltaTime;

                if (loadingPercent <= 89f)
                {
                    loadingPercent = Mathf.Lerp(loadingPercent, 89f, unsacledTimer1);
                    loadingText.text = Mathf.Round(loadingPercent).ToString() + " %";
                }
            }
            else
            {
                unsacledTimer2 += Time.unscaledDeltaTime;

                loadingPercent = 89f;
                loadingPercent = Mathf.Lerp(loadingPercent, 100f, unsacledTimer2);
                // 반올림
                loadingText.text = Mathf.Round(loadingPercent).ToString() + " %";

                // loadingPercent가 100이라면 씬 전환
                if (loadingPercent == 100f)
                {
                    asyncOper.allowSceneActivation = true;
                }
            }
        }
    }
    #endregion // 함수
}
