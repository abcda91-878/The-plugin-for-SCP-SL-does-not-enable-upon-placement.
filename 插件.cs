using CommandSystem;
using Exiled.API.Features;
using System;

namespace BC_Chat
{
    /// <summary>
    /// 公屏发言工具：把消息推送到所有玩家屏幕
    /// </summary>
    public static class PublicScreen
    {
        public static object Players { get; private set; }

        /// <summary>
        /// 将消息广播到所有玩家公屏
        /// </summary>
        /// <param name="arguments">命令参数</param>
        /// <param name="sender">命令发送者</param>
        /// <param name="prefix">消息前缀</param>
        /// <param name="response">命令响应文本</param>
        /// <returns>是否执行成功</returns>
        public static bool Send(ArraySegment<string> arguments, ICommandSender sender, string prefix, out string response)
        {
            if (arguments.Count < 1)
            {
                response = "用法: .命令 <要发送的消息内容>";
                return false;
            }

            string message = string.Join(" ", arguments);

            if (Plugin.Instance.Config.ShowSenderName)
            {
                string senderName = "服务器";
                Player player = Player.Get(sender);
                if (player != null)
                {
                    senderName = player.Nickname;
                }

                message = $"{prefix} <color=#FFFF00>{senderName}:</color> {message}";
            }
            else
            {
                message = $"{prefix} {message}";
            }

            Map.Broadcast(Plugin.Instance.Config.BroadcastDuration, message);
            response = "已发送到公屏";
            return true;
        }
    }

    /// <summary>
    /// .bc 命令：发送消息到公屏（广播样式）
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class BcCommand : ICommand
    {
        /// <inheritdoc />
        public string Command => "bc";

        /// <inheritdoc />
        public string[] Aliases => Array.Empty<string>();

        /// <inheritdoc />
        public string Description => "发送消息到公屏（广播样式）";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            return PublicScreen.Send(arguments, sender, Plugin.Instance.Config.BcPrefix, out response);
        }
    }

    /// <summary>
    /// .c 命令：发送消息到公屏（聊天样式）
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CCommand : ICommand
    {
        /// <inheritdoc />
        public string Command => "c";

        /// <inheritdoc />
        public string[] Aliases => Array.Empty<string>();

        /// <inheritdoc />
        public string Description => "发送消息到公屏（聊天样式）";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            return PublicScreen.Send(arguments, sender, Plugin.Instance.Config.CPrefix, out response);
        }
    }

    internal class RemoteAdminCommandHandler
    {
    }

    /// <summary>
    /// .ac 命令：发送消息到公屏（公告样式）
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class AcCommand : ICommand
    {
        /// <inheritdoc />
        public string Command => "ac";

        /// <inheritdoc />
        public string[] Aliases => Array.Empty<string>();

        /// <inheritdoc />
        public string Description => "发送消息到公屏（公告样式）";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            return PublicScreen.Send(arguments, sender, Plugin.Instance.Config.AcPrefix, out response);
        }
    }
}
