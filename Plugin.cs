using Exiled.API.Features;
using System;

namespace BC_Chat
{
    /// <summary>
    /// 公屏发言插件主类
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        /// <inheritdoc />
        public override string Name => "BC_Chat";

        /// <inheritdoc />
        public override string Author => "Doubao";

        /// <inheritdoc />
        public override string Prefix => "bc_chat";

        /// <inheritdoc />
        public override Version Version => new Version(1, 0, 0);

        /// <inheritdoc />
        public override Version RequiredExiledVersion => new Version(9, 14, 2);

        /// <summary>
        /// 插件单例，供命令类读取配置使用
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;
            Log.Info($"{Name} 已启用");
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}
