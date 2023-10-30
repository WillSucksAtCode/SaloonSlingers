using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{

    public interface ICommand
    {
        void Execute();
    }

    public static Invoker Instance { get; private set; }

    private Stack<ICommand> _commands = new Stack<ICommand>();

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; 
    }

    public void AddCommand(ICommand command)
    {
        command.Execute();
        //m_CommandsBuffer.Push(command);
    }

}
