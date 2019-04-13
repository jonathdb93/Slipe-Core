﻿using System;
using System.Collections.Generic;
using System.Text;
using Slipe.MtaDefinitions;
using Slipe.Server.IO;
using Slipe.Shared.Helpers;

namespace Slipe.Server.GameServer
{
    /// <summary>
    /// Class that handles methods on the global server
    /// </summary>
    public static class Server
    {
        #region Properties

        /// <summary>
        /// Get and set the server password
        /// </summary>
        public static string Password
        {
            get
            {
                return MtaServer.GetServerPassword();
            }
            set
            {
                MtaServer.SetServerPassword(value);
            }
        }

        /// <summary>
        /// Get and set the player limit
        /// </summary>
        public static int MaxPlayers
        {
            get
            {
                return MtaServer.GetMaxPlayers();
            }
            set
            {
                MtaServer.SetMaxPlayers(value);
            }
        }

        /// <summary>
        /// Get and set the FPS limit
        /// </summary>
        public static int FPSLimit
        {
            get
            {
                return MtaShared.GetFPSLimit();
            }
            set
            {
                MtaShared.SetFPSLimit(value);
            }
        }

        /// <summary>
        /// Get the port this server runs on
        /// </summary>
        public static int Port { get { return MtaServer.GetServerPort(); } }

        /// <summary>
        /// Get the HTTP port of this server
        /// </summary>
        public static int HTTPPort { get { return MtaServer.GetServerHttpPort(); } }

        /// <summary>
        /// Get the name of this server
        /// </summary>
        public static string Name { get { return MtaServer.GetServerName(); } }

        /// <summary>
        /// Get if voice is currently enabled
        /// </summary>
        public static bool IsVoiceEnabled
        {
            get
            {
                return MtaShared.IsVoiceEnabled();
            }
        }

        #endregion

        /// <summary>
        /// Enable or disable a certain known GTA glitch
        /// </summary>
        public static bool SetGlitchEnabled(Glitch glitch, bool enabled)
        {
            return MtaServer.SetGlitchEnabled(glitch.ToString().ToLower(), enabled);
        }

        /// <summary>
        /// Check if a certain GTA glitch is enabled
        /// </summary>
        public static bool IsGlitchEnabled(Glitch glitch)
        {
            return MtaServer.IsGlitchEnabled(glitch.ToString().ToLower());
        }

        private static Config config;
        /// <summary>
        /// Get the server config handler
        /// </summary>
        public static Config Config
        {
            get
            {
                if (config == null)
                    config = new Config();
                return config;
            }
        }

        /// <summary>
        /// Get the amount of time that the system has been running in milliseconds.
        /// </summary>
        public static int TickCount
        {
            get
            {
                return MtaShared.GetTickCount();
            }
        }

        private static SystemVersion version;
        /// <summary>
        /// Get the current MTA version of this server
        /// </summary>
        public static SystemVersion Version
        {
            get
            {
                if (version == null)
                    version = new SystemVersion();
                return version;
            }
        }

        /// <summary>
        /// Returns the MTA F8 console
        /// </summary>
        private static MtaConsole console;
        public static MtaConsole Console
        {
            get
            {
                if (console == null)
                {
                    console = new MtaConsole();
                }
                return console;
            }
        }

        /// <summary>
        /// Returns the MTA debug view
        /// </summary>
        private static MtaDebug debug;
        public static MtaDebug Debug
        {
            get
            {
                if (debug == null)
                {
                    debug = new MtaDebug();
                }
                return debug;
            }
        }

        /// <summary>
        /// Returns the MTA Server Log
        /// </summary>
        private static ServerLog log;
        public static ServerLog Log
        {
            get
            {
                if (log == null)
                {
                    log = new ServerLog();
                }
                return log;
            }
        }

        /// <summary>
        /// Get and set the limit at which clients can run their game on this server
        /// </summary>
        public static int FpsLimit
        {
            get
            {
                return MtaShared.GetFPSLimit();
            }
            set
            {
                MtaShared.SetFPSLimit(value);
            }
        }

        /// <summary>
        /// Terminates the server process
        /// </summary>
        public static void Shutdown(string reason)
        {
            MtaServer.Shutdown(reason);
        }
    }
}
