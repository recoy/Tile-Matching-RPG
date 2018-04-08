using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClick : MonoBehaviour
{

    public RandomMapGenerator2D tileGenerator;
    RaycastHit hit;
    public int color;
    public GameObject player1, player2, gameOverPanel;
    public Button[] player1Buttons, player2Buttons;
    public GameObject endTurn;
    private PlayerController player1PC, player2PC, whichPlayerHasTurn;
    public int playerTurn = 1;
    public List<GameObject> destroy = new List<GameObject>();
    public Text movesText;
    private int movesLeft;
    public int maxMoves;
    public int green = 0, blue = 0, red = 0;


    // Use this for initialization
    void Start()
    {
        gameOverPanel.SetActive(false);
        player1PC = player1.GetComponent<PlayerController>();
        player2PC = player2.GetComponent<PlayerController>();
        tileGenerator = GetComponent<RandomMapGenerator2D>();
        maxMoves = player1PC.maxMoves;
        movesLeft = maxMoves;
        movesText.text = maxMoves.ToString();
        foreach (Button button in player2Buttons)
        {
            button.interactable = false;
        }
        endTurn.SetActive(false);
    }

    public void GenerateNewTiles()
    {
        //destroy.Clear();
        tileGenerator.GenerateTiles();
        movesLeft = maxMoves;
        //movesText.text = movesLeft.ToString();
        ChangeTurn(whichPlayerHasTurn);

        green = blue = red = 0;
    }

    public void DamageAnotherPlayer(int attackValue)
    {
        if (playerTurn == 1)
        {
            int health = player2.GetComponent<PlayerAttributes>().currentHealth -= attackValue;
            player2.GetComponent<PlayerAttributes>().RefreshAttributeTexts();
            if (health <= 0)
            {
                gameOverPanel.SetActive(true);
                gameOverPanel.GetComponentInChildren<Text>().text = "PLAYER 1 WINS";
            }
        }
        else
        {
            int health = player1.GetComponent<PlayerAttributes>().currentHealth -= attackValue;
            player1.GetComponent<PlayerAttributes>().RefreshAttributeTexts();
            if (health <= 0)
            {
                gameOverPanel.SetActive(true);
                gameOverPanel.GetComponentInChildren<Text>().text = "PLAYER 2 WINS";
            }
        }
    }

    private void ChangeTurn(PlayerController pc)
    {
        pc.TurnEnd();
        endTurn.SetActive(false);
        if (playerTurn == 1)
        {
            playerTurn = 2;
            player1PC.enabled = false;
            player2PC.enabled = true;
            maxMoves = player2PC.maxMoves;
            movesText.text = maxMoves.ToString();
            movesLeft = maxMoves;
            foreach (Button button in player1Buttons)
            {
                button.interactable = false;
            }
            foreach (Button button in player2Buttons)
            {
                button.interactable = true;
            }
        }
        else
        {
            playerTurn = 1;
            player1PC.enabled = true;
            player2PC.enabled = false;
            maxMoves = player1PC.maxMoves;
            movesText.text = maxMoves.ToString();
            movesLeft = maxMoves;
            foreach (Button button in player1Buttons)
            {
                button.interactable = true;
            }
            foreach (Button button in player2Buttons)
            {
                button.interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && movesLeft > 0)
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Tile")
            {
                destroy.Add(hit.collider.gameObject);
                StartCoroutine(CheckNeighbours(hit.collider.gameObject));
                DecreaseMoves(whichPlayerHasTurn);
            }
        }
    }

    void DecreaseMoves(PlayerController pc)
    {
        movesLeft--;
        pc.DecreaseMoves();
        if (movesLeft <= 0)
        {
            endTurn.SetActive(true);
        }
    }

    void AddProbs(PlayerController pc)
    {
        if (color == 1)
        {
            pc.blue += 1;
            pc.RefreshProbTexts("blue");
            pc.AddProbsToArray("blue");
        }
        else if (color == 2)
        {
            pc.green += 1;
            pc.RefreshProbTexts("green");
            pc.AddProbsToArray("green");
        }
        else if (color == 3)
        {
            pc.red += 1;
            pc.RefreshProbTexts("red");
            pc.AddProbsToArray("red");
        }
    }

    private IEnumerator CheckNeighbours(GameObject go)
    {
        if (playerTurn == 1)
            whichPlayerHasTurn = player1PC;
        else
            whichPlayerHasTurn = player2PC;
        color = go.GetComponent<TileSpecs>().colorInt;
        TileSpecs goSpecs = go.GetComponent<TileSpecs>();
        if (!goSpecs.hasChecked)
        {
            if (Physics.Raycast(go.transform.position, Vector3.up, out hit, 1f) && hit.collider.tag == "Tile" && hit.collider.gameObject.GetComponent<TileSpecs>().colorInt == color)
            {
                if (!hit.collider.gameObject.GetComponent<TileSpecs>().hasChecked && !hit.collider.gameObject.GetComponent<TileSpecs>().isAdded)
                {
                    goSpecs.neighboursList.Add(hit.collider.gameObject);
                    destroy.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<TileSpecs>().isAdded = true;
                }
            }

            if (Physics.Raycast(go.transform.position, Vector3.down, out hit, 1f) && hit.collider.tag == "Tile" && hit.collider.gameObject.GetComponent<TileSpecs>().colorInt == color)
            {
                if (!hit.collider.gameObject.GetComponent<TileSpecs>().hasChecked && !hit.collider.gameObject.GetComponent<TileSpecs>().isAdded)
                {
                    goSpecs.neighboursList.Add(hit.collider.gameObject);
                    destroy.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<TileSpecs>().isAdded = true;
                }
            }

            if (Physics.Raycast(go.transform.position, Vector3.left, out hit, 1f) && hit.collider.tag == "Tile" && hit.collider.gameObject.GetComponent<TileSpecs>().colorInt == color)
            {
                if (!hit.collider.gameObject.GetComponent<TileSpecs>().hasChecked && !hit.collider.gameObject.GetComponent<TileSpecs>().isAdded)
                {
                    goSpecs.neighboursList.Add(hit.collider.gameObject);
                    destroy.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<TileSpecs>().isAdded = true;
                }
            }

            if (Physics.Raycast(go.transform.position, Vector3.right, out hit, 1f) && hit.collider.tag == "Tile" && hit.collider.gameObject.GetComponent<TileSpecs>().colorInt == color)
            {
                if (!hit.collider.gameObject.GetComponent<TileSpecs>().hasChecked && !hit.collider.gameObject.GetComponent<TileSpecs>().isAdded)
                {
                    goSpecs.neighboursList.Add(hit.collider.gameObject);
                    destroy.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<TileSpecs>().isAdded = true;
                }
            }

            goSpecs.hasChecked = true;

            yield return new WaitForSeconds(0.0f);

            if (goSpecs.neighboursList.Count != 0)
            {

                for (int i = 0; i < goSpecs.neighboursList.Count; i++)
                {
                    yield return new WaitForSeconds(0.0f);

                    StartCoroutine(CheckNeighbours(goSpecs.neighboursList[i]));
                }
            }
            else
            {
                for (int i = 0; i < destroy.Count; i++)
                {
                    if (destroy[i].GetComponent<TileSpecs>().isAdded == true && destroy[i].GetComponent<TileSpecs>().hasChecked == false)
                    {
                        StartCoroutine(CheckNeighbours(destroy[i]));
                    }
                }

                yield return new WaitForSeconds(0.0f);

                for (int i = 0; i < destroy.Count; i++)
                {
                    if (color == 1)
                    {
                        blue++;
                        AddProbs(whichPlayerHasTurn);
                    }
                    else if (color == 2)
                    {
                        green++;
                        AddProbs(whichPlayerHasTurn);
                    }
                    else if (color == 3)
                    {
                        red++;
                        AddProbs(whichPlayerHasTurn);
                    }
                    Destroy(destroy[i]);
                    //Debug.Log("Destroyed tiles: "+ x);

                    //destroy.Remove(destroy[i]);
                }

                destroy.Clear();
            }
        }
    }
}