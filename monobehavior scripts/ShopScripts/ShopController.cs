using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class ShopController : MonoBehaviour
{
    public TextMeshPro playerTMP, item1TMP, item2TMP, item3TMP, item4TMP;
    // Start is called before the first frame update
    void Start()
    {
        this.updatePlayerTMP();

        //read plain text file
        this.readItemsData();

        //read json file with serialization
        string jsonString = this.readItemsDataJson();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        // Output the data to the console
        foreach (var item in root.items)
        {
            print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        }

        this.item1TMP.text = root.item[0];
        this.item2TMP.text = root.item[1]; 
        this.item3TMP.text = root.item[2]; 
        this.item4TMP.text = root.item[3]; 

        private void updatePlayerTMP()
        {
            this.playerTMP.text = "Pellets: " + MySingleton.currentPellets + "(HP: " + MySingleton.thePlayer.getHP() + ")"; ;
        }

        private void readItemsData()
        {
            string filePath = "Assets/Data Files/items.txt"; // Path to the file"

            // Check if the file exists
            if (File.Exists(filePath))
            {
                try
                {
                    // Open the file to read from
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        string[] itemParts = new string[3];

                        int pos = 0;
                        // Read and display lines from the file until the end of the file is reached
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(",");
                            for (int i = 0; i < parts.Length; i++)
                            {
                                itemParts[pos % 3] = parts[i];
                                pos++;
                            }
                            Item theItem = new Item(itemParts[0], itemParts[1], int.Parse(itemParts[2]));
                            theItem.display();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display any errors that occurred during reading the file
                    print("An error occurred while reading the file:");
                    print(ex.Message);
                }
            }
            else
            {
                print("The file does not exist.");
            }
        }

        private string readItemsDataJson()
        {
            string filePath = "Assets/Data Files/items_data_json.txt"; // Path to the file
            string answer = "";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                try
                {
                    print("Serialized JSON Parsing");
                    // Open the file to read from
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        // Read and display lines from the file until the end of the file is reached
                        while ((line = reader.ReadLine()) != null)
                        {
                            answer = answer + line;
                        }
                        return answer;
                    }
                }
                catch (Exception ex)
                {
                    // Display any errors that occurred during reading the file
                    print("An error occurred while reading the file:");
                    print(ex.Message);
                    return null;
                }
            }
            else
            {
                print("The file does not exist.");
                return null;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                if (MySingleton.currentPellets >= root.item[0];)
                {
                    MySingleton.currentPellets -= root.item[0].modifier;
                    MySingleton.thePlayer.addHP(5);
                    this.updatePlayerTMP();
                }
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                if (MySingleton.currentPellets >= root.item[1];)
                {
                    MySingleton.currentPellets -= root.item[1].modifier;
                    MySingleton.thePlayer.addHP(5);
                    this.updatePlayerTMP();
                }
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                if (MySingleton.currentPellets >= root.item[2];)
                {
                    MySingleton.currentPellets -= root.item[2].modifier;
                    MySingleton.thePlayer.addHP(5);
                    this.updatePlayerTMP();
                }
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                if (MySingleton.currentPellets >= root.item[3];)
                {
                    MySingleton.currentPellets -= root.item[3].modifier);
                    MySingleton.thePlayer.addHP(5);
                    this.updatePlayerTMP();
                }
            }
        }


        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.item1TMP.text = root.item[0];
            this.item2TMP.text = root.item[1];
            this.item3TMP.text = root.item[2];
            this.item4TMP.text = root.item[3];
        }
   

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.item1TMP.text = root.item[4];
            this.item2TMP.text = root.item[5];
            this.item3TMP.text = root.item[6];
            this.item4TMP.text = root.item[7];
        }
       
    } 
}
