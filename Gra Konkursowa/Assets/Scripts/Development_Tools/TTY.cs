using Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class TTY : MonoBehaviour
{
    [SerializeField]
    GameObject tty;
    [SerializeField]
    GameObject ttyOut;
    [SerializeField]
    TMP_InputField ttyIn;
    [SerializeField]
    GameObject ttyFedPrefab;
    public List<string> ttyHistory = new List<string>();
    private string ttyHistoryPath;
    private FileStream ttyHistoryStream;
    private BinaryWriter ttyHistoryWriter;
    public int ttyHistoryIndex; //index of elemnt from history on console

    private void Awake()
    {
        ttyHistoryPath = Application.persistentDataPath + @"\tty.hist";
        if (File.Exists(ttyHistoryPath))
        {
            ttyHistoryStream = File.Open(ttyHistoryPath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(ttyHistoryStream);
            while (ttyHistoryStream.Position < ttyHistoryStream.Length)
            {
                int data = reader.ReadInt32();
                if (data == 0)
                {
                    ttyHistory.Add("");
                }
                else
                {
                    ttyHistory[ttyHistory.Count - 1] += Encoding.UTF32.GetString(BitConverter.GetBytes(data));
                }
            }
            ttyHistoryIndex = ttyHistory.Count - 1;
        }
        else ttyHistoryStream = File.Create(ttyHistoryPath);
        ttyHistoryStream.Close();
    }

    public void OpenConsole_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, tty.activeInHierarchy);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, tty.activeInHierarchy);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, tty.activeInHierarchy);

        tty.SetActive(!tty.activeInHierarchy);
    }

    public void CommandChanged()
    {
        if (ttyIn.text != "")
        {
            ExecuteCommand(new Command(ttyIn.text, ' ', '"'));
            ttyHistoryStream = File.Open(ttyHistoryPath, FileMode.Append);
            ttyHistoryWriter = new BinaryWriter(ttyHistoryStream);
            ttyHistory.Add(ttyIn.text);
            ttyHistoryIndex = ttyHistory.Count;
            ttyHistoryWriter.Write((int)0);
            ttyHistoryStream.Write(Encoding.UTF32.GetBytes(ttyIn.text), 0, Encoding.UTF32.GetBytes(ttyIn.text).Length);
            ttyHistoryStream.Close();
            ttyIn.text = "";
        }
    }

    public void ExecuteCommand(Command command)
    {
        string fed = "";
        if (command.Cmd[0] == '/')
        {
            switch (command.Cmd.Substring(1))
            {
                case "godmode":
                    if (command.Args.Length == 0)
                    {
                        fed = "this command requires one argument";
                        break;
                    }
                    if (command.Args[0] == "ON")
                    {
                        G_Controller.instatnce.Godmode = true;
                        fed = "godmode turned on";
                    }
                    else if (command.Args[0] == "OFF")
                    {
                        G_Controller.instatnce.Godmode = false;
                        fed = "godmode turned off";
                    }
                    else
                    {
                        fed = "err in arg 1, unknown option \"" + command.Args[0] + "\"\ntype ?godmode to get more information regarding this command";
                    }
                    break;
                case "scene":
                    if (command.Args.Length == 0)
                    {
                        fed = "this command requires one argument";
                        break;
                    }
                    else
                    {
                        bool err = false;
                        try
                        {
                            G_Controller.instatnce.UIController.PreparingForLoading(command.Args[0], nameDirect:true);
                        }
                        catch (Exception ex)
                        {
                            fed = "encountered error when parsing argument one \"" + command.Args[0] + "\"\ncheck if this scene is included in the build";
                            err = true;
                        }
                        if (!err)
                        {
                            fed = "switching scene";
                        }
                    }
                    break;
                case "reset":
                    G_Controller.instatnce.ResetPlayerProgress();
                    fed = "progress ereased";
                    break;
                default:
                    fed = "unknown command \"" + command.Cmd + "\"\ntype ? to get a list of commands";
                    break;
            }
        }
        else if (command.Cmd[0] == '?')
        {
            if (command.Cmd.Length == 1)
            {
                fed = "/godmode <ON/OFF> - turns on and off godmode\n/reset - ereases progress\n/sceme <name> - loads scene by name\n=scrap <amount> - sets amount of scrap\n=xp <amount> - sets amount of xp";
            }
            else
            {
                switch (command.Cmd.Substring(1))
                {
                    case "godmode":
                        fed = "arg 0 - \"ON\" to turn on, \"OFF\" to turn off";
                        break;
                    default:
                        fed = "unknown command \"" + command.Cmd + "\"\ntype ? to get a list of commands";
                        break;
                }
            }
        }
        else if (command.Cmd[0] == '=')
        {
            switch (command.Cmd.Substring(1))
            {
                case "scrap":
                    if (command.Args.Length == 0)
                    {
                        fed = "this command requires one argument";
                        break;
                    }
                    else
                    {
                        bool err = false;
                        try
                        {
                            G_Controller.instatnce.PlayerMoney.Scrap = long.Parse(command.Args[0]);
                        }
                        catch (Exception ex)
                        {
                            fed = "encountered error when parsing argument one \"" + command.Args[0] + "\"\ncheck if you typed a valid number";
                            err = true;
                        }
                        if (!err)
                        {
                            fed = "set scrap amount to " + G_Controller.instatnce.PlayerMoney.Scrap.ToString();
                        }
                    }
                    break;
                case "xp":
                    if (command.Args.Length == 0)
                    {
                        fed = "this command requires one argument";
                        break;
                    }
                    else
                    {
                        bool err = false;
                        try
                        {
                            G_Controller.instatnce.PlayerExperience.XP = float.Parse(command.Args[0]);
                        }
                        catch (Exception ex)
                        {
                            fed = "encountered error when parsing argument one \"" + command.Args[0] + "\"\ncheck if you typed a valid number";
                            err = true;
                        }
                        if (!err)
                        {
                            fed = "set xp to " + G_Controller.instatnce.PlayerExperience.XP.ToString();
                        }
                    }
                    break;
                default:
                    fed = "unknown command \"" + command.Cmd + "\"\ntype ? to get a list of commands";
                    break;
            }
        }
        else
        {
            fed = "unknown statement, first letter of a command must be statement\n? - shows help\n= - sets number variables\n/ - actions";
        }
        GameObject msg = Instantiate(ttyFedPrefab, ttyOut.transform);
        msg.GetComponent<TMP_Text>().text = fed;
    }
}
