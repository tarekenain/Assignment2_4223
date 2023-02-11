using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public EnemyProducer enemyProducer;
    public GameObject playerPrefab;

    public string playerHealth;
    public bool isAlive = true;

    public Text livesText;

    void Start () {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onPlayerDeath += onPlayerDeath;
    }

    void onPlayerDeath(Player player) {
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);
        isAlive = false;

        Invoke("restartGame", 3);
    }

    void restartGame() {
        isAlive = true;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies){
            Destroy(enemy);
        }

        var playerObject = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
        var cameraRig = Camera.main.GetComponent<CameraRig>();
        cameraRig.target = playerObject;
        enemyProducer.SpawnEnemies(true);
        playerObject.GetComponent<Player>().onPlayerDeath += onPlayerDeath;



    }

    void Update(){

        if (isAlive == false){
            playerHealth = "0";
            livesText.text = "Lives: " + playerHealth;
        } else {
            var currentLives = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            playerHealth = currentLives.health.ToString();
            livesText.text = "Lives: " + playerHealth;
        }
    
        
    }

}
