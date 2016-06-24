using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    
    public GameObject hazard;// obiekt przeciwnika
    public GameObject hazard2;// drugi obiekt przeciwnika
    public Vector3 spawnValues;//Vector ograniczający miejsce pojawiania się przeciwników
    public int hazardCount;//ilość przeciwników

    public float spawnWait;//interwał czasowy między falami przeciwników
    public float startWait;
    public float waveWait;


    public GUIText scoreText;
    private int score; //wynik - ilosc zniszczonych przeciwników

    //elementy GUI
    public GUIText restartText;
    public GUIText gameOvertext;

    private bool restart;
    private bool gameOver;

    // Use this for initialization
    void Start()
    {

        //flagi
        restart = false;
        gameOver = false;

        //ukrycie tekstu GUI
        restartText.text = "";
        gameOvertext.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine( SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    //tworzy serię przeciwników
    IEnumerator SpawnWaves()
    {


        yield return new WaitForSeconds(startWait);// tworzenie interwału czasowego przed pojawieniem się pierwszej fali przeciwników

        //pętla tworząca nowych przeciwników
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //tworzenie instancji przeciwników
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                //tworzenie instancji przeciwników
               if(score<5)
                {
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }
                else
                {
                    Instantiate(hazard2, spawnPosition, spawnRotation);
                }
                


                yield return new WaitForSeconds(spawnWait);// tworzenie przerwy czasowej między pojawieniem się przeciwników
            }
            yield return new WaitForSeconds(waveWait);//tworzenie przerwy czasowej między falami się przeciwników

            if(gameOver)
            {
                restartText.text = "Press 'R' fo Restart";
                restart = true;
                break;
            }
        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // aktualizacja textu z wynikiem 
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    //metoda kończąca grę
    public void GameOver()
    {
        gameOver = true;
        gameOvertext.text = "Game Over";
    }
}

