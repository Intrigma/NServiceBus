using Castle.MicroKernel;

namespace NServiceBus.ObjectBuilder.CastleWindsor
{
    /// <summary>
    /// Castle Windsor implementation of IComponentConfig.
    /// </summary>
    public class ConfigureComponentAdapter : IComponentConfig
    {
        private readonly IHandler handler;

        /// <summary>
        /// Instantiates the class and saves the given IHandler object.
        /// </summary>
        /// <param name="handler"></param>
        public ConfigureComponentAdapter(IHandler handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Calls AddCustomDependencyValue on the previously given handler.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IComponentConfig ConfigureProperty(string name, object value)
        {
            // TODO I've commented it because I believe it is used for Property injection. And we do noy use it in Handlers
            //handler.AddCustomDependencyValue(name, value);

            return this;
        }
    }
}
