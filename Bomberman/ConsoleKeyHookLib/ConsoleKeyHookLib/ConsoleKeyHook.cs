using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleKeyHookLib
{
    public delegate void KeyPressedHandler();

    public class InvalidArgumentException : SystemException
    {
        public InvalidArgumentException(string message) : base(message) { }
    }

    public class ConsoleKeyHook
    {
        public event KeyPressedHandler KeyPressedEvent;

        private List<List<ConsoleKey>> validKeys;
        private List<List<ConsoleKey>> allKeysPressed;
        private ConsoleKey[] lastKeyPressed;
        private bool intercept;

        private Thread hook;

        public ConsoleKeyHook(List<List<ConsoleKey>> validKeys, bool intercept)
        {
            if (validKeys == null)
                throw new NullReferenceException();
            if (validKeys.Count <= 0)
                throw new InvalidArgumentException("validKeys.Count must be higher than 0!");

            this.validKeys = validKeys;
            this.allKeysPressed = new List<List<ConsoleKey>>();
            this.lastKeyPressed = new ConsoleKey[validKeys.Count];
            for (int i = 0; i < validKeys.Count; i++)
            {
                this.allKeysPressed.Add(new List<ConsoleKey>());
            }
            this.intercept = intercept;

            hook = new Thread(hookKeys);
        }

        public void Start()
        {
            if (hook != null)
                hook.Start();
        }

        public void Stop()
        {
            if (hook != null && hook.IsAlive)
                hook.Abort();
        }

        private void hookKeys()
        {
            bool validKeyPressed;
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                validKeyPressed = false;
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(intercept);

                    for (int i = 0; i < validKeys.Count; i++)
                    {
                        for (int j = 0; j < validKeys[i].Count; j++)
                        {
                            if (keyInfo.Key == validKeys[i][j])
                            {
                                lastKeyPressed[i] = keyInfo.Key;
                                allKeysPressed[i].Add(keyInfo.Key);
                                validKeyPressed = true;
                            }
                        }
                    }

                    if (KeyPressedEvent != null && validKeyPressed)
                        KeyPressedEvent();
                }
            }
        }

        public ConsoleKey[] GetLastKeyPressed(bool clearList)
        {
            if (clearList)
            {
                ConsoleKey[] tmpLastKeyPressed = this.lastKeyPressed.ToArray();
                this.lastKeyPressed = new ConsoleKey[lastKeyPressed.Length];
                return tmpLastKeyPressed;
            }

            return this.lastKeyPressed;
        }

        public List<List<ConsoleKey>> GetAllKeysPressed(bool clearList)
        {
            if (clearList)
            {
                List<List<ConsoleKey>> tmpAllKeysPressed = new List<List<ConsoleKey>>();
                for (int i = 0; i < this.allKeysPressed.Count; i++)
                {
                    tmpAllKeysPressed.Add(new List<ConsoleKey>());
                    for (int j = 0; j < this.allKeysPressed[i].Count; j++)
                    {
                        tmpAllKeysPressed[i].Add(this.allKeysPressed[i][j]);
                    }
                }

                for (int i = 0; i < allKeysPressed.Count; i++)
                {
                    this.allKeysPressed[i].Clear();
                }

                return tmpAllKeysPressed;
            }

            return this.allKeysPressed;
        }
    }
}
