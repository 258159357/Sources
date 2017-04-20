﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Program
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using ReLogic.IO;
using ReLogic.OS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
  public static class Program
  {
    public static Dictionary<string, string> LaunchParameters = new Dictionary<string, string>();
    private static int ThingsToLoad = 0;
    private static int ThingsLoaded = 0;
    public static bool LoadedEverything = false;
    public const bool IsServer = true;
    public static IntPtr JitForcedMethodCache;

    public static float LoadedPercentage
    {
      get
      {
        if (Program.ThingsToLoad == 0)
          return 1f;
        return (float) Program.ThingsLoaded / (float) Program.ThingsToLoad;
      }
    }

    public static void StartForceLoad()
    {
      if (!Main.SkipAssemblyLoad)
        ThreadPool.QueueUserWorkItem(new WaitCallback(Program.ForceLoadThread));
      else
        Program.LoadedEverything = true;
    }

    public static void ForceLoadThread(object ThreadContext)
    {
      Program.ForceLoadAssembly(Assembly.GetExecutingAssembly(), true);
      Program.LoadedEverything = true;
    }

    private static void ForceJITOnAssembly(Assembly assembly)
    {
      foreach (Type type in assembly.GetTypes())
      {
        foreach (MethodInfo method in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (!method.IsAbstract && !method.ContainsGenericParameters && method.GetMethodBody() != null)
            RuntimeHelpers.PrepareMethod(method.MethodHandle);
        }
        ++Program.ThingsLoaded;
      }
    }

    private static void ForceStaticInitializers(Assembly assembly)
    {
      foreach (Type type in assembly.GetTypes())
      {
        if (!type.IsGenericType)
          RuntimeHelpers.RunClassConstructor(type.TypeHandle);
      }
    }

    private static void ForceLoadAssembly(Assembly assembly, bool initializeStaticMembers)
    {
      Program.ThingsToLoad = assembly.GetTypes().Length;
      Program.ForceJITOnAssembly(assembly);
      if (!initializeStaticMembers)
        return;
      Program.ForceStaticInitializers(assembly);
    }

    private static void ForceLoadAssembly(string name, bool initializeStaticMembers)
    {
      Assembly assembly = (Assembly) null;
      Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
      for (int index = 0; index < assemblies.Length; ++index)
      {
        if (assemblies[index].GetName().Name.Equals(name))
        {
          assembly = assemblies[index];
          break;
        }
      }
      if (Assembly.op_Equality(assembly, (Assembly) null))
        assembly = Assembly.Load(name);
      Program.ForceLoadAssembly(assembly, initializeStaticMembers);
    }

    private static void SetupLogging()
    {
      if (Program.LaunchParameters.ContainsKey("-logfile"))
      {
        string launchParameter = Program.LaunchParameters["-logfile"];
        ConsoleOutputMirror.ToFile(launchParameter == null || launchParameter.Trim() == "" ? Path.Combine(Main.SavePath, "Logs", string.Format("Log_{0}.log", (object) DateTime.Now.ToString("yyyyMMddHHmmssfff"))) : Path.Combine(launchParameter, string.Format("Log_{0}.log", (object) DateTime.Now.ToString("yyyyMMddHHmmssfff"))));
      }
      if (!Program.LaunchParameters.ContainsKey("-logerrors"))
        return;
      Program.HookAllExceptions();
    }

    private static void HookAllExceptions()
    {
      bool useMiniDumps = Program.LaunchParameters.ContainsKey("-minidump");
      bool useFullDumps = Program.LaunchParameters.ContainsKey("-fulldump");
      Console.WriteLine("Error Logging Enabled.");
      CrashDump.Options dumpOptions = CrashDump.Options.WithFullMemory;
      if (useFullDumps)
        Console.WriteLine("Full Dump logs enabled.");
      AppDomain.CurrentDomain.add_FirstChanceException((EventHandler<FirstChanceExceptionEventArgs>) ((sender, exceptionArgs) =>
      {
        Console.Write("================\r\n" + string.Format("{0}: First-Chance Exception\r\nCulture: {1}\r\nException: {2}\r\n", (object) DateTime.Now, (object) Thread.CurrentThread.CurrentCulture.Name, (object) exceptionArgs.get_Exception().ToString()) + "================\r\n\r\n");
        if (!useMiniDumps)
          return;
        CrashDump.WriteException(CrashDump.Options.WithIndirectlyReferencedMemory, Path.Combine(Main.SavePath, "Dumps"));
      }));
      AppDomain.CurrentDomain.UnhandledException += (UnhandledExceptionEventHandler) ((sender, exceptionArgs) =>
      {
        Console.Write("================\r\n" + string.Format("{0}: Unhandled Exception\r\nCulture: {1}\r\nException: {2}\r\n", (object) DateTime.Now, (object) Thread.CurrentThread.CurrentCulture.Name, (object) exceptionArgs.ExceptionObject.ToString()) + "================\r\n");
        if (!useFullDumps)
          return;
        CrashDump.WriteException(dumpOptions, Path.Combine(Main.SavePath, "Dumps"));
      });
    }

    private static void InitializeConsoleOutput()
    {
      try
      {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
      }
      catch
      {
      }
    }

    public static void LaunchGame(string[] args, bool monoArgs = false)
    {
      if (monoArgs)
        args = Utils.ConvertMonoArgsToDotNet(args);
      if (Platform.get_IsOSX())
      {
        // ISSUE: reference to a compiler-generated field
        if (Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5 = new Action((object) null, __methodptr(\u003CLaunchGame\u003Eb__4));
        }
        // ISSUE: reference to a compiler-generated field
        Main.OnEngineLoad += Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5;
      }
      Program.LaunchParameters = Utils.ParseArguements(args);
      ThreadPool.SetMinThreads(8, 8);
      LanguageManager.Instance.SetLanguage(GameCulture.English);
      Program.SetupLogging();
      using (Main game = new Main())
      {
        try
        {
          Program.InitializeConsoleOutput();
          Lang.InitializeLegacyLocalization();
          SocialAPI.Initialize(new SocialMode?());
          LaunchInitializer.LoadParameters(game);
          // ISSUE: method pointer
          Main.OnEnginePreload += new Action((object) null, __methodptr(StartForceLoad));
          game.DedServ();
        }
        catch (Exception ex)
        {
          Program.DisplayException(ex);
        }
      }
    }

    private static void DisplayException(Exception e)
    {
      try
      {
        using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
        {
          streamWriter.WriteLine((object) DateTime.Now);
          streamWriter.WriteLine((object) e);
          streamWriter.WriteLine("");
        }
        Console.WriteLine(Language.GetTextValue("Error.ServerCrash"), (object) DateTime.Now, (object) e);
      }
      catch
      {
      }
    }
  }
}
