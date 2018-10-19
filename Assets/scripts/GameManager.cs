using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
  
  public GameObject gameOverMenu,gameWonMenu;
  public GameObject button;
  public static bool gamehasEnded=false;
  private bool gameIsWon=false;
  public float velocity = 1;
   
  public TextMeshProUGUI ScoreUpdate,ScoreFinal;
  private float depth=0;
  private float height;

  void Awake(){
    FindObjectOfType<AnimatedTexture>().putGoingUpFalse();
    Time.timeScale=1;      
  }
   
  public void toMainMenu(){
      SceneManager.LoadScene("menu");
  }
    public void Restart(){
       gameOverMenu.SetActive(false);
       gameWonMenu.SetActive(false);
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
       FindObjectOfType<AnimatedTexture>().putGoingUpFalse();
             Time.timeScale=1;
       gamehasEnded=false;
       gameIsWon=false;
       depth=0;
   }

   void Update(){
       if(FindObjectOfType<AnimatedTexture>().getGoingUp()){
            button.SetActive(false);
            height--;
            if(height==0){
                gameIsWon=true;
                gameWon();
            }
       }
       else
          height= depth++;
       ScoreUpdate.text="SCORE: "+depth.ToString();
       velocity += 0.001f;
   }
    public void gameOver(){
        if(!gamehasEnded){
            gameOverMenu.SetActive(true);
            Time.timeScale=0;
            button.SetActive(false);
        }
   } 
   
   void gameWon(){
        if(gameIsWon){
	     print("SCORE:"+depth);
         ScoreFinal.text="SCORE:"+depth.ToString();
         gameWonMenu.SetActive(true);
         print(Time.timeScale);
         Time.timeScale=0;
         button.SetActive(false);
         
       }      

   }
}
