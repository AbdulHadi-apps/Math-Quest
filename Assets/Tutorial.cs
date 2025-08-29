using UnityEngine;
using System.Collections;


public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;
    public GameObject[] Points;
    public GameObject Hand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        instance = this;
    }
   public void tart()
    {
        StartCoroutine(Tutorial.instance.Play());
    }
   public IEnumerator Play()
{
    Hand.SetActive(true);

    // Move hand to target position (Points[1])
  while (Vector3.Distance(Hand.transform.position, new Vector3(Points[1].transform.position.x, Hand.transform.position.y, Points[1].transform.position.z)) > 0.01f)
{
    Vector3 targetPos = new Vector3(
        Points[1].transform.position.x,
        Hand.transform.position.y, // Keep Y constant
        Points[1].transform.position.z
    );

    Hand.transform.position = Vector3.MoveTowards(
        Hand.transform.position,
        targetPos,
        Time.deltaTime * 2f
    );

    yield return null;
}
    // Tap animation: simulate pressing down and lifting up
    yield return new WaitForSeconds(0.5f); // Initial pause

    Hand.transform.rotation = Quaternion.Euler(-95f, 0, -164.12f);
    yield return new WaitForSeconds(0.3f);

    Hand.transform.rotation = Quaternion.Euler(-90f, 0, -164.12f);
    yield return new WaitForSeconds(0.3f);

    Hand.transform.rotation = Quaternion.Euler(-95f, 0, -164.12f);
    yield return new WaitForSeconds(0.3f);

    Hand.transform.rotation = Quaternion.Euler(-90f, 0, -164.12f);

    // Move hand back to starting position (Points[0])
    while (Vector3.Distance(Hand.transform.position, Points[0].transform.position) > 0.01f)
    {
        Hand.transform.position = Vector3.MoveTowards(
            Hand.transform.position,
            Points[0].transform.position,
            Time.deltaTime * 2f
        );
        yield return null;
    }

    // Optional: Set final rotation or deactivate hand here if needed
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
