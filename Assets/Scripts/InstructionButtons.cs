using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionButtons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _spaceImage;
    [SerializeField] GameObject _leftArrow;
    [SerializeField] GameObject _rightArrow;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleWhenPress();
    }
    void HandleWhenPress()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _spaceImage.GetComponent<Image>().color = new Color32(144, 255, 160, 255);
        }
        else
        {
            _spaceImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _leftArrow.GetComponent<Image>().color = new Color32(144, 255, 160, 255);
        }
        else
        {
            _leftArrow.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rightArrow.GetComponent<Image>().color = new Color32(144, 255, 160, 255);
        }
        else
        {
            _rightArrow.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
