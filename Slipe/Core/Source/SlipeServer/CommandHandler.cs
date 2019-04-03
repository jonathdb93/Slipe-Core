﻿using Slipe.MTADefinitions;
using Slipe.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slipe.Server
{
    /// <summary>
    /// Represents a single command handler
    /// </summary>
    public class CommandHandler
    {
        private Action<Player, string, string[]> callback;
        private Action<string, string[]> consoleCallback;

        /// <summary>
        /// Adds a command handler to be used by players
        /// </summary>
        /// <param name="command"></param>
        /// <param name="callback"></param>
        /// <param name="restricted"></param>
        /// <param name="caseSensitive"></param>
        public CommandHandler(string command, Action<Player, string, string[]> callback, bool restricted = false, bool caseSensitive = true)
        {
            this.callback = callback;
            MTAServer.AddCommandHandler(command, CommandHandlerCallback, restricted, caseSensitive);
        }

        /// <summary>
        /// Adds a command handler to be used by the console
        /// </summary>
        /// <param name="command"></param>
        /// <param name="consoleCallback"></param>
        /// <param name="restricted"></param>
        /// <param name="caseSensitive"></param>
        public CommandHandler(string command, Action<string, string[]> consoleCallback, bool restricted = false, bool caseSensitive = true)
        {
            this.consoleCallback = consoleCallback;
            MTAServer.AddCommandHandler(command, CommandHandlerCallback, restricted, caseSensitive);
        }

        private void CommandHandlerCallback(MTAElement element, string command, string[] parameters)
        {
            if (MTAShared.GetElementType(element) == "console")
            {
                this.consoleCallback?.Invoke(command, parameters);
            } else
            {
                this.callback?.Invoke(element == null ? null : (Player)ElementManager.Instance.GetElement(element), command, parameters);
            }
        }
    }
}