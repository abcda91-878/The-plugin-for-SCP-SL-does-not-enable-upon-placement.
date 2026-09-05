using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BC_Chat
{
    /// <summary>
    /// 公屏发言插件配置
    /// </summary>
    public class Config : IConfig
    {
        /// <summary>
        /// 是否启用插件（Exiled 强制要求）
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// 调试模式
        /// </summary>
        public bool Debug { get; set; } = false;

        [Description("消息在公屏上的显示时长（秒）")]
        public ushort BroadcastDuration { get; set; } = 5;

        [Description("是否在消息前显示发送者名字")]
        public bool ShowSenderName { get; set; } = true;

        [Description(".bc 命令的消息前缀（支持富文本颜色标签）")]
        public string BcPrefix { get; set; } = "<color=#00FF00>[公屏]</color>";

        [Description(".c 命令的消息前缀（支持富文本颜色标签）")]
        public string CPrefix { get; set; } = "<color=#FFA500>[广播]</color>";

        [Description(".ac 命令的消息前缀（支持富文本颜色标签）")]
        public string AcPrefix { get; set; } = "<color=#FF4500>[公告]</color>";
    }
    
 }